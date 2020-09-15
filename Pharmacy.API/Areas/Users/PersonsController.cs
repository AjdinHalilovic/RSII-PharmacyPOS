using Microsoft.AspNetCore.Mvc;
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
    public class PersonsController : BaseController
    {
        public PersonsController(IDataUnitOfWork dataUnitOfWork) : base(dataUnitOfWork)
        {
        }

        #region Get

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PersonSearchObject search)
        {
            try
            {
                if(search == null)
                {
                    search = new PersonSearchObject();
                }
                search.PharmacyBranchId = ClaimUser.PharmacyBranchId;
                var persons = await DataUnitOfWork.BaseUow.PersonsRepository.GetAllDtosAsync(search);

                return Ok(persons);
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
            return Ok(await DataUnitOfWork.BaseUow.PersonsRepository.GetByIdAsync(id));
        }
        #endregion

        #region Insert
        [HttpPost]
        public async Task<IActionResult> Insert(UserUpsertRequest request)
        {
            DataUnitOfWork.BaseUow.BeginTransaction();
            try
            {
                Person person = request;
                DataUnitOfWork.BaseUow.PersonsRepository.Add(person);
                await DataUnitOfWork.BaseUow.PersonsRepository.SaveChangesAsync();

                User user = request;
                user.Id = person.Id;
                DataUnitOfWork.BaseUow.UsersRepository.Add(user);
                await DataUnitOfWork.BaseUow.UsersRepository.SaveChangesAsync();

                List<UserRole> userRoles = request.Roles.Select(x => new UserRole()
                {
                    PharmacyBranchId = ClaimUser.PharmacyBranchId,
                    PharmacyId = ClaimUser.PharmacyId,
                    UserId = user.Id,
                    RoleId = x
                }).ToList();
                DataUnitOfWork.BaseUow.UserRolesRepository.AddRange(userRoles);
                await DataUnitOfWork.BaseUow.UserRolesRepository.SaveChangesAsync();

                PharmacyBranchUser pharmacyBranchUser = new PharmacyBranchUser()
                {
                    PharmacyBranchId = ClaimUser.PharmacyBranchId,
                    UserId = user.Id,
                    StartDateTime = DateTime.Now
                };
                DataUnitOfWork.BaseUow.PharmacyBranchUsersRepository.Add(pharmacyBranchUser);
                await DataUnitOfWork.BaseUow.PharmacyBranchUsersRepository.SaveChangesAsync();

                DataUnitOfWork.BaseUow.CommitTransaction();
                return Ok(person);
            }
            catch (Exception ex)
            {
                DataUnitOfWork.BaseUow.RollbackTransaction();
                return BadRequest();
                throw;
            }
        }
        #endregion


        #region Update
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]UserUpsertRequest request)
        {
            try
            {
                #region User
                Person person = request;
                person.Id = id;
                DataUnitOfWork.BaseUow.PersonsRepository.Update(person);
                await DataUnitOfWork.BaseUow.PersonsRepository.SaveChangesAsync();

                User userEntity = await DataUnitOfWork.BaseUow.UsersRepository.GetByIdAsync(id);
                User user = request;
                user.Id = id;
                user.AccessToken = userEntity.AccessToken;
                user.CreatedDate = userEntity.CreatedDate;
                user.CreatedTokenDateTime = userEntity.CreatedTokenDateTime;
                user.RefreshToken = userEntity.RefreshToken;
                user.RefreshTokenExpirationDateTime = userEntity.RefreshTokenExpirationDateTime;
                user.TokenExpirationDateTime = userEntity.TokenExpirationDateTime;
                user.UpdateDateTime = DateTime.Now;
                DataUnitOfWork.BaseUow.UsersRepository.Update(user);
                await DataUnitOfWork.BaseUow.UsersRepository.SaveChangesAsync();
                #endregion

                #region Roles
                var existingUserRoles = await DataUnitOfWork.BaseUow.UserRolesRepository.GetByParametersAsync(new RolesSearchObject() { UserId = user.Id });
                var newUserRoles = request.Roles.Where(x => !existingUserRoles.Select(y => y.RoleId).Contains(x))
                    .Select(x => new UserRole()
                    {
                        PharmacyBranchId = ClaimUser.PharmacyBranchId,
                        PharmacyId = ClaimUser.PharmacyId,
                        RoleId = x,
                        UserId = user.Id
                    });
                var removedUserRoles = existingUserRoles.Where(x => !request.Roles.Contains(x.RoleId));

                DataUnitOfWork.BaseUow.UserRolesRepository.RemoveRange(removedUserRoles);
                DataUnitOfWork.BaseUow.UserRolesRepository.AddRange(newUserRoles);
                await DataUnitOfWork.BaseUow.UserRolesRepository.SaveChangesAsync();
                #endregion
                return Ok(person);
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
