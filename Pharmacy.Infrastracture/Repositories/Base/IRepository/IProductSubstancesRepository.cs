using Pharmacy.Core.Entities.Base;
using Pharmacy.Core.Models.Billing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.Repositories.Base.IRepository
{
    public interface IProductSubstancesRepository : IRepository<ProductSubstance, int>
    {
        Task<IEnumerable<ProductSubstance>> GetByParametersAsync(SubstanceSearchObject search);
        Task<IEnumerable<ProductSubstance>> GetByProductIdsAsync(List<int> productIds);
    }
}
