using System.Linq;
using System.Threading.Tasks;
using Pharmacy.Core.Entities.Base;
using Pharmacy.Infrastructure.Contexts.Base;
using Pharmacy.Infrastructure.Repositories.Base.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Pharmacy.Infrastructure.Repositories.Base.Repository
{
    public class InventoryProductsRepository : Repository<InventoryProduct, int>, IInventoryProductsRepository
    {
        public InventoryProductsRepository(PharmacyContext context) : base(context)
        {
        }

        public async Task<IEnumerable<InventoryProduct>> GetByInventoryIdAndProductIds(int inventoryId, List<int> productIds)
        {
            return await Context.InventoryProducts.Where(x => !x.DeletedDateTime.HasValue && x.InventoryId == inventoryId && productIds.Contains(x.ProductId)).ToListAsync();
        }

        public async Task<IEnumerable<InventoryProduct>> GetByInventoryIdAndProductCodes(int inventoryId, List<string> codes)
        {
            return await Context.InventoryProducts.Include(x=>x.Product).Where(x => !x.DeletedDateTime.HasValue && x.InventoryId == inventoryId && codes.Contains(x.Product.Code)).ToListAsync();
        }

    }
}
