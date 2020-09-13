using Pharmacy.Core.Entities.Base;
using Pharmacy.Core.Entities.Base.DTO;
using Pharmacy.Core.Models;
using Pharmacy.Core.Models.Billing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.Repositories.Base.IRepository
{
    public interface IProductsRepository : IRepository<Product, int>
    {
        Task<IEnumerable<ProductDto>> GetAllDtosByParametersAsync(ProductSearchObject search);
        Task<IEnumerable<Product>> GetByListIdsAsync(List<int> ids);
    }
}
