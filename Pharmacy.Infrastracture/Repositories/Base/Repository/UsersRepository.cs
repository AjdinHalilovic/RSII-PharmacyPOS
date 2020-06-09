using System.Linq;
using System.Threading.Tasks;
using Pharmacy.Core.Entities.Base;
using Pharmacy.Infrastructure.Contexts.Base;
using Pharmacy.Infrastructure.Repositories.Base.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Pharmacy.Infrastructure.Repositories.Base.Repository
{
    public class UsersRepository : Repository<User, int>, IUsersRepository
    {
        public UsersRepository(PharmacyContext context) : base(context)
        {
        }

        public User GetByAccessToken(string accessToken)
        {
            return Context.Users.AsNoTracking().SingleOrDefault(x => x.AccessToken == accessToken);
        }

        public async Task<User> GetByAccessTokenAsync(string accessToken)
        {
            return await Context.Users.AsNoTracking().SingleOrDefaultAsync(x => x.AccessToken == accessToken);
        }


       
    }
}
