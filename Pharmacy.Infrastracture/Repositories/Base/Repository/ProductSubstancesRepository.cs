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
    public class ProductSubstancesRepository : Repository<ProductSubstance, int>, IProductSubstancesRepository
    {
        public ProductSubstancesRepository(PharmacyContext context) : base(context)
        {
        }
        public async Task<IEnumerable<ProductSubstance>> GetByParametersAsync(SubstanceSearchObject search)
        {
            var query = Context.ProductSubstances.Include(x => x.Substance).AsQueryable();
            if (search.ProductId.HasValue)
            {
                query = query.Where(x => search.ProductId == x.ProductId);
            }
            if (!string.IsNullOrWhiteSpace(search.SearchTerm))
            {
                query = query.Where(x => x.Substance.Name.ToLower().Equals(search.SearchTerm));
            }
            if (search.ListIds != null && search.ListIds.Length > 0)
            {
                query = query.Where(x => search.ListIds.Contains(x.SubstanceId));
            }
            query = query.Where(x => !x.DeletedDateTime.HasValue);
            var list = await query.ToListAsync();

            return list;
        }


    }
}
