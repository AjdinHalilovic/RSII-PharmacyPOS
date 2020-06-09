using System.Linq;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.Repositories.Base
{
    public interface IRepository<TEntity, in TPk> where TEntity : class
    {
        IDbContextTransaction BeginTransaction();
        Task<IDbContextTransaction> BeginTransactionAsync();

        int SaveChanges();
        Task<int> SaveChangesAsync();


        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        TEntity Remove(TEntity entity, bool softDelete = true);
        TEntity RemoveById(int id, bool softDelete = true);

        IEnumerable<TEntity> RemoveRange(IEnumerable<TEntity> entities, bool softDelete = true);
        IEnumerable<TEntity> RemoveRangeByIds(int[] ids, bool softDelete = true);

        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);


        TEntity GetById(TPk id);
        Task<TEntity> GetByIdAsync(TPk id);


        IEnumerable<TEntity> GetAll();
    }
}