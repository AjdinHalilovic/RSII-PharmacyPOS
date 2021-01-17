using System.Linq;
using System.Threading.Tasks;
using Pharmacy.Core.Entities.Base;
using Pharmacy.Infrastructure.Contexts.Base;
using Pharmacy.Infrastructure.Repositories.Base.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Pharmacy.Core.Models.Billing;

namespace Pharmacy.Infrastructure.Repositories.Base.Repository
{
    public class ProductCategoriesRepository : Repository<ProductCategory, int>, IProductCategoriesRepository
    {
        public ProductCategoriesRepository(PharmacyContext context) : base(context)
        {
        }

        public IEnumerable<ProductCategory> GetByPharmacyBranchId(int pharmacyBranchId)
        {
            return Context.ProductCategories.Include(x => x.Product).Where(x => x.Product.PharmacyBranchId == pharmacyBranchId);
        }
        public async Task<IEnumerable<ProductCategory>> GetByParametersAsync(CategorySearchObject search)
        {
            var query = Context.ProductCategories.Include(x => x.Category).ThenInclude(x=>x.PharmacyBranch).AsQueryable();
            if (search.ProductId.HasValue)
            {
                query = query.Where(x => search.ProductId == x.ProductId);
            }

            if (search.PharmacyId.HasValue)
            {
                query = query.Where(x => search.PharmacyId == x.Category.PharmacyBranch.PharmacyId);
            }
            if (!string.IsNullOrWhiteSpace(search.SearchTerm))
            {
                query = query.Where(x => x.Category.Name.ToLower().Equals(search.SearchTerm));
            }
            if (search.ListIds != null && search.ListIds.Length > 0)
            {
                query = query.Where(x => search.ListIds.Contains(x.CategoryId));
            }
            query = query.Where(x => !x.DeletedDateTime.HasValue);

            var list = await query.ToListAsync();

            return list;
        }
        public async Task<IEnumerable<ProductCategory>> GetByProductIdsAsync(List<int> productIds)
        {
            return await Context.ProductCategories.Include(x => x.Product).Where(x => productIds.Contains(x.ProductId)).ToListAsync();
        }

    }
}
