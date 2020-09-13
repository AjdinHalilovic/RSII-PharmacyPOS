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
    public class InventoryIntermediateProductsController : BaseController
    {
        public InventoryIntermediateProductsController(IDataUnitOfWork dataUnitOfWork) : base(dataUnitOfWork)
        {
        }

        #region Get

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] InventoryIntermediateProductsSearchObject search)
        {
            try
            {
                search.PharmacyBranchId = ClaimUser.PharmacyBranchId;
                search.FromInventoryId = search.FromInventoryProducts ? ClaimUser.InventoryId : (int?)null;
                search.ToInventoryId = search.ToInventoryProducts ? ClaimUser.InventoryId : (int?)null;
                var inventoryEntries = await DataUnitOfWork.BaseUow.InventoryIntermediateProductsRepository.GetAllDtosByParametersAsync(search);

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
            return Ok(await DataUnitOfWork.BaseUow.InventoryIntermediateProductsRepository.GetByIdAsync(id));
        }
        #endregion




    }
}
