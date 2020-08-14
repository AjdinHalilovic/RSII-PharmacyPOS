using Microsoft.AspNetCore.Mvc;
using Pharmacy.API.Controllers;
using Pharmacy.API.Filters;
using Pharmacy.Core.Constants.Configurations;
using Pharmacy.Core.Entities.Base;
using Pharmacy.Core.Entities.Base.DTO;
using Pharmacy.Core.Helpers;
using Pharmacy.Core.Helpers.TokenProcessor;
using Pharmacy.Core.Models.Access;
using Pharmacy.Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.API.Areas.Settings
{
    [ApiController, Area("Settings")]
    [Route("[controller]")]
    public class CitiesController : BaseController
    {
        public CitiesController(IDataUnitOfWork dataUnitOfWork) : base(dataUnitOfWork)
        {
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var cities = DataUnitOfWork.BaseUow.CitiesRepository.GetAll();

                return Ok(cities);
            }
            catch (Exception ex)
            {

                return BadRequest();
                throw;
            }
        }
    }
}
