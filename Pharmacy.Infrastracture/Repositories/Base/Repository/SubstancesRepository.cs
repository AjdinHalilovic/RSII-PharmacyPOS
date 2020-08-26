using System.Linq;
using System.Threading.Tasks;
using Pharmacy.Core.Entities.Base;
using Pharmacy.Infrastructure.Contexts.Base;
using Pharmacy.Infrastructure.Repositories.Base.IRepository;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Core.Models;
using System.Collections.Generic;
using Pharmacy.Core.Entities.Base.DTO;
using Pharmacy.Core.Models.Billing;

namespace Pharmacy.Infrastructure.Repositories.Base.Repository
{
    public class SubstancesRepository : Repository<Substance, int>, ISubstancesRepository
    {
        public SubstancesRepository(PharmacyContext context) : base(context)
        {
        }

        public async Task<IEnumerable<BaseDto>> GetAllByParametersAsync(SubstanceSearchObject search)
        {
            var query = Context.Substances.AsQueryable();

            if (search.PharmacyBranchId.HasValue)
            {
                query = query.Where(x => x.PharmacyBranchId == search.PharmacyBranchId);
            }
            if (!string.IsNullOrWhiteSpace(search.SearchTerm))
            {
                query = query.Where(x => x.Name.ToLower().StartsWith(search.SearchTerm));
            }
            if (search.ListIds != null && search.ListIds.Any())
            {
                query = query.Where(x => search.ListIds.Contains(x.Id));
            }

            var list = await query.Select(x=>new BaseDto() { Id = x.Id, Name = x.Name}).ToListAsync();

            return list;
        }

    }
}
