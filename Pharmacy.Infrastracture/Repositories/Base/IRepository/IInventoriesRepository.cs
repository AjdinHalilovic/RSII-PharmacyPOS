using Pharmacy.Core.Entities.Base;
using Pharmacy.Core.Entities.Base.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.Repositories.Base.IRepository
{
    public interface IInventoriesRepository : IRepository<Inventory, int>
    {
        Task<IEnumerable<InventoryDto>> GetAllDtosByPharmacyIdAsync(int pharmacyId, int? inventoryId = null);
    }
}
