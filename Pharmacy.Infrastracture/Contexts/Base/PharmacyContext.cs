using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Pharmacy.Core.Entities;
using Pharmacy.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Pharmacy.Infrastructure.Contexts.Base
{
    public class PharmacyContext : DbContext
    {
        #region Entities
        
        public virtual DbSet<User> Users { get; set; }

        #endregion

        public PharmacyContext(DbContextOptions options) : base(options)
        {
        }

        #region Save changes

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            //OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            //OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving()
        {
            IEnumerable<EntityEntry> entries = ChangeTracker.Entries();
            foreach (EntityEntry entry in entries)
            {
                if (!(entry.Entity is Entity entity))
                    continue;

                DateTime now = DateTime.Now;

                switch (entry.State)
                {
                    case EntityState.Added: { entity.CreatedDateTime = entity.ModifiedDateTime = now; } break;
                    case EntityState.Modified: { entity.ModifiedDateTime = now; } break;
                    case EntityState.Deleted: { entity.DeletedDateTime = now; } break;
                }
            }
        }


        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* Remove all cascade relationships */
            modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()).ToList().ForEach(r => r.DeleteBehavior = DeleteBehavior.Restrict);


            base.OnModelCreating(modelBuilder);
        }
    }
}