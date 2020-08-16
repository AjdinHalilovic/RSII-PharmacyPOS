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
        public async Task<IActionResult> Insert(BaseInsertRequest request)
        {
            try
            {
                var attribute = new Pharmacy.Core.Entities.Base.Attribute()
                {
                    Name = request.Name,
                    PharmacyBranchId = 2 //modify from claims
                };
                DataUnitOfWork.BaseUow.AttributesRepository.Add(attribute);
                await DataUnitOfWork.BaseUow.AttributesRepository.SaveChangesAsync();

                return Ok(attribute);
            }
            catch (Exception ex)
            {
                return BadRequest();
                throw;
            }
        }
        #endregion


        #region Update
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,[FromBody] BaseInsertRequest request)
        {
            try
            {
                var attribute = await DataUnitOfWork.BaseUow.AttributesRepository.GetByIdAsync(id);
                attribute.Name = request.Name;

                DataUnitOfWork.BaseUow.AttributesRepository.Update(attribute);
                await DataUnitOfWork.BaseUow.AttributesRepository.SaveChangesAsync();

                return Ok(attribute);
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
