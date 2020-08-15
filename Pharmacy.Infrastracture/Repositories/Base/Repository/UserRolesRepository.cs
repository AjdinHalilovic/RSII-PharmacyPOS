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
    public class UserRolesRepository : Repository<UserRole, int>, IUserRolesRepository
    {
        public UserRolesRepository(PharmacyContext context) : base(context)
        {
        }

        public async Task<IEnumerable<UserRole>> GetByParametersAsync(RolesSearchObject search)
        {
            var query = Context.UserRoles.Include(x=>x.Role).AsQueryable();
            if (search.UserId.HasValue)
            {
                query = query.Where(x => search.UserId == x.UserId);
            }
            if (!string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Role.Name.ToLower().Equals(search.Name));
            }
            if (search.ListIds != null && search.ListIds.Length > 0)
            {
                query = query.Where(x => search.ListIds.Contains(x.RoleId));
            }

            var list = await query.ToListAsync();

            return list;
        }


    }
}
