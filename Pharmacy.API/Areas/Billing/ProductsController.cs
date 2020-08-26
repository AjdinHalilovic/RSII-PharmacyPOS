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
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.API.Areas.Billing
{
    [ApiController, TokenValidation, Area("Billing")]
    [Route("[controller]")]
    public class ProductsController : BaseController
    {
        public ProductsController(IDataUnitOfWork dataUnitOfWork) : base(dataUnitOfWork)
        {
        }

        #region Get

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ProductSearchObject search)
        {
            try
            {
                search.PharmacyBranchId = ClaimUser.PharmacyBranchId;
                var products = await DataUnitOfWork.BaseUow.ProductsRepository.GetAllDtosByParametersAsync(search);

                return Ok(products);
            }
            catch (Exception ex)
            {

                return BadRequest();
                throw;
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await DataUnitOfWork.BaseUow.ProductsRepository.GetByIdAsync(id));
        }
        #endregion


        #region Insert
        [HttpPost]
        public async Task<IActionResult> Insert(ProductUpsertRequest request)
        {
            DataUnitOfWork.BaseUow.BeginTransaction();
            try
            {
                Product product = request;
                product.PharmacyBranchId = ClaimUser.PharmacyBranchId;
                DataUnitOfWork.BaseUow.ProductsRepository.Add(product);
                await DataUnitOfWork.BaseUow.ProductsRepository.SaveChangesAsync();

                request.ProductAttributes.ForEach(x => x.ProductId = product.Id);
                DataUnitOfWork.BaseUow.ProductAttributesRepository.AddRange(request.ProductAttributes);
                await DataUnitOfWork.BaseUow.ProductAttributesRepository.SaveChangesAsync();

                List<ProductSubstance> productSubstances = request.Substances.Select(x => new ProductSubstance
                {
                    ProductId = product.Id,
                    SubstanceId = x
                }).ToList();
                DataUnitOfWork.BaseUow.ProductSubstancesRepository.AddRange(productSubstances);
                await DataUnitOfWork.BaseUow.ProductSubstancesRepository.SaveChangesAsync();

                List<ProductCategory> productCategories = request.Categories.Select(x => new ProductCategory
                {
                    ProductId = product.Id,
                    CategoryId = x
                }).ToList();
                DataUnitOfWork.BaseUow.ProductCategoriesRepository.AddRange(productCategories);
                await DataUnitOfWork.BaseUow.ProductCategoriesRepository.SaveChangesAsync();

                InventoryProduct inventoryProduct = new InventoryProduct() { InventoryId = ClaimUser.InventoryId, ProductId = product.Id, Quantity = 0 };
                DataUnitOfWork.BaseUow.InventoryProductsRepository.Add(inventoryProduct);
                await DataUnitOfWork.BaseUow.InventoryProductsRepository.SaveChangesAsync();

                DataUnitOfWork.BaseUow.CommitTransaction();
                return Ok(product);
            }
            catch (Exception ex)
            {
                DataUnitOfWork.BaseUow.RollbackTransaction();
                return BadRequest();
                throw;
            }
        }
        #endregion


        #region Update
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductUpsertRequest request)
        {
            try
            {
                #region Product
                Product product = request;
                product.Id = id;
                product.PharmacyBranchId = ClaimUser.PharmacyBranchId; 
                DataUnitOfWork.BaseUow.ProductsRepository.Update(product);
                await DataUnitOfWork.BaseUow.ProductsRepository.SaveChangesAsync();
                #endregion

                #region Categories
                var existingProductCategories = await DataUnitOfWork.BaseUow.ProductCategoriesRepository.GetByParametersAsync(new CategorySearchObject() { ProductId = id });
                var newProductCategories = request.Categories.Where(x => !existingProductCategories.Select(y => y.ProductId).Contains(x))
                    .Select(x => new ProductCategory()
                    {
                        ProductId = id,
                        CategoryId = x
                    });
                var removedProductCategories = existingProductCategories.Where(x => !request.Categories.Contains(x.CategoryId));

                DataUnitOfWork.BaseUow.ProductCategoriesRepository.RemoveRange(removedProductCategories);
                DataUnitOfWork.BaseUow.ProductCategoriesRepository.AddRange(newProductCategories);
                await DataUnitOfWork.BaseUow.ProductCategoriesRepository.SaveChangesAsync();
                #endregion

                #region Categories
                var existingProductSubstances = await DataUnitOfWork.BaseUow.ProductSubstancesRepository.GetByParametersAsync(new SubstanceSearchObject() { ProductId = id });
                var newProductSubstances = request.Substances.Where(x => !existingProductSubstances.Select(y => y.ProductId).Contains(x))
                    .Select(x => new ProductSubstance()
                    {
                        ProductId = id,
                        SubstanceId = x
                    });
                var removedProductSubstances = existingProductSubstances.Where(x => !request.Substances.Contains(x.SubstanceId));

                DataUnitOfWork.BaseUow.ProductSubstancesRepository.RemoveRange(removedProductSubstances);
                DataUnitOfWork.BaseUow.ProductSubstancesRepository.AddRange(newProductSubstances);
                await DataUnitOfWork.BaseUow.ProductSubstancesRepository.SaveChangesAsync();
                #endregion

                #region Attributes
                var existingProductAttributes = (await DataUnitOfWork.BaseUow.ProductAttributesRepository.GetByParametersAsync(new AttributeSearchObject() { ProductId = id })).ToList();
                var removedProductAttributes = existingProductAttributes.Where(x =>
                    !request.ProductAttributes.Select(y => y.AttributeOptionId).Contains(x.AttributeOptionId)
                || !request.ProductAttributes.Select(x => x.AttributeId).Contains(x.AttributeId)).ToList();
                var newProductAttributes = request.ProductAttributes.Where(x => x.Id == 0 && !existingProductAttributes.Select(y => y.AttributeOptionId).Contains(x.AttributeOptionId)).ToList();
                newProductAttributes.ForEach(x => x.ProductId = product.Id);

                DataUnitOfWork.BaseUow.ProductAttributesRepository.AddRange(newProductAttributes);
                DataUnitOfWork.BaseUow.ProductAttributesRepository.RemoveRangeByIds(removedProductAttributes.Select(x => x.Id).ToArray());
                await DataUnitOfWork.BaseUow.ProductAttributesRepository.SaveChangesAsync();
                #endregion

                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest();
                throw;
            }
        }
        #endregion

        #region Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                DataUnitOfWork.BaseUow.ProductsRepository.RemoveById(id);
                await DataUnitOfWork.BaseUow.ProductsRepository.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
                throw;
            }
        }
        #endregion
    }
}
