using System.Linq;
using System.Threading.Tasks;
using Pharmacy.Core.Entities.Base;
using Pharmacy.Infrastructure.Contexts.Base;
using Pharmacy.Infrastructure.Repositories.Base.IRepository;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Core.Models;
using System.Collections.Generic;
using Pharmacy.Core.Models.Users;

namespace Pharmacy.Infrastructure.Repositories.Base.Repository
{
    public class PharmacyBranchUsersRepository : Repository<PharmacyBranchUser, int>, IPharmacyBranchUsersRepository
    {
        public PharmacyBranchUsersRepository(PharmacyContext context) : base(context)
        {
        }

        public async Task<IEnumerable<PharmacyBranchUser>> GetByParametersAsync(PharmacyBranchUserSearchObject search)
        {
            var query = Context.PharmacyBranchUsers.AsQueryable();
            if (search.PharmacyBranchId.HasValue)
            {
                query = query.Where(x => search.PharmacyBranchId == x.PharmacyBranchId);
            }
            if (search.UserId.HasValue)
            {
                query = query.Where(x => search.UserId == x.UserId);
            }

            query = query.Where(x => !x.DeletedDateTime.HasValue);
            var list = await query.ToListAsync();

            return list;
        }


    }
}
