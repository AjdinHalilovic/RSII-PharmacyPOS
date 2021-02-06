using System.Linq;
using System.Threading.Tasks;
using Pharmacy.Core.Entities.Base;
using Pharmacy.Infrastructure.Contexts.Base;
using Pharmacy.Infrastructure.Repositories.Base.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Pharmacy.Core.Models;
using Pharmacy.Core.Entities.Base.DTO;
using Pharmacy.Core.Models.Billing;

namespace Pharmacy.Infrastructure.Repositories.Base.Repository
{
    public class CategoriesRepository : Repository<Category, int>, ICategoriesRepository
    {
        public CategoriesRepository(PharmacyContext context) : base(context)
        {
        }

        public IEnumerable<Category> GetByPharmacyId(int pharmacyId)
        {
            return Context.Categories.Include(x => x.PharmacyBranch).Where(x => x.PharmacyBranch.PharmacyId == pharmacyId);
        }
        public async Task<IEnumerable<BaseDto>> GetAllByParametersAsync(CategorySearchObject search)
        {
            var query = Context.Categories.AsQueryable();

            if (search.PharmacyBranchId.HasValue)
            {
                query = query.Where(x => x.PharmacyBranchId == search.PharmacyBranchId);
            }
            if (!string.IsNullOrWhiteSpace(search.EqualSearchTerm))
            {
                query = query.Where(x => x.Name.ToLower().Equals(search.EqualSearchTerm.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(search.SearchTerm))
            {
                query = query.Where(x => x.Name.ToLower().StartsWith(search.SearchTerm.ToLower()));
            }
            if (search.ListIds != null  && search.ListIds.Any())
            {
                query = query.Where(x => search.ListIds.Contains(x.Id));
            }

            var list = await query.Select(x=> new BaseDto() { Id = x.Id, Name = x.Name}).ToListAsync();

            return list;
        }


    }
}
