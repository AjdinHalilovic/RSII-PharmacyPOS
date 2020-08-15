using Pharmacy.Core.Entities.Base;
using Pharmacy.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.Repositories.Base.IRepository
{
    public interface ISubstancesRepository : IRepository<Substance, int>
    {
        Task<IEnumerable<Substance>> GetAllByParametersAsync(BaseSearchObject search);
    }
}
