using Pharmacy.Core.Entities.Base;
using Pharmacy.Core.Entities.Base.DTO;
using Pharmacy.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.Repositories.Base.IRepository
{
    public interface IInventoryEntriesRepository : IRepository<InventoryEntry, int>
    {
        Task<IEnumerable<InventoryEntryDto>> GetAllDtosByParametersAsync(BaseSearchObject search);
    }
}
