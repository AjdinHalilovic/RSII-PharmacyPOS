using Microsoft.AspNetCore.Mvc;
using Namotion.Reflection;
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
    public class BillsController : BaseController
    {
        public BillsController(IDataUnitOfWork dataUnitOfWork) : base(dataUnitOfWork)
        {

        }
        #region Get

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] BillSearchObject search)
        {
            try
            {
                search.PharmacyBranchId = search.IncludeBranchFiltering ? search.PharmacyBranchId : ClaimUser.PharmacyBranchId;
                search.PharmacyId = ClaimUser.PharmacyId;
                var bills = await DataUnitOfWork.BaseUow.BillsRepository.GetAllDtosByParametersAsync(search);

                return Ok(bills);
            }
            catch (Exception ex)
            {

                return BadRequest();
                throw;
            }
        }
        #endregion

        #region Insert
        [HttpPost]
        public async Task<IActionResult> Insert(BillUpsertRequest request)
        {
            DataUnitOfWork.BaseUow.BeginTransaction();
            try
            {
                var lastBill =  await DataUnitOfWork.BaseUow.BillsRepository.GetLastBill(ClaimUser.PharmacyBranchId);
                Bill bill = new Bill()
                {
                    CreatedDateTime = DateTime.Now,
                    Number = lastBill != null ? lastBill.Number + 1 : 0,
                    PharmacyBranchId = ClaimUser.PharmacyBranchId,
                    Total = request.BillItems.Sum(x=> x.Quantity * x.UnitPrice),
                    AddUserId = ClaimUser.UserId
                };
                DataUnitOfWork.BaseUow.BillsRepository.Add(bill);
                await DataUnitOfWork.BaseUow.BillsRepository.SaveChangesAsync();

                request.BillItems.ForEach(x => { x.BillId = bill.Id; x.Total = x.Quantity * x.UnitPrice; });
                DataUnitOfWork.BaseUow.BillItemsRepository.AddRange(request.BillItems);
                await DataUnitOfWork.BaseUow.BillItemsRepository.SaveChangesAsync();

                var inventoryProducts = await DataUnitOfWork.BaseUow.InventoryProductsRepository.GetByInventoryIdAndProductIds(ClaimUser.InventoryId, request.BillItems.Select(x => x.ProductId).ToList());
                inventoryProducts.ToList().ForEach(x => x.Quantity -= request.BillItems.FirstOrDefault(y => y.ProductId == x.ProductId).Quantity);
                DataUnitOfWork.BaseUow.InventoryProductsRepository.UpdateRange(inventoryProducts);
                await DataUnitOfWork.BaseUow.InventoryProductsRepository.SaveChangesAsync();

                DataUnitOfWork.BaseUow.CommitTransaction();
                return Ok(bill);
            }
            catch (Exception ex)
            {
                DataUnitOfWork.BaseUow.RollbackTransaction();
                return BadRequest();
                throw;
            }
        }
        #endregion


        
    }
}
