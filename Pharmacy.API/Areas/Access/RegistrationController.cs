using Microsoft.AspNetCore.Mvc;
using Pharmacy.API.Controllers;
using Pharmacy.API.Filters;
using Pharmacy.Core.Constants;
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
                    var existingPharmacy = await DataUnitOfWork.BaseUow.PharmaciesRepository.GetByUniqueIdentifier(model.PharmacyUniqueIdentifier);
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
                        Central = existingPharmacy == null ? model.CentralBranch : false
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

                    Inventory inventory = new Inventory() { PharmacyBranchId = pharmacyBranch.Id };
                    DataUnitOfWork.BaseUow.InventoriesRepository.Add(inventory);
                    await DataUnitOfWork.BaseUow.InventoriesRepository.SaveChangesAsync();

                    UserRole userRole = new UserRole()
                    {
                        PharmacyBranchId = pharmacyBranch.Id,
                        PharmacyId = existingPharmacy?.Id ?? pharmacy.Id,
                        RoleId = existingPharmacy == null ? (int)Enumerations.WebRole.SuperAdministrator : (int)Enumerations.WebRole.Administrator,
                        UserId = user.Id
                    };
                    DataUnitOfWork.BaseUow.UserRolesRepository.Add(userRole);
                    await DataUnitOfWork.BaseUow.UserRolesRepository.SaveChangesAsync();

                    if (existingPharmacy != null && model.UseCentralBranchData)
                    {
                        var centralBranch = DataUnitOfWork.BaseUow.PharmacyBranchesRepository.GetCentralBranch(existingPharmacy.Id);

                        var prohibitetSubstances = DataUnitOfWork.BaseUow.ProhibitedSubstancesRepository.GetByPharmacyBranchId(centralBranch.Id);
                        var centralSubstances = prohibitetSubstances.Select(x => x.Substance).ToList();
                        centralSubstances.AddRange(DataUnitOfWork.BaseUow.SubstancesRepository.GetByPharmacyBranchId(centralBranch.Id).Where(x => !centralSubstances.Select(y => y.Id).Contains(x.Id)));

                        var substances = centralSubstances;
                        substances.ForEach(x => x.Id = 0);
                        substances.ForEach(x => x.PharmacyBranchId = pharmacyBranch.Id);

                        DataUnitOfWork.BaseUow.SubstancesRepository.AddRange(substances);
                        DataUnitOfWork.BaseUow.SubstancesRepository.SaveChanges();

                        prohibitetSubstances.ToList().ForEach(x =>
                        {
                            x.SubstanceId = substances.FirstOrDefault(x => x.Name.Equals(centralSubstances.FirstOrDefault(y => y.Id == x.Id).Name)).Id;
                            x.ProhibitedSubstanceId = substances.FirstOrDefault(x => x.Name.Equals(centralSubstances.FirstOrDefault(y => y.Id == x.Id).Name)).Id;
                            x.Id = 0;
                        });
                        DataUnitOfWork.BaseUow.ProhibitedSubstancesRepository.AddRange(prohibitetSubstances);
                        DataUnitOfWork.BaseUow.ProhibitedSubstancesRepository.SaveChanges();

                        var productSubstances = DataUnitOfWork.BaseUow.ProductSubstancesRepository.GetByPharmacyBranchId(centralBranch.Id);
                        var centralProducts = productSubstances.Select(x => x.Product).ToList();
                        var products = centralProducts;

                        products.ToList().ForEach(x => { x.PharmacyBranchId = pharmacyBranch.Id; x.Id = 0; });
                        DataUnitOfWork.BaseUow.ProductsRepository.AddRange(products);
                        DataUnitOfWork.BaseUow.ProductsRepository.SaveChanges();

                        productSubstances.ToList().ForEach(x => { x.Id = 0; x.ProductId = products.FirstOrDefault(y => y.Name.Equals(centralProducts.FirstOrDefault(z => z.Id == y.Id).Name)).Id; });
                        DataUnitOfWork.BaseUow.ProductSubstancesRepository.AddRange(productSubstances);
                        DataUnitOfWork.BaseUow.ProductSubstancesRepository.SaveChanges();

                        var productCategories = DataUnitOfWork.BaseUow.ProductCategoriesRepository.GetByPharmacyBranchId(centralBranch.Id);
                        productCategories.ToList().ForEach(x => { x.Id = 0; x.ProductId = products.FirstOrDefault(y => y.Name.Equals(centralProducts.FirstOrDefault(z => z.Id == y.Id).Name)).Id; });
                        DataUnitOfWork.BaseUow.ProductCategoriesRepository.AddRange(productCategories);
                        DataUnitOfWork.BaseUow.ProductCategoriesRepository.SaveChanges();

                        var inventoryProducts = DataUnitOfWork.BaseUow.InventoryProductsRepository.GetByPharmacyBranchId(centralBranch.Id);
                        inventoryProducts.ToList().ForEach(x =>
                        {
                            x.InventoryId = inventory.Id;
                            x.Id = 0;
                            x.Quantity = 0;
                            x.ProductId = products.FirstOrDefault(y => y.Name.Equals(centralProducts.FirstOrDefault(z => z.Id == y.Id).Name)).Id;
                        });
                        DataUnitOfWork.BaseUow.InventoryProductsRepository.AddRange(inventoryProducts);
                        DataUnitOfWork.BaseUow.InventoryProductsRepository.SaveChanges();

                        var centralAttributeOptions = DataUnitOfWork.BaseUow.AttributeOptionsRepository.GetByPharmacyBranchId(centralBranch.Id).ToList();
                        var centralAttributes = centralAttributeOptions.Select(x => x.Attribute).Distinct().ToList();
                        var attributes = centralAttributes;

                        attributes.ForEach(x => { x.Id = 0; x.PharmacyBranchId = pharmacyBranch.Id; });
                        DataUnitOfWork.BaseUow.AttributesRepository.AddRange(attributes);
                        DataUnitOfWork.BaseUow.AttributesRepository.SaveChanges();

                        var attributeOptions = centralAttributeOptions;
                        attributeOptions.ToList().ForEach(x =>
                        {
                            x.Id = 0;
                            x.AttributeId = attributes.FirstOrDefault(y => y.Name.Equals(centralAttributes.FirstOrDefault(z => z.Id == y.Id).Name)).Id;
                        });
                        DataUnitOfWork.BaseUow.AttributeOptionsRepository.AddRange(attributeOptions);
                        DataUnitOfWork.BaseUow.AttributeOptionsRepository.SaveChanges();

                        var productAttributes = DataUnitOfWork.BaseUow.ProductAttributesRepository.GetByPharmacyBranchId(centralBranch.Id);
                        productAttributes.ToList().ForEach(x =>
                        {
                            x.Id = 0;
                            x.AttributeId = attributes.FirstOrDefault(y => y.Name.Equals(centralAttributes.FirstOrDefault(z => z.Id == y.Id).Name)).Id;
                            x.ProductId = products.FirstOrDefault(y => y.Name.Equals(centralProducts.FirstOrDefault(z => z.Id == y.Id).Name)).Id;
                            x.AttributeOptionId = attributeOptions.FirstOrDefault(y => y.Value.Equals(centralAttributeOptions.FirstOrDefault(z => z.Id == y.Id).Value)).Id;
                        });
                        DataUnitOfWork.BaseUow.ProductAttributesRepository.AddRange(productAttributes);
                        DataUnitOfWork.BaseUow.ProductAttributesRepository.SaveChanges();

                    }

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
