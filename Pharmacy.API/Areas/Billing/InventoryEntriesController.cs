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
    public class InventoryEntriesController : BaseController
    {
        public InventoryEntriesController(IDataUnitOfWork dataUnitOfWork) : base(dataUnitOfWork)
        {
        }

        #region Get

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] BaseSearchObject search)
        {
            try
            {
                search.PharmacyBranchId = ClaimUser.PharmacyBranchId;
                var inventoryEntries = await DataUnitOfWork.BaseUow.InventoryEntriesRepository.GetAllDtosByParametersAsync(search);

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
            return Ok(await DataUnitOfWork.BaseUow.InventoryEntriesRepository.GetByIdAsync(id));
        }
        #endregion


        #region Insert
        [HttpPost]
        public async Task<IActionResult> Insert(InventoryEntryUpsertRequest request)
        {
            DataUnitOfWork.BaseUow.BeginTransaction();
            try
            {
                InventoryEntry inventoryEntry = request;
                inventoryEntry.InventoryId = ClaimUser.InventoryId;
                inventoryEntry.UserId = ClaimUser.UserId;

                DataUnitOfWork.BaseUow.InventoryEntriesRepository.Add(inventoryEntry);
                await DataUnitOfWork.BaseUow.InventoryEntriesRepository.SaveChangesAsync();

                request.EntryProducts.ForEach(x => x.InventoryEntryId = inventoryEntry.Id);
                DataUnitOfWork.BaseUow.InventoryEntryProductsRepository.AddRange(request.EntryProducts);
                await DataUnitOfWork.BaseUow.InventoryEntryProductsRepository.SaveChangesAsync();

                var inventoryProducts = (await DataUnitOfWork.BaseUow.InventoryProductsRepository.GetByInventoryIdAndProductIds(inventoryEntry.InventoryId, request.EntryProducts.Select(x => x.ProductId).ToList())).ToList();
                inventoryProducts.ForEach(x => x.Quantity += request.EntryProducts.FirstOrDefault(y => y.ProductId == x.ProductId).Quantity);
                DataUnitOfWork.BaseUow.InventoryProductsRepository.UpdateRange(inventoryProducts);
                await DataUnitOfWork.BaseUow.InventoryProductsRepository.SaveChangesAsync();

                DataUnitOfWork.BaseUow.CommitTransaction();
                return Ok(inventoryEntry);
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
