using System.Linq;
using System.Threading.Tasks;
using Pharmacy.Core.Entities.Base;
using Pharmacy.Infrastructure.Contexts.Base;
using Pharmacy.Infrastructure.Repositories.Base.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Pharmacy.Core.Models.Users;

namespace Pharmacy.Infrastructure.Repositories.Base.Repository
{
    public class RolesRepository : Repository<Role, int>, IRolesRepository
    {
        public RolesRepository(PharmacyContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Role>> GetByParametersAsync(RolesSearchObject search)
        {
            var query = Context.Roles.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search.SearchTerm))
            {
                query = query.Where(x => x.Name.ToLower().Equals(search.SearchTerm));
            }
            if (search.ListIds != null && search.ListIds.Length > 0)
            {
                query = query.Where(x => search.ListIds.Contains(x.Id));
            }

            var list = await query.ToListAsync();

            return list;
        }

    }
}
