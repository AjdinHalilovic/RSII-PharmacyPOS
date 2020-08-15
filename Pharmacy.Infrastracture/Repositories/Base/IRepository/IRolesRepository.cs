using Pharmacy.Core.Entities.Base;
using Pharmacy.Core.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.Repositories.Base.IRepository
{
    public interface IRolesRepository : IRepository<Role, int>
    {
        Task<IEnumerable<Role>> GetByParametersAsync(RolesSearchObject search);
    }
}
