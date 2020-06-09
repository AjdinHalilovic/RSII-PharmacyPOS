using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace Pharmacy.Infrastructure.UnitOfWorks
{
    public interface IUnitOfWork
    {
        int SaveChanges();
        Task<int> SaveChangesAsync();

        void DiscardChanges();

        IDbContextTransaction BeginTransaction();
        Task<IDbContextTransaction> BeginTransactionAsync();

        void Dispose();
    }
}
