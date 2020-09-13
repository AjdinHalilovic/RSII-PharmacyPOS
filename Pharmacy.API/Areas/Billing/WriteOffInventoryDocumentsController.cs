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
    public class WriteOffInventoryDocumentsController : BaseController
    {
        public WriteOffInventoryDocumentsController(IDataUnitOfWork dataUnitOfWork) : base(dataUnitOfWork)
        {
        }

        #region Get

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] BaseSearchObject search)
        {
            try
            {
                search.PharmacyBranchId = ClaimUser.PharmacyBranchId;
                var inventoryEntries = await DataUnitOfWork.BaseUow.WriteOffInventoryDocumentsRepository.GetAllDtosByParametersAsync(search);

                return Ok(inventoryEntries);
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
            return Ok(await DataUnitOfWork.BaseUow.WriteOffInventoryDocumentsRepository.GetByIdAsync(id));
        }
        #endregion


        #region Insert
        [HttpPost]
        public async Task<IActionResult> Insert(InventoryWriteOffUpsertRequest request)
        {
            DataUnitOfWork.BaseUow.BeginTransaction();
            try
            {
                var inventoryProduct = (await DataUnitOfWork.BaseUow.InventoryProductsRepository.GetByInventoryIdAndProductIds(ClaimUser.InventoryId, new List<int>() { request.ProductId })).FirstOrDefault();
                inventoryProduct.Quantity -= request.Quantity;
                DataUnitOfWork.BaseUow.InventoryProductsRepository.Update(inventoryProduct);
                await DataUnitOfWork.BaseUow.InventoryProductsRepository.SaveChangesAsync();

                WriteOffInventoryDocument writeOffInventoryDocument = request;
                writeOffInventoryDocument.UserId = ClaimUser.UserId;
                writeOffInventoryDocument.InventoryProductId = inventoryProduct.Id;

                DataUnitOfWork.BaseUow.WriteOffInventoryDocumentsRepository.Add(writeOffInventoryDocument);
                await DataUnitOfWork.BaseUow.WriteOffInventoryDocumentsRepository.SaveChangesAsync();

                DataUnitOfWork.BaseUow.CommitTransaction();
                return Ok(writeOffInventoryDocument);
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
