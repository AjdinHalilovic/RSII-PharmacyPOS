using Pharmacy.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Pharmacy.Infrastructure.Contexts.Base;

namespace Pharmacy.Infrastructure.Repositories.Base
{
    public abstract class Repository<TEntity, TPk> : IRepository<TEntity, TPk> where TEntity : class
    {
        protected readonly PharmacyContext Context;
        protected DbConnection DbConnection => Context.Database.GetDbConnection();

        private DbSet<TEntity> _entity;

        protected Repository(PharmacyContext context)
        {
            Context = context;
            _entity = Context.Set<TEntity>();
        }


        #region Select
        public virtual TEntity GetById(TPk id) => _entity.AsNoTracking().ToList().SingleOrDefault(i => Equals(((IEntity)i).Id, id));
        public virtual async Task<TEntity> GetByIdAsync(TPk id) => await _entity.AsNoTracking().SingleOrDefaultAsync(i => Equals(((IEntity)i).Id, id));

        public virtual IEnumerable<TEntity> GetAll() => _entity.Where(i => !((IEntity)i).DeletedDateTime.HasValue);
        #endregion

        #region Add
        public virtual void Add(TEntity entity)
        {
            try
            {
                _entity.Add(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            try
            {
                _entity.AddRange(entities);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update
        public virtual void Update(TEntity entity)
        {
            try
            {
                _entity.Update(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            try
            {
                _entity.UpdateRange(entities);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Delete
        public virtual TEntity Remove(TEntity entity, bool softDelete = true)
        {
            if (softDelete)
            {
                ((IEntity)entity).DeletedDateTime = DateTime.Now;
            }

            try
            {
                if (softDelete)
                {
                    _entity.Update(entity);
                }
                else
                {
                    _entity.Remove(entity);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return entity;
        }

        public virtual TEntity RemoveById(int id, bool softDelete = true)
        {
            var entity = _entity.FirstOrDefault(i => ((IEntity)i).Id == id);

            if (softDelete)
            {
                ((IEntity)entity).DeletedDateTime = DateTime.Now;
            }

            try
            {
                if (softDelete)
                {
                    _entity.Update(entity);
                }
                else
                {
                    _entity.Remove(entity);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return entity;
        }

        public virtual IEnumerable<TEntity> RemoveRange(IEnumerable<TEntity> entities, bool softDelete = true)
        {
            if (softDelete)
            {
                foreach (var entity in entities)
                    ((IEntity)entity).DeletedDateTime = DateTime.Now;
            }

            try
            {
                if (softDelete)
                {
                    _entity.UpdateRange(entities);
                }
                else
                {
                    _entity.RemoveRange(entities);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return entities;
        }

        public virtual IEnumerable<TEntity> RemoveRangeByIds(int[] ids, bool softDelete = true)
        {
            var entities = _entity.Where(i => ids.Contains(((IEntity)i).Id));

            if (softDelete)
            {
                foreach (var entity in entities)
                    ((IEntity)entity).DeletedDateTime = DateTime.Now;
            }

            try
            {
                if (softDelete)
                {
                    _entity.UpdateRange(entities);
                }
                else
                {
                    _entity.RemoveRange(entities);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return entities;
        }
        #endregion


        #region TRANSACTION
        public IDbContextTransaction BeginTransaction() => Context.Database.BeginTransaction();
        public async Task<IDbContextTransaction> BeginTransactionAsync() => await Context.Database.BeginTransactionAsync();

        public int SaveChanges() => Context.SaveChanges();

        public async Task<int> SaveChangesAsync() => await Context.SaveChangesAsync();
        #endregion
    }
}