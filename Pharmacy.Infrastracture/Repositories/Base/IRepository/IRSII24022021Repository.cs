using Pharmacy.Core.Entities.Base;
using Pharmacy.Core.Entities.Base.DTO;
using Pharmacy.Core.Models.Billing;
using Pharmacy.Core.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.Repositories.Base.IRepository
{
    public interface IRSII24022021Repository : IRepository<RSII24022021, int>
    {
        Task<IEnumerable<RSII24022021Dto>> GetAllByParametersAsync(RSII24022021SearchObject search);
        Task<IEnumerable<RSII24022021>> GetByIds(List<int> ids);
    }
}
