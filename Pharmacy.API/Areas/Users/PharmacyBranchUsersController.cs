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
    public class PharmacyBranchUsersController : BaseController
    {
        public PharmacyBranchUsersController(IDataUnitOfWork dataUnitOfWork) : base(dataUnitOfWork)
        {
        }

        #region Get

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PharmacyBranchUserSearchObject search)
        {
            try
            {
                search.PharmacyId = search.PharmacyId ?? ClaimUser.PharmacyId;

                var pharmacyBranchUsers = (await DataUnitOfWork.BaseUow.PharmacyBranchUsersRepository.GetByParametersAsync(search));

                return Ok(pharmacyBranchUsers);
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
            return Ok(await DataUnitOfWork.BaseUow.PharmacyBranchUsersRepository.GetByIdAsync(id));
        }
        #endregion
    }
}
