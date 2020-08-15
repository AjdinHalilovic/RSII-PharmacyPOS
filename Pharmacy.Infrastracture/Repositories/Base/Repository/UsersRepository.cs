using System.Linq;
using System.Threading.Tasks;
using Pharmacy.Core.Entities.Base;
using Pharmacy.Infrastructure.Contexts.Base;
using Pharmacy.Infrastructure.Repositories.Base.IRepository;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Core.Entities.Base.DTO;
using Pharmacy.Infrastracture;
using Pharmacy.Infrastracture.Helpers;
using System.Collections;
using Pharmacy.Core.Models.Users;
using System.Collections.Generic;

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


        public User GetByUsernameOrEmailAddress(string username)
        {
            return Context.Users.AsNoTracking().FirstOrDefault(x => !x.DeletedDateTime.HasValue && (x.Username.Equals(username) || x.Email.Equals(username)));
        }

        public async Task<UserDto> GetByUserIdAndInstitutionIdAsync(int userId)
        {
            return await DbConnection.QueryFunctionFirstOrDefaultAsync<UserDto>(DbObjects.BaseDbObjects.Functions.Users.users_getloginbyuserid, new { pUserId = userId});
        }

        public async Task<UserDto> GetByUserTokensAndInstitutionIdAsync(string accessToken, string refreshToken)
        {
            return await DbConnection.QueryFunctionFirstOrDefaultAsync<UserDto>(DbObjects.BaseDbObjects.Functions.Users.users_getloginbyusertokens, new { pAccessToken = accessToken, pRefreshToken = refreshToken });
        }

        public async Task<IEnumerable<User>> GetAllByParametersAsync(UsersSearchObject search)
        {
            var query = Context.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search.Username))
            {
                query = query.Where(x => x.Username.ToLower().Equals(search.Username));
            }

            if (!string.IsNullOrWhiteSpace(search.Email))
            {
                query = query.Where(x => x.Email.ToLower().Equals(search.Email));
            }
            var list = await query.ToListAsync();

            return list;
        }

    }
}
