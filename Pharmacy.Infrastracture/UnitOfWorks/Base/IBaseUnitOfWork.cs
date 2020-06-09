using Pharmacy.Infrastructure.Repositories.Base.IRepository;
using Microsoft.EntityFrameworkCore.Storage;

namespace Pharmacy.Infrastructure.UnitOfWorks.Base
{
    public interface IBaseUnitOfWork : IUnitOfWork
    {
        IDbContextTransaction Transaction();

        void CommitTransaction();
        void RollbackTransaction();

        #region Repositories

        IUsersRepository UsersRepository { get; }
       
        #endregion
    }
}
