using Pharmacy.Core.Entities.Base;
using Pharmacy.Core.Models.Billing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.Repositories.Base.IRepository
{
    public interface IAttributeOptionsRepository : IRepository<AttributeOption, int>
    {
        Task<IEnumerable<AttributeOption>> GetAllByParametersAsync(AttributeOptionSearchObject search);
    }
}
