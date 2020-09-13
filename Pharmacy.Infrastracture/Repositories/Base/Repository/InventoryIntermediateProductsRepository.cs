using System.Linq;
using System.Threading.Tasks;
using Pharmacy.Core.Entities.Base;
using Pharmacy.Infrastructure.Contexts.Base;
using Pharmacy.Infrastructure.Repositories.Base.IRepository;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Core.Entities.Base.DTO;
using System.Collections.Generic;
using Pharmacy.Core.Models;
using Pharmacy.Core.Models.Billing;

namespace Pharmacy.Infrastructure.Repositories.Base.Repository
{
    public class InventoryIntermediateProductsRepository : Repository<InventoryIntermediateProduct, int>, IInventoryIntermediateProductsRepository
    {
        public InventoryIntermediateProductsRepository(PharmacyContext context) : base(context)
        {
        }

        public async Task<IEnumerable<InventoryIntermediateProductDto>> GetAllDtosByParametersAsync(InventoryIntermediateProductsSearchObject search)
        {
            var query = Context.InventoryIntermediateProducts.Include(x => x.Product).Include(x => x.InventoryIntermediate).AsQueryable();

            if (search.FromInventoryProducts)
            {
                query = query.Where(x => x.InventoryIntermediate.FromInventoryId == search.FromInventoryId);
            }
            else if (search.ToInventoryProducts)
            {
                query = query.Where(x => x.InventoryIntermediate.ToInventoryId == search.ToInventoryId);
            }

            if (search.PharmacyBranchId.HasValue)
            {
                query = query.Where(x => x.Product.PharmacyBranchId == search.PharmacyBranchId);
            }

            if (!string.IsNullOrWhiteSpace(search.SearchTerm))
            {
                query = query.Where(x => x.Product.Name.ToLower().StartsWith(search.SearchTerm) || x.Product.Code.ToLower().StartsWith(search.SearchTerm));
            }

            query = query.Where(x => !x.DeletedDateTime.HasValue);

            var list = await query.Select(x => new InventoryIntermediateProductDto()
            {
                Id = x.Id,
                CreatedDateTime = x.InventoryIntermediate.CreatedDateTime,
                Product = x.Product.Name,
                ProductCode = x.Product.Code,
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                Type = "INTERMEDIATE"
            }).ToListAsync();

            return list;
        }

    }
}
