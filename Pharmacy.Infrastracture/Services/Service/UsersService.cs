using Pharmacy.Core.Constants.Configurations;
using Pharmacy.Core.Wrappers.Dto;
using Pharmacy.Infrastructure.Services.IService;
using System;
using Pharmacy.Infrastructure.UnitOfWorks;

namespace Pharmacy.Infrastructure.Services.Service
{
    public class UsersService : Service<_UserDto, int>, IUsersService
    {
        private readonly AppSettingsConfiguration _settingsConfiguration;

        public UsersService(IDataUnitOfWork dataUnitOfWork, AppSettingsConfiguration settingsConfiguration) : base(dataUnitOfWork)
        {
            _settingsConfiguration = settingsConfiguration;
        }

        public override _UserDto GetById(int id)
        {
            throw new NotImplementedException();
        }

     
    }
}
