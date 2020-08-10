using Pharmacy.Core.Entities.Base;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.Repositories.Base.IRepository
{
    public interface IUsersRepository : IRepository<User, int>
    {
        User GetByAccessToken(string accessToken);
        Task<User> GetByAccessTokenAsync(string accessToken);
        User GetByUsernameOrEmailAddress(string username);

    }
}
