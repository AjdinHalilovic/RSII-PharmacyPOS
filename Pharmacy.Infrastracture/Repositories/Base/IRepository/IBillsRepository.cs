using Pharmacy.Core.Entities.Base;
using Pharmacy.Core.Entities.Base.DTO;
using Pharmacy.Core.Models;
using Pharmacy.Core.Models.Billing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.Repositories.Base.IRepository
{
    public interface IBillsRepository : IRepository<Bill, int>
    {
        Task<Bill> GetLastBill(int pharmacyBranchId);
        Task<IEnumerable<BillDto>> GetAllDtosByParametersAsync(BillSearchObject search);
    }
}
