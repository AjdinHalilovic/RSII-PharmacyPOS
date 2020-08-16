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
    [ApiController,TokenValidation, Area("Settings")]
    [Route("[controller]")]
    public class MeasurementUnitsController : BaseController
    {
        public MeasurementUnitsController(IDataUnitOfWork dataUnitOfWork) : base(dataUnitOfWork)
        {
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var measurementUnits = DataUnitOfWork.BaseUow.MeasurementUnitsRepository.GetAll();

                return Ok(measurementUnits);
            }
            catch (Exception ex)
            {

                return BadRequest();
                throw;
            }
        }
    }
}
