using System.Linq;
using System.Threading.Tasks;
using Pharmacy.Core.Entities.Base;
using Pharmacy.Infrastructure.Contexts.Base;
using Pharmacy.Infrastructure.Repositories.Base.IRepository;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Core.Models.Billing;
using Pharmacy.Core.Entities.Base.DTO;
using System.Collections.Generic;

namespace Pharmacy.Infrastructure.Repositories.Base.Repository
{
    public class InventoryEntryProductsRepository : Repository<InventoryEntryProduct, int>, IInventoryEntryProductsRepository
    {
        public InventoryEntryProductsRepository(PharmacyContext context) : base(context)
        {
        }

        public async Task<IEnumerable<InventoryEntryProductDto>> GetDtosByInventoryEntryAsync(InventoryEntryProductSearchObject search)
        {
            var query = Context.InventoryEntryProducts.Include(x=> x.Product).AsQueryable();

            if (search.PharmacyBranchId.HasValue)
            {
                query = query.Where(x => x.Product.PharmacyBranchId == search.PharmacyBranchId);
            }
            if (search.InventoryEntryId.HasValue)
            {
                query = query.Where(x => x.InventoryEntryId == search.InventoryEntryId);
            }
            if (!string.IsNullOrWhiteSpace(search.SearchTerm))
            {
                query = query.Where(x => x.Product.Name.ToLower().StartsWith(search.SearchTerm) || x.Product.Code.ToLower().StartsWith(search.SearchTerm));
            }

            query = query.Where(x => !x.DeletedDateTime.HasValue);

            var list = await query.Select(x => new InventoryEntryProductDto() { Id = x.Id, Product = x.Product.Name, ProductCode = x.Product.Code, ProductId = x.ProductId, Quantity = x.Quantity }).ToListAsync();

            return list;
        }

    }
}
