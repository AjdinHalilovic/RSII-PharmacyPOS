using Microsoft.AspNetCore.Mvc;
using Pharmacy.API.Controllers;
using Pharmacy.API.Filters;
using Pharmacy.Core.Constants.Configurations;
using Pharmacy.Core.Entities.Base;
using Pharmacy.Core.Entities.Base.DTO;
using Pharmacy.Core.Helpers;
using Pharmacy.Core.Helpers.TokenProcessor;
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
    public class ProductSubstancesController : BaseController
    {
        public ProductSubstancesController(IDataUnitOfWork dataUnitOfWork) : base(dataUnitOfWork)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SubstanceSearchObject search)
        {
            try
            {
                var roles = await DataUnitOfWork.BaseUow.ProductSubstancesRepository.GetByParametersAsync(search);

                return Ok(roles);
            }
            catch (Exception ex)
            {

                return BadRequest();
                throw;
            }
        }

        [HttpGet,Route("CheckProhibitedSubstances")]
        public async Task<IActionResult> CheckProhibitedSubstances([FromQuery] ProductSubstanceSearchObject search)
        {
            try
            {
                if(search.ProhibitedProductIds == null)
                {
                    return Ok(false);
                }
                var prohibited = await DataUnitOfWork.BaseUow.ProductSubstancesRepository.CheckProhibitedSubstances(search);

                return Ok(prohibited);
            }
            catch (Exception ex)
            {

                return BadRequest();
                throw;
            }
        }
    }
}
