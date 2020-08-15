﻿using System.Linq;
using System.Threading.Tasks;
using Pharmacy.Core.Entities.Base;
using Pharmacy.Infrastructure.Contexts.Base;
using Pharmacy.Infrastructure.Repositories.Base.IRepository;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Core.Models;
using System.Collections.Generic;

namespace Pharmacy.Infrastructure.Repositories.Base.Repository
{
    public class AttributesRepository : Repository<Attribute, int>, IAttributesRepository
    {
        public AttributesRepository(PharmacyContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Attribute>> GetAllByParametersAsync(BaseSearchObject search)
        {
            var query = Context.Attributes.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Equals(search.Name));
            }

            var list = await query.ToListAsync();

            return list;
        }

    }
}