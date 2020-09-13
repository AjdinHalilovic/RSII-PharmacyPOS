using System.Linq;
using System.Threading.Tasks;
using Pharmacy.Core.Entities.Base;
using Pharmacy.Infrastructure.Contexts.Base;
using Pharmacy.Infrastructure.Repositories.Base.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using Pharmacy.Core.Entities.Base.DTO;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Pharmacy.Infrastructure.Repositories.Base.Repository
{
    public class InventoriesRepository : Repository<Inventory, int>, IInventoriesRepository
    {
        public InventoriesRepository(PharmacyContext context) : base(context)
        {
        }

        public async Task<IEnumerable<InventoryDto>> GetAllDtosByPharmacyIdAsync(int pharmacyId, int? inventoryId = null)
        {
            return await Context.Inventories.Include(x => x.PharmacyBranch).Where(x => x.Id != inventoryId && !x.DeletedDateTime.HasValue && x.PharmacyBranch.PharmacyId == pharmacyId).Select(x => new InventoryDto() { Id = x.Id, PharmacyBranchIdentifier = x.PharmacyBranch.BranchIdentifier }).ToListAsync();
        }

    }
}
