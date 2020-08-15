using Pharmacy.Core.Entities.Base;
using Pharmacy.Core.Entities.Base.DTO;
using Pharmacy.Core.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.Repositories.Base.IRepository
{
    public interface IPersonsRepository : IRepository<Person, int>
    {
        Task<IEnumerable<PersonDto>> GetAllDtosAsync(PersonSearchObject search);
    }
}
