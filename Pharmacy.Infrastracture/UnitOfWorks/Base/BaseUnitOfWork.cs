using System.Linq;
using System.Threading.Tasks;
using Pharmacy.Infrastructure.Contexts.Base;
using Pharmacy.Infrastructure.Repositories.Base.IRepository;
using Pharmacy.Infrastructure.Repositories.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Pharmacy.Infrastructure.UnitOfWorks.Base
{
    public class BaseUnitOfWork : IBaseUnitOfWork
    {
        private readonly PharmacyContext _pharmacyContext;
        public IDbContextTransaction Transaction() => _pharmacyContext.Database.CurrentTransaction ?? _pharmacyContext.Database.BeginTransaction();
        public BaseUnitOfWork(PharmacyContext pharmacyContext)
        {
            _pharmacyContext = pharmacyContext;
        }



        #region Repositories

        #region Entities
      
        private IUsersRepository _usersRepository;
        public IUsersRepository UsersRepository => _usersRepository = _usersRepository ?? new UsersRepository(_pharmacyContext);

        #endregion

        #endregion

        #region Transaction
        public IDbContextTransaction BeginTransaction() => _pharmacyContext.Database.BeginTransaction();

        public async Task<IDbContextTransaction> BeginTransactionAsync() => await _pharmacyContext.Database.BeginTransactionAsync();

        public void CommitTransaction() => _pharmacyContext.Database.CommitTransaction();
        public void RollbackTransaction() => _pharmacyContext.Database.RollbackTransaction();

        #endregion

        #region SaveChanges
        public int SaveChanges() => _pharmacyContext.SaveChanges();

        public async Task<int> SaveChangesAsync() => await _pharmacyContext.SaveChangesAsync();
        #endregion

        #region DiscardChanges
        public void DiscardChanges()
        {
            foreach (var entry in _pharmacyContext.ChangeTracker.Entries()
                                  .Where(e => e.State != EntityState.Unchanged))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
        }
        #endregion

        #region Dispose
        public void Dispose() => _pharmacyContext.Dispose();
        #endregion
    }
}
