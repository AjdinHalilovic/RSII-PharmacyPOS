using Pharmacy.Core.Entities.Base;
using Pharmacy.Core.Models.Settings;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.Repositories.Base.IRepository
{
    public interface IProhibitedSubstancesRepository : IRepository<ProhibitedSubstance, int>
    {
        Task<IEnumerable<ProhibitedSubstance>> GetByParametersAsync(ProhibitedSubstanceSearchObject search);
        IEnumerable<ProhibitedSubstance> GetByPharmacyBranchId(int pharmacyBranchId);
    }
}
