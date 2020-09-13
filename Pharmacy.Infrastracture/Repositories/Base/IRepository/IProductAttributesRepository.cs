using Pharmacy.Core.Entities.Base;
using Pharmacy.Core.Entities.Base.DTO;
using Pharmacy.Core.Models.Billing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.Repositories.Base.IRepository
{
    public interface IProductAttributesRepository : IRepository<ProductAttribute, int>
    {
        Task<IEnumerable<ProductAttributeDto>> GetByParametersAsync(AttributeSearchObject search);
        Task<IEnumerable<ProductAttribute>> GetByProductIdsAsync(List<int> productIds);
    }
}
