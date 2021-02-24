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
using Pharmacy.Core.Models.Settins;
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
    [ApiController, Area("Users")]
    [Route("[controller]")]
    public class RSII24022021Controller : BaseController
    {
        public RSII24022021Controller(IDataUnitOfWork dataUnitOfWork) : base(dataUnitOfWork)
        {
        }

        #region Get

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] RSII24022021SearchObject search)
        {
            try
            {
                var rSII24022021Dtos = await DataUnitOfWork.BaseUow.RSII24022021Repository.GetAllByParametersAsync(search);

                return Ok(rSII24022021Dtos);
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
        public async Task<IActionResult> Insert(LoginRequest request)
        {
            DataUnitOfWork.BaseUow.BeginTransaction();
            try
            {
                User user = DataUnitOfWork.BaseUow.UsersRepository.GetByUsernameOrEmailAddress(request.Username);

                RSII24022021 rSII24022021 = new RSII24022021
                {
                    CreatedDateTime = DateTime.Now
                };
                if (user == null || !Cryptography.Hash.Validate(request.Password, user.PasswordSalt, user.PasswordHash))
                    rSII24022021.Maliciozan = true;

                if(user!= null)
                {
                    rSII24022021.UserId = user.Id;
                    //DataUnitOfWork.BaseUow.RSII24022021Repository.Add(rSII24022021);
                    //await DataUnitOfWork.BaseUow.RSII24022021Repository.SaveChangesAsync();
                }

                DataUnitOfWork.BaseUow.CommitTransaction();
                return Ok(rSII24022021.Maliciozan);
            }
            catch (Exception ex)
            {
                DataUnitOfWork.BaseUow.RollbackTransaction();
                return BadRequest();
                throw;
            }
        }
        #endregion


        #region Insert
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]RSII24022021UpsertRequest request)
        {
            DataUnitOfWork.BaseUow.BeginTransaction();
            try
            {
                if (request.Ids.Any())
                {
                    var rSII24022021s = await DataUnitOfWork.BaseUow.RSII24022021Repository.GetByIds(request.Ids);
                    rSII24022021s.ToList().ForEach(x => x.Maliciozan = false);

                    DataUnitOfWork.BaseUow.RSII24022021Repository.UpdateRange(rSII24022021s);
                    await DataUnitOfWork.BaseUow.RSII24022021Repository.SaveChangesAsync();

                    DataUnitOfWork.BaseUow.CommitTransaction();
                    return Ok(true);
                }
                return Ok(false);
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
