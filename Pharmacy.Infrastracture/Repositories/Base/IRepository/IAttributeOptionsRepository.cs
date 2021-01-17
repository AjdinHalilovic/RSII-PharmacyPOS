using Pharmacy.Core.Entities.Base;
using Pharmacy.Core.Models.Billing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.Repositories.Base.IRepository
{
    public interface IAttributeOptionsRepository : IRepository<AttributeOption, int>
    {
        IEnumerable<AttributeOption> GetByPharmacyBranchId(int pharmacyBranchId);
        Task<IEnumerable<AttributeOption>> GetAllByParametersAsync(AttributeOptionSearchObject search);
    }
}
