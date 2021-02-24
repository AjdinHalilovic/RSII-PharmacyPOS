using System.Linq;
using System.Threading.Tasks;
using Pharmacy.Core.Entities.Base;
using Pharmacy.Infrastructure.Contexts.Base;
using Pharmacy.Infrastructure.Repositories.Base.IRepository;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Core.Models;
using System.Collections.Generic;
using Pharmacy.Core.Models.Billing;
using Pharmacy.Core.Entities.Base.DTO;
using Pharmacy.Core.Models.Users;

namespace Pharmacy.Infrastructure.Repositories.Base.Repository
{
    public class RSII24022021Repository : Repository<RSII24022021, int>, IRSII24022021Repository
    {
        public RSII24022021Repository(PharmacyContext context) : base(context)
        {
        }

        public async Task<IEnumerable<RSII24022021>> GetByIds(List<int> ids)
        {
            return await Context.RSII24022021.Where(x => ids.Contains(x.Id)).ToListAsync();
        }



        public async Task<IEnumerable<RSII24022021Dto>> GetAllByParametersAsync(RSII24022021SearchObject search)
        {
            var query = Context.RSII24022021.Include(x=>x.User).ThenInclude(x=>x.Person).Where(x=> x.Maliciozan == search.Maliciozan).AsQueryable();

            if (search.PersonId.HasValue)
            {
                query = query.Where(x => x.UserId == search.PersonId);
            }
            if (search.DateTimeFrom.HasValue)
            {
                query = query.Where(x => x.CreatedDateTime > search.DateTimeFrom);
            }
            if (search.DateTimeTo.HasValue)
            {
                query = query.Where(x => x.CreatedDateTime < search.DateTimeTo);
            }

            var result =await query.Select(x=>
            
                new RSII24022021Dto
                {
                    Id = x.Id,
                    FullName = $"{x.User.Person.FirstName} {x.User.Person.LastName}",
                    CreatedDateTime = x.CreatedDateTime,
                    Maliciozan = x.Maliciozan
                }
            ).ToListAsync();

            return result;
        }


    }
}
