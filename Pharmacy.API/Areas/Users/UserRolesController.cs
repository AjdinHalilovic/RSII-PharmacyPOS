﻿using Microsoft.AspNetCore.Mvc;
using Pharmacy.API.Controllers;
using Pharmacy.API.Filters;
using Pharmacy.Core.Constants.Configurations;
using Pharmacy.Core.Entities.Base;
using Pharmacy.Core.Entities.Base.DTO;
using Pharmacy.Core.Helpers;
using Pharmacy.Core.Helpers.TokenProcessor;
using Pharmacy.Core.Models.Access;
using Pharmacy.Core.Models.Users;
using Pharmacy.Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.API.Areas.Users
{
    [ApiController, TokenValidation, Area("Users")]
    [Route("[controller]")]
    public class UserRolesController : BaseController
    {
        public UserRolesController(IDataUnitOfWork dataUnitOfWork) : base(dataUnitOfWork)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] RolesSearchObject search)
        {
            try
            {
                var roles = await DataUnitOfWork.BaseUow.UserRolesRepository.GetByParametersAsync(search);

                return Ok(roles);
            }
            catch (Exception ex)
            {

                return BadRequest();
                throw;
            }
        }
    }
}
