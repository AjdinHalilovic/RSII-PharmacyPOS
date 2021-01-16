using System.Linq;
using System.Threading.Tasks;
using Pharmacy.Core.Entities.Base;
using Pharmacy.Infrastructure.Contexts.Base;
using Pharmacy.Infrastructure.Repositories.Base.IRepository;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Core.Models;
using System.Collections.Generic;
using Pharmacy.Core.Entities.Base.DTO;

namespace Pharmacy.Infrastructure.Repositories.Base.Repository
{
    public class PharmacyBranchesRepository : Repository<PharmacyBranch, int>, IPharmacyBranchesRepository
    {
        public PharmacyBranchesRepository(PharmacyContext context) : base(context)
        {
        }

        public async Task<IEnumerable<PharmacyBranchDto>> GetByParametersAsync(BaseSearchObject search)
        {
            var query = Context.PharmacyBranches.Include(x => x.Pharmacy).Include(x => x.Country).Include(x => x.City).AsQueryable();
            if (search.PharmacyId.HasValue)
            {
                query = query.Where(x => search.PharmacyId == x.PharmacyId);
            }
            if (search.PharmacyBranchId.HasValue)
            {
                query = query.Where(x => search.PharmacyBranchId == x.Id);
            }
            if (!string.IsNullOrWhiteSpace(search.SearchTerm))
            {
                query = query.Where(x => x.BranchIdentifier.ToLower().Equals(search.SearchTerm));
            }

            query = query.Where(x => !x.DeletedDateTime.HasValue);
            var list = await query.Select(x =>
            new PharmacyBranchDto
            {
                Id = x.Id,
                Name = x.Pharmacy.Name,
                Country = x.Country.Name,
                City = x.City.Name,
                Address = x.Address,
                BranchIdentifier = x.BranchIdentifier,
                Central = x.Central
            }).ToListAsync();

            return list;
        }

    }
}
