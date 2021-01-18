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
    public class BillItemsController : BaseController
    {
        public BillItemsController(IDataUnitOfWork dataUnitOfWork) : base(dataUnitOfWork)
        {
        }

        #region Get

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] BillItemSearchObject search)
        {
            try
            {
                search.PharmacyBranchId = search.IncludeBranchFiltering ? search.PharmacyBranchId: ClaimUser.PharmacyBranchId;
                var billItems = await DataUnitOfWork.BaseUow.BillItemsRepository.GetAllDtosByParametersAsync(search);

                return Ok(billItems);
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
