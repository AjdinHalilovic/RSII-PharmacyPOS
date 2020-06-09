using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pharmacy.Infrastructure.Contexts.Base;
using Pharmacy.Infrastructure.UnitOfWorks.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Pharmacy.Infrastructure.UnitOfWorks
{
    public class DataUnitOfWork : IDataUnitOfWork
    {
        #region Contexts
        private readonly PharmacyContext _pharmacyContext;
        #endregion

        public DataUnitOfWork(PharmacyContext pharmacyContext)
        {
            _pharmacyContext = pharmacyContext;
        }



        #region Uow's
        private IBaseUnitOfWork _baseUnitOfWork;
        public IBaseUnitOfWork BaseUow => _baseUnitOfWork = _baseUnitOfWork ?? new BaseUnitOfWork(_pharmacyContext);

        #endregion



        #region Transactions
        private List<IDbContextTransaction> Transactions { get; set; }

        public void BeginTransactions()
        {
            if (Transactions == null)
                Transactions = new List<IDbContextTransaction>();

            Transactions.Add(BaseUow.Transaction());
        }
        public void CommitTransactions()
        {
            if (Transactions == null)
                return;

            /* Do not touch - treba ovako */
            Transactions.ForEach(x => x.Commit());
            Dispose();

            Transactions = null;
        }

        public void RollbackTransactions()
        {
            if (Transactions == null)
                return;

            /* Do not touch - treba ovako */
            Transactions.ForEach(x => x.Rollback());
            Dispose();

            Transactions = null;
        }
        public void Dispose()
        {
            if (Transactions == null)
                return;

            Transactions.ForEach(x => x.Dispose());

            Transactions = null;
        }
        #endregion



        #region Save changes
        public int SaveChanges() => _pharmacyContext.SaveChanges();

        public async Task<int> SaveChangesAsync()
        {
            int contextCount = await _pharmacyContext.SaveChangesAsync();

            return contextCount;
        }
        #endregion

        #region Discard changes
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
    }
}
