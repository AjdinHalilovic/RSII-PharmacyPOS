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

namespace Pharmacy.API.Areas.Access
{
    [ApiController]
    public class RegistrationController : BaseController
    {
        public RegistrationController(IDataUnitOfWork dataUnitOfWork) : base(dataUnitOfWork)
        {
        }

        [HttpPost, Route("Register/Pharmacy")]
        public async Task<IActionResult> Register([FromBody] PharmacyRegisterRequest model)
        {
            DataUnitOfWork.BaseUow.BeginTransaction();
            try
            {
                if (ModelState.IsValid)
                {
                    #region User data
                    Person person = new Person
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                    };
                    DataUnitOfWork.BaseUow.PersonsRepository.Add(person);
                    await DataUnitOfWork.BaseUow.PersonsRepository.SaveChangesAsync();

                    var passwordSalt = Cryptography.Salt.Create();
                    var passwordHash = Cryptography.Hash.Create(model.Password, passwordSalt);

                    User user = new User()
                    {
                        Id = person.Id,
                        Username = model.Username,
                        Email = model.Email,
                        CreatedDate = DateTime.Now,
                        PasswordSalt = passwordSalt,
                        PasswordHash = passwordHash
                    };
                    DataUnitOfWork.BaseUow.UsersRepository.Add(user);
                    await DataUnitOfWork.BaseUow.UsersRepository.SaveChangesAsync();
                    #endregion

                    #region Pharmacy data
                    Pharmacy.Core.Entities.Base.Pharmacy pharmacy = null;
                    var existingPharmacy = DataUnitOfWork.BaseUow.PharmaciesRepository.GetByUniqueIdentifier(model.PharmacyUniqueIdentifier);
                    if (existingPharmacy == null)
                    {
                        pharmacy = new Pharmacy.Core.Entities.Base.Pharmacy()
                        {
                            Name = model.PharmacyName,
                            PharmacyUniqueIdentifier = model.PharmacyUniqueIdentifier,
                            OwnerUserId = user.Id
                        };
                        DataUnitOfWork.BaseUow.PharmaciesRepository.Add(pharmacy);
                        await DataUnitOfWork.BaseUow.PharmaciesRepository.SaveChangesAsync();
                    }

                    PharmacyBranch pharmacyBranch = new PharmacyBranch()
                    {
                        PharmacyId = existingPharmacy?.Id ?? pharmacy.Id,
                        BranchIdentifier = model.BranchIdentifier,
                        CountryId = model.CountryId.GetValueOrDefault(),
                        CityId = model.CityId.GetValueOrDefault(),
                        Address = model.Address,
                        Central = model.CentralBranch
                    };
                    DataUnitOfWork.BaseUow.PharmacyBranchesRepository.Add(pharmacyBranch);
                    await DataUnitOfWork.BaseUow.PharmacyBranchesRepository.SaveChangesAsync();

                    PharmacyBranchUser pharmacyBranchUser = new PharmacyBranchUser()
                    {
                        PharmacyBranchId = pharmacyBranch.Id,
                        UserId = user.Id,
                        StartDateTime = DateTime.Now
                    };
                    DataUnitOfWork.BaseUow.PharmacyBranchUsersRepository.Add(pharmacyBranchUser);
                    await DataUnitOfWork.BaseUow.PharmacyBranchUsersRepository.SaveChangesAsync();

                    #endregion
                    DataUnitOfWork.BaseUow.CommitTransaction();

                    return Ok(model);
                }
                else
                {
                    return BadRequest(model);
                }
            }
            catch (Exception ex)
            {
                DataUnitOfWork.BaseUow.RollbackTransaction();
                return BadRequest(model);

                throw;
            }

        }
    }
}
