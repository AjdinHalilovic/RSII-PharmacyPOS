using System.Linq;
using System.Threading.Tasks;
using Pharmacy.Core.Entities.Base;
using Pharmacy.Infrastructure.Contexts.Base;
using Pharmacy.Infrastructure.Repositories.Base.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Pharmacy.Core.Models;

namespace Pharmacy.Infrastructure.Repositories.Base.Repository
{
    public class CategoriesRepository : Repository<Category, int>, ICategoriesRepository
    {
        public CategoriesRepository(PharmacyContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Category>> GetAllByParametersAsync(BaseSearchObject search)
        {
            var query = Context.Categories.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Equals(search.Name));
            }
           
            var list = await query.ToListAsync();

            return list;
        }


    }
}
