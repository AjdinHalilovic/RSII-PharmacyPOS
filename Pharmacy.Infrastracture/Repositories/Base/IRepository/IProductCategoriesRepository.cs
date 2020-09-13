using Pharmacy.Core.Entities.Base;
using Pharmacy.Core.Models.Billing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.Repositories.Base.IRepository
{
    public interface IProductCategoriesRepository : IRepository<ProductCategory, int>
    {
        Task<IEnumerable<ProductCategory>> GetByParametersAsync(CategorySearchObject search);
        Task<IEnumerable<ProductCategory>> GetByProductIdsAsync(List<int> productIds);
    }
}
