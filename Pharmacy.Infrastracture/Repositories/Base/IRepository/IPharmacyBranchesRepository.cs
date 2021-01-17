using Pharmacy.Core.Entities.Base;
using Pharmacy.Core.Entities.Base.DTO;
using Pharmacy.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.Repositories.Base.IRepository
{
    public interface IPharmacyBranchesRepository : IRepository<PharmacyBranch, int>
    {
        Task<IEnumerable<PharmacyBranchDto>> GetByParametersAsync(BaseSearchObject search);
        PharmacyBranch GetCentralBranch(int pharmacyId);
    }
}
