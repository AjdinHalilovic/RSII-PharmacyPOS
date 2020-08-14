﻿using Pharmacy.Core.Entities.Base;
using Pharmacy.Core.Entities.Base.DTO;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.Repositories.Base.IRepository
{
    public interface IUsersRepository : IRepository<User, int>
    {
        User GetByAccessToken(string accessToken);
        Task<User> GetByAccessTokenAsync(string accessToken);
        User GetByUsernameOrEmailAddress(string username);
        Task<UserDto> GetByUserIdAndInstitutionIdAsync(int userId);
        Task<UserDto> GetByUserTokensAndInstitutionIdAsync(string accessToken, string refreshToken);

    }
}
