using Pharmacy.Core.Entities.Base;
using Pharmacy.Core.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.Repositories.Base.IRepository
{
    public interface IUserRolesRepository : IRepository<UserRole, int>
    {
        Task<IEnumerable<UserRole>> GetByParametersAsync(RolesSearchObject search);
    }
}
