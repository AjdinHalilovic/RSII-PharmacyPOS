﻿using System.Linq;
using System.Threading.Tasks;
using Pharmacy.Core.Entities.Base;
using Pharmacy.Infrastructure.Contexts.Base;
using Pharmacy.Infrastructure.Repositories.Base.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Pharmacy.Core.Models.Settings;

namespace Pharmacy.Infrastructure.Repositories.Base.Repository
{
    public class ProhibitedSubstancesRepository : Repository<ProhibitedSubstance, int>, IProhibitedSubstancesRepository
    {
        public ProhibitedSubstancesRepository(PharmacyContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ProhibitedSubstance>> GetByParametersAsync(ProhibitedSubstanceSearchObject search)
        {
            var query = Context.ProhibitedSubstances.Include(x => x.Substance).AsQueryable();
            if (search.SubstanceId.HasValue)
            {
                query = query.Where(x => search.SubstanceId == x.SubstanceId);
            }
            if (!string.IsNullOrWhiteSpace(search.SearchTerm))
            {
                query = query.Where(x => x.Substance.Name.ToLower().Equals(search.SearchTerm));
            }
            if (search.ListIds != null && search.ListIds.Length > 0)
            {
                query = query.Where(x => search.ListIds.Contains(x.SubstanceId));
            }
            query = query.Where(x => !x.DeletedDateTime.HasValue);
            var list = await query.ToListAsync();

            return list;
        }



    }
}
