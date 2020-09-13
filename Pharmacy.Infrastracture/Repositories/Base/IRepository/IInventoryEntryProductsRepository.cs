using Pharmacy.Core.Entities.Base;
using Pharmacy.Core.Entities.Base.DTO;
using Pharmacy.Core.Models.Billing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.Repositories.Base.IRepository
{
    public interface IInventoryEntryProductsRepository : IRepository<InventoryEntryProduct, int>
    {
        Task<IEnumerable<InventoryEntryProductDto>> GetDtosByInventoryEntryAsync(InventoryEntryProductSearchObject search);
    }
}
