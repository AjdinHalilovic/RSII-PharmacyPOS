using Microsoft.AspNetCore.Mvc;
using Pharmacy.API.Controllers;
using Pharmacy.API.Filters;
using Pharmacy.Core.Constants.Configurations;
using Pharmacy.Core.Entities.Base;
using Pharmacy.Core.Entities.Base.DTO;
using Pharmacy.Core.Helpers;
using Pharmacy.Core.Helpers.TokenProcessor;
using Pharmacy.Core.Models;
using Pharmacy.Core.Models.Access;
using Pharmacy.Core.Models.Billing;
using Pharmacy.Core.Models.Users;
using Pharmacy.Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.API.Areas.Billing
{
    [ApiController, TokenValidation, Area("Billing")]
    [Route("[controller]")]
    public class InventoryIntermediatesController : BaseController
    {
        public InventoryIntermediatesController(IDataUnitOfWork dataUnitOfWork) : base(dataUnitOfWork)
        {
        }

        #region Get

        //[HttpGet]
        //public async Task<IActionResult> Get([FromQuery] BaseSearchObject search)
        //{
        //    try
        //    {
        //        search.PharmacyBranchId = ClaimUser.PharmacyBranchId;
        //        var inventoryEntries = await DataUnitOfWork.BaseUow.InventoryEntriesRepository.GetAllDtosByParametersAsync(search);

        //        return Ok(inventoryEntries);
        //    }
        //    catch (Exception ex)
        //    {

        //        return BadRequest();
        //        throw;
        //    }
        //}
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    return Ok(await DataUnitOfWork.BaseUow.InventoryEntriesRepository.GetByIdAsync(id));
        //}
        #endregion


        #region Insert
        [HttpPost]
        public async Task<IActionResult> Insert(InventoryIntermediateUpsertRequest request)
        {
            DataUnitOfWork.BaseUow.BeginTransaction();
            try
            {
                #region Intermediate

                InventoryIntermediate inventoryIntermediate = request;
                inventoryIntermediate.FromInventoryId = ClaimUser.InventoryId;
                inventoryIntermediate.UserId = ClaimUser.UserId;

                DataUnitOfWork.BaseUow.InventoryIntermediatesRepository.Add(inventoryIntermediate);
                await DataUnitOfWork.BaseUow.InventoryIntermediatesRepository.SaveChangesAsync();
                #endregion

                #region Intermediate products
                request.IntermediateProducts.ForEach(x => x.InventoryIntermediateId = inventoryIntermediate.Id);
                var intermediateProductsInsert = request.IntermediateProducts;
                intermediateProductsInsert.ForEach(x => x.Product = null);
                DataUnitOfWork.BaseUow.InventoryIntermediateProductsRepository.AddRange(intermediateProductsInsert);
                await DataUnitOfWork.BaseUow.InventoryIntermediateProductsRepository.SaveChangesAsync();
                #endregion

                #region To inventory products
                var products = (await DataUnitOfWork.BaseUow.ProductsRepository.GetByListIdsAsync(request.IntermediateProducts.Select(x => x.ProductId).ToList())).ToList();

                var toInventoryProducts = (await DataUnitOfWork.BaseUow.InventoryProductsRepository.GetByInventoryIdAndProductCodes(inventoryIntermediate.ToInventoryId, products.Select(x => x.Code).ToList())).ToList();
                toInventoryProducts.ForEach(x => x.Quantity += request.IntermediateProducts.FirstOrDefault(y => y.Product.Code.Equals(x.Product.Code)).Quantity);
                DataUnitOfWork.BaseUow.InventoryProductsRepository.UpdateRange(toInventoryProducts);

                var newBranchProducts = request.IntermediateProducts.Where(x => toInventoryProducts.Select(y => y.Product.Code).Contains(x.Product.Code)).ToList();
                if(newBranchProducts.Count > 0)
                {
                    #region new products
                    var inventory = await DataUnitOfWork.BaseUow.InventoriesRepository.GetByIdAsync(inventoryIntermediate.ToInventoryId);
                    var newProducts = (await DataUnitOfWork.BaseUow.ProductsRepository.GetByListIdsAsync(newBranchProducts.Select(x=>x.ProductId).ToList())).ToList();
                    newProducts.ForEach(x => { x.Id = 0; x.PharmacyBranchId = inventory.PharmacyBranchId; });

                    DataUnitOfWork.BaseUow.ProductsRepository.AddRange(newProducts);
                    await DataUnitOfWork.BaseUow.ProductsRepository.SaveChangesAsync();

                    #region attributes
                    var newProductAttributes = (await DataUnitOfWork.BaseUow.ProductAttributesRepository.GetByProductIdsAsync(newBranchProducts.Select(x => x.ProductId).ToList())).ToList();
                    newProductAttributes.ForEach(x => { x.Id = 0; x.ProductId = newProducts.FirstOrDefault(y => y.Code == x.Product.Code).Id; });

                    DataUnitOfWork.BaseUow.ProductAttributesRepository.AddRange(newProductAttributes);
                    await DataUnitOfWork.BaseUow.ProductAttributesRepository.SaveChangesAsync();
                    #endregion

                    #region substances
                    var newProductSubstances = (await DataUnitOfWork.BaseUow.ProductSubstancesRepository.GetByProductIdsAsync(newBranchProducts.Select(x => x.ProductId).ToList())).ToList();
                    newProductSubstances.ForEach(x => { x.Id = 0; x.ProductId = newProducts.FirstOrDefault(y => y.Code == x.Product.Code).Id; });

                    DataUnitOfWork.BaseUow.ProductSubstancesRepository.AddRange(newProductSubstances);
                    await DataUnitOfWork.BaseUow.ProductSubstancesRepository.SaveChangesAsync();
                    #endregion

                    #region categories
                    var newProductCategories = (await DataUnitOfWork.BaseUow.ProductCategoriesRepository.GetByProductIdsAsync(newBranchProducts.Select(x => x.ProductId).ToList())).ToList();
                    newProductCategories.ForEach(x => { x.Id = 0; x.ProductId = newProducts.FirstOrDefault(y => y.Code == x.Product.Code).Id; });

                    DataUnitOfWork.BaseUow.ProductCategoriesRepository.AddRange(newProductCategories);
                    await DataUnitOfWork.BaseUow.ProductCategoriesRepository.SaveChangesAsync();
                    #endregion

                    var newInventoryProducts = newProducts.Select(x => new InventoryProduct() { InventoryId = inventoryIntermediate.ToInventoryId, ProductId = x.Id, Quantity = request.IntermediateProducts.FirstOrDefault(y => y.Product.Code.Equals(x.Code)).Quantity }).ToList();
                    DataUnitOfWork.BaseUow.InventoryProductsRepository.AddRange(newInventoryProducts);
                    await DataUnitOfWork.BaseUow.InventoryProductsRepository.SaveChangesAsync();
                    #endregion
                }
                #endregion

                #region From inventory products
                var fromInventoryProducts = (await DataUnitOfWork.BaseUow.InventoryProductsRepository.GetByInventoryIdAndProductIds(inventoryIntermediate.FromInventoryId, request.IntermediateProducts.Select(x => x.ProductId).ToList())).ToList();
                fromInventoryProducts.ForEach(x => x.Quantity -= request.IntermediateProducts.FirstOrDefault(y => y.ProductId == x.ProductId).Quantity);

                DataUnitOfWork.BaseUow.InventoryProductsRepository.UpdateRange(fromInventoryProducts);
                await DataUnitOfWork.BaseUow.InventoryProductsRepository.SaveChangesAsync();
                #endregion

                DataUnitOfWork.BaseUow.CommitTransaction();
                return Ok(inventoryIntermediate);
            }
            catch (Exception ex)
            {
                DataUnitOfWork.BaseUow.RollbackTransaction();
                return BadRequest();
            }
        }
        #endregion


    }
}
