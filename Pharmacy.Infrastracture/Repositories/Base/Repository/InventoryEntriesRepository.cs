using System.Linq;
using System.Threading.Tasks;
using Pharmacy.Core.Entities.Base;
using Pharmacy.Infrastructure.Contexts.Base;
using Pharmacy.Infrastructure.Repositories.Base.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using Pharmacy.Core.Models;
using Pharmacy.Core.Entities.Base.DTO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Pharmacy.Infrastracture;
using Pharmacy.Infrastracture.Helpers;

namespace Pharmacy.Infrastructure.Repositories.Base.Repository
{
    public class InventoryEntriesRepository : Repository<InventoryEntry, int>, IInventoryEntriesRepository
    {
        public InventoryEntriesRepository(PharmacyContext context) : base(context)
        {
        }

        public async Task<IEnumerable<InventoryEntryDto>> GetAllDtosByParametersAsync(BaseSearchObject search)
        {
            //string searchTerm = string.IsNullOrEmpty(search.SearchTerm) ? null : $"{Regex.Replace(search.SearchTerm, @"\s+", " ").Replace(" ", ":*&")}:*";
            string searchTerm = search.SearchTerm;
            return await DbConnection.QueryFunctionAsync<InventoryEntryDto>(DbObjects.BaseDbObjects.Functions.InventoryEntries.inventoryentries_getdtosbyparameters, new { pPharmacyBranchId = search.PharmacyBranchId, pSearchTerm = searchTerm });
        }

    }
}
