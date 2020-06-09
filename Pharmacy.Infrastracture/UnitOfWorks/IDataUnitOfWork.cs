using System.Threading.Tasks;
using Pharmacy.Infrastructure.UnitOfWorks.Base;

namespace Pharmacy.Infrastructure.UnitOfWorks
{
    public interface IDataUnitOfWork
    {
        IBaseUnitOfWork BaseUow { get; }

        #region Transactions
        void BeginTransactions();

        void CommitTransactions();

        void RollbackTransactions();

        void Dispose();
        #endregion

        #region Save changes
        int SaveChanges();
        Task<int> SaveChangesAsync();
        #endregion

        #region Discard changes
        void DiscardChanges();
        #endregion
    }
}
