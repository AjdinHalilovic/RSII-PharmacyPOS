using System.Linq;
using System.Threading.Tasks;
using Pharmacy.Core.Entities.Base;
using Pharmacy.Infrastructure.Contexts.Base;
using Pharmacy.Infrastructure.Repositories.Base.IRepository;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Core.Models;
using System.Collections.Generic;
using Pharmacy.Core.Models.Billing;
using Pharmacy.Core.Entities.Base.DTO;
using System.Text.RegularExpressions;
using Pharmacy.Infrastracture.Helpers;
using Pharmacy.Infrastracture;

namespace Pharmacy.Infrastructure.Repositories.Base.Repository
{
    public class ProductsRepository : Repository<Product, int>, IProductsRepository
    {
        public ProductsRepository(PharmacyContext context) : base(context)
        {
        }

      
        public async Task<IEnumerable<ProductDto>> GetAllDtosByParametersAsync(ProductSearchObject search)
        {
            //string searchTerm = string.IsNullOrEmpty(search.SearchTerm) ? null : $"{Regex.Replace(search.SearchTerm, @"\s+", " ").Replace(" ", ":*&")}:*";
            string searchTerm = search.SearchTerm?.Trim();
            var pCategoryId = search.CategoryId == 0 ? null : search.CategoryId;
            return await DbConnection.QueryFunctionAsync<ProductDto>(DbObjects.BaseDbObjects.Functions.Products.products_getdtosbyparameters, new { pPharmacyBranchId = search.PharmacyBranchId, pSearchTerm  = searchTerm, pEqualFullName = search.EqualSearchTerm ,pCategoryId });

        }

        public async Task<IEnumerable<Product>> GetByListIdsAsync(List<int> ids)
        {
            return await Context.Products.Where(x => ids.Contains(x.Id)).ToListAsync();
        }

    }
}
