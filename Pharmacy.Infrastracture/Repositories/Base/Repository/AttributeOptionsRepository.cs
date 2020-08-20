using System.Linq;
using System.Threading.Tasks;
using Pharmacy.Core.Entities.Base;
using Pharmacy.Infrastructure.Contexts.Base;
using Pharmacy.Infrastructure.Repositories.Base.IRepository;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Core.Models;
using System.Collections.Generic;
using Pharmacy.Core.Models.Billing;

namespace Pharmacy.Infrastructure.Repositories.Base.Repository
{
    public class AttributeOptionsRepository : Repository<AttributeOption, int>, IAttributeOptionsRepository
    {
        public AttributeOptionsRepository(PharmacyContext context) : base(context)
        {
        }
        public async Task<IEnumerable<AttributeOption>> GetAllByParametersAsync(AttributeOptionSearchObject search)
        {
            var query = Context.AttributeOptions.AsQueryable();
            if (search.AttributeId.HasValue)
            {
                query = query.Where(x => x.AttributeId == search.AttributeId);
            }
            if (!string.IsNullOrWhiteSpace(search.SearchTerm))
            {
                query = query.Where(x => x.Value.ToLower().StartsWith(search.SearchTerm));
            }
            query = query.Where(x => !x.DeletedDateTime.HasValue);
            var list = await query.ToListAsync();

            return list;
        }


    }
}
