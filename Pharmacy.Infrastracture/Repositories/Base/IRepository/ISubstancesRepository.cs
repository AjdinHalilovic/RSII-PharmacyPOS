using Pharmacy.Core.Entities.Base;
using Pharmacy.Core.Entities.Base.DTO;
using Pharmacy.Core.Models;
using Pharmacy.Core.Models.Billing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.Repositories.Base.IRepository
{
    public interface ISubstancesRepository : IRepository<Substance, int>
    {
        Task<IEnumerable<BaseDto>> GetAllByParametersAsync(SubstanceSearchObject search);
        IEnumerable<Substance> GetByPharmacyBranchId(int pharmacyBranchId);
    }
}
