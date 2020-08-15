using Pharmacy.Core.Entities.Base;
using Pharmacy.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.Repositories.Base.IRepository
{
    public interface IProductsRepository : IRepository<Product, int>
    {
        Task<IEnumerable<Product>> GetAllByParametersAsync(BaseSearchObject search);
    }
}
