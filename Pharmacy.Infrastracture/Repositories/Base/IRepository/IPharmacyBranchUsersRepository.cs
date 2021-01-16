using Pharmacy.Core.Entities.Base;
using Pharmacy.Core.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.Repositories.Base.IRepository
{
    public interface IPharmacyBranchUsersRepository : IRepository<PharmacyBranchUser, int>
    {
        Task<IEnumerable<PharmacyBranchUser>> GetByParametersAsync(PharmacyBranchUserSearchObject search);
    }
}
