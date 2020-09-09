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
using Pharmacy.Core.Models.Settings;
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
    public class SubstancesController : BaseController
    {
        public SubstancesController(IDataUnitOfWork dataUnitOfWork) : base(dataUnitOfWork)
        {
        }
        #region Get

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SubstanceSearchObject search)
        {
            try
            {
                search.PharmacyBranchId = ClaimUser.PharmacyBranchId;
                var substances = await DataUnitOfWork.BaseUow.SubstancesRepository.GetAllByParametersAsync(search);

                return Ok(substances);
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
            return Ok(await DataUnitOfWork.BaseUow.SubstancesRepository.GetByIdAsync(id));
        }
        #endregion

        #region Insert
        [HttpPost]
        public async Task<IActionResult> Insert(SubstanceUpsertRequest request)
        {
            DataUnitOfWork.BaseUow.BeginTransaction();
            try
            {
                var substance = new Substance()
                {
                    Name = request.Name,
                    PharmacyBranchId = ClaimUser.PharmacyBranchId
                };
                DataUnitOfWork.BaseUow.SubstancesRepository.Add(substance);
                await DataUnitOfWork.BaseUow.SubstancesRepository.SaveChangesAsync();

                List<ProhibitedSubstance> prohibitedSubstance = request.Substances.Select(x => new ProhibitedSubstance
                {
                    SubstanceId = substance.Id,
                    ProhibitedSubstanceId = x
                }).ToList();
                DataUnitOfWork.BaseUow.ProhibitedSubstancesRepository.AddRange(prohibitedSubstance);
                await DataUnitOfWork.BaseUow.ProhibitedSubstancesRepository.SaveChangesAsync();

                DataUnitOfWork.BaseUow.CommitTransaction();
                return Ok(substance);
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
        public async Task<IActionResult> Update(int id, [FromBody] SubstanceUpsertRequest request)
        {
            DataUnitOfWork.BaseUow.BeginTransaction();
            try
            {
                var substance = await DataUnitOfWork.BaseUow.SubstancesRepository.GetByIdAsync(id);
                substance.Name = request.Name;
                substance.PharmacyBranchId = ClaimUser.PharmacyBranchId;

                DataUnitOfWork.BaseUow.SubstancesRepository.Update(substance);
                await DataUnitOfWork.BaseUow.SubstancesRepository.SaveChangesAsync();


                var existingProhibitedSubstances = await DataUnitOfWork.BaseUow.ProhibitedSubstancesRepository.GetByParametersAsync(new ProhibitedSubstanceSearchObject() { SubstanceId = id });
                var newProhibitedSubstances = request.Substances.Where(x => !existingProhibitedSubstances.Select(y => y.SubstanceId).Contains(x))
                    .Select(x => new ProhibitedSubstance()
                    {
                        SubstanceId = id,
                        ProhibitedSubstanceId = x
                    });
                var removedProhibitedSubstances = existingProhibitedSubstances.Where(x => !request.Substances.Contains(x.SubstanceId));

                DataUnitOfWork.BaseUow.ProhibitedSubstancesRepository.RemoveRange(removedProhibitedSubstances);
                DataUnitOfWork.BaseUow.ProhibitedSubstancesRepository.AddRange(newProhibitedSubstances);
                await DataUnitOfWork.BaseUow.ProhibitedSubstancesRepository.SaveChangesAsync();

                DataUnitOfWork.BaseUow.CommitTransaction();
                return Ok(substance);
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
