﻿using System.Linq;
using System.Threading.Tasks;
using Pharmacy.Core.Entities.Base;
using Pharmacy.Infrastructure.Contexts.Base;
using Pharmacy.Infrastructure.Repositories.Base.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Pharmacy.Infrastructure.Repositories.Base.Repository
{
    public class PharmaciesRepository : Repository<Pharmacy.Core.Entities.Base.Pharmacy, int>, IPharmaciesRepository
    {
        public PharmaciesRepository(PharmacyContext context) : base(context)
        {
        }

        public async Task<Pharmacy.Core.Entities.Base.Pharmacy> GetByUniqueIdentifier(string identifier)
        {
            return await Context.Pharmacies.FirstOrDefaultAsync(x => !x.DeletedDateTime.HasValue && x.PharmacyUniqueIdentifier.ToLower().Equals(identifier.ToLower()));
        }


    }
}
