using Pharmacy.Core.Entities.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.Repositories.Base.IRepository
{
    public interface IInventoryProductsRepository : IRepository<InventoryProduct, int>
    {
        Task<IEnumerable<InventoryProduct>> GetByInventoryIdAndProductIds(int inventoryId, List<int> productIds);
        Task<IEnumerable<InventoryProduct>> GetByInventoryIdAndProductCodes(int inventoryId, List<string> codes);
    }
}
