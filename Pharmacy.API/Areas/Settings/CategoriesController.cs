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
    [ApiController, TokenValidation, Area("Settings")]
    [Route("[controller]")]
    public class CategoriesController : BaseController
    {
        public CategoriesController(IDataUnitOfWork dataUnitOfWork) : base(dataUnitOfWork)
        {
        }

        #region Get

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] CategorySearchObject search)
        {
            try
            {
                search.PharmacyBranchId = ClaimUser.PharmacyBranchId;
                var categories = await DataUnitOfWork.BaseUow.CategoriesRepository.GetAllByParametersAsync(search);

                return Ok(categories);
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
            return Ok(await DataUnitOfWork.BaseUow.CategoriesRepository.GetByIdAsync(id));
        }
        #endregion

        #region Insert
        [HttpPost]
        public async Task<IActionResult> Insert(BaseInsertRequest request)
        {
            try
            {
                Category category = new Category()
                {
                    Name = request.Name,
                    PharmacyBranchId = ClaimUser.PharmacyBranchId
                };
                DataUnitOfWork.BaseUow.CategoriesRepository.Add(category);
                await DataUnitOfWork.BaseUow.CategoriesRepository.SaveChangesAsync();

                return Ok(category);
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
        public async Task<IActionResult> Update(int id,BaseInsertRequest request)
        {
            try
            {
                var category = await DataUnitOfWork.BaseUow.CategoriesRepository.GetByIdAsync(id);
                category.Name = request.Name;
                category.PharmacyBranchId = ClaimUser.PharmacyBranchId;

                DataUnitOfWork.BaseUow.CategoriesRepository.Update(category);
                await DataUnitOfWork.BaseUow.CategoriesRepository.SaveChangesAsync();

                return Ok(category);
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
