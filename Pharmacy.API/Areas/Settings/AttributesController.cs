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
    public class AttributesController : BaseController
    {
        public AttributesController(IDataUnitOfWork dataUnitOfWork) : base(dataUnitOfWork)
        {
        }

        #region Get

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] BaseSearchObject search)
        {
            try
            {
                search.PharmacyBranchId = ClaimUser.PharmacyBranchId;
                var attributes = await DataUnitOfWork.BaseUow.AttributesRepository.GetAllByParametersAsync(search);

                return Ok(attributes);
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
            return Ok(await DataUnitOfWork.BaseUow.AttributesRepository.GetByIdAsync(id));
        }
        #endregion

        #region Insert
        [HttpPost]
        public async Task<IActionResult> Insert(AttributeUpsertRequest request)
        {
            DataUnitOfWork.BaseUow.BeginTransaction();
            try
            {
                var attribute = new Pharmacy.Core.Entities.Base.Attribute()
                {
                    Name = request.Name,
                    PharmacyBranchId = ClaimUser.PharmacyBranchId
                };
                DataUnitOfWork.BaseUow.AttributesRepository.Add(attribute);
                await DataUnitOfWork.BaseUow.AttributesRepository.SaveChangesAsync();

                request.AttributeOptions.ForEach(x => x.AttributeId = attribute.Id);
                DataUnitOfWork.BaseUow.AttributeOptionsRepository.AddRange(request.AttributeOptions);
                await DataUnitOfWork.BaseUow.AttributeOptionsRepository.SaveChangesAsync();

                DataUnitOfWork.BaseUow.CommitTransaction();

                return Ok(attribute);
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
        public async Task<IActionResult> Update(int id,[FromBody] AttributeUpsertRequest request)
        {
            DataUnitOfWork.BaseUow.BeginTransaction();
            try
            {
                var attribute = await DataUnitOfWork.BaseUow.AttributesRepository.GetByIdAsync(id);
                attribute.Name = request.Name;
                attribute.PharmacyBranchId = ClaimUser.PharmacyBranchId;

                DataUnitOfWork.BaseUow.AttributesRepository.Update(attribute);
                await DataUnitOfWork.BaseUow.AttributesRepository.SaveChangesAsync();

                #region Options
                var existingAttributeOptions = (await DataUnitOfWork.BaseUow.AttributeOptionsRepository.GetAllByParametersAsync(new AttributeOptionSearchObject() { AttributeId = id })).ToList();
                var removedAttributeOptions = existingAttributeOptions.Where(x =>
                    !request.AttributeOptions.Select(y => y.Value).Contains(x.Value)).ToList();
                var newAttributeOptions = request.AttributeOptions.Where(x => x.Id == 0 && !existingAttributeOptions.Select(y => y.Value).Contains(x.Value)).ToList();
                newAttributeOptions.ForEach(x => x.AttributeId = attribute.Id);

                DataUnitOfWork.BaseUow.AttributeOptionsRepository.AddRange(newAttributeOptions);
                DataUnitOfWork.BaseUow.AttributeOptionsRepository.RemoveRangeByIds(removedAttributeOptions.Select(x => x.Id).ToArray());
                await DataUnitOfWork.BaseUow.AttributeOptionsRepository.SaveChangesAsync();
                #endregion

                DataUnitOfWork.BaseUow.CommitTransaction();
                return Ok(attribute);
            }
            catch (Exception ex)
            {
                DataUnitOfWork.BaseUow.RollbackTransaction();
                return BadRequest();
                throw;
            }
        }
        #endregion

        #region Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                DataUnitOfWork.BaseUow.AttributesRepository.RemoveById(id);
                await DataUnitOfWork.BaseUow.AttributesRepository.SaveChangesAsync();
                return Ok();
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
