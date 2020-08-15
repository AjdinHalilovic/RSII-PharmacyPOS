﻿using System.Linq;
using System.Threading.Tasks;
using Pharmacy.Core.Entities.Base;
using Pharmacy.Infrastructure.Contexts.Base;
using Pharmacy.Infrastructure.Repositories.Base.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Pharmacy.Infrastructure.Repositories.Base.Repository
{
    public class PharmacyBranchesRepository : Repository<PharmacyBranch, int>, IPharmacyBranchesRepository
    {
        public PharmacyBranchesRepository(PharmacyContext context) : base(context)
        {
        }



    }
}