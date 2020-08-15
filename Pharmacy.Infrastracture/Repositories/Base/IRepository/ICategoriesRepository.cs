using Pharmacy.Core.Entities.Base;
using Pharmacy.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.Repositories.Base.IRepository
{
    public interface ICategoriesRepository : IRepository<Category, int>
    {
        Task<IEnumerable<Category>> GetAllByParametersAsync(BaseSearchObject search);
    }
}
