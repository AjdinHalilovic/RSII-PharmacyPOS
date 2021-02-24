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
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Pharmacy.Core.Entities.Base.Pharmacy> Pharmacies { get; set; }
        public virtual DbSet<PharmacyBranch> PharmacyBranches { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<PharmacyBranchUser> PharmacyBranchUsers { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<MeasurementUnit> MeasurementUnits { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Substance> Substances { get; set; }
        public virtual DbSet<Pharmacy.Core.Entities.Base.Attribute> Attributes{ get; set; }
        public virtual DbSet<AttributeOption> AttributeOptions { get; set; }
        public virtual DbSet<Bill> Bills{ get; set; }
        public virtual DbSet<InventoryEntry> InventoryEntries { get; set; }
        public virtual DbSet<InventoryEntryProduct> InventoryEntryProducts { get; set; }
        public virtual DbSet<InventoryIntermediate> InventoryIntermediates{ get; set; }
        public virtual DbSet<InventoryIntermediateProduct> InventoryIntermediateProducts{ get; set; }
        public virtual DbSet<BillItem>  BillItems{ get; set; }
        public virtual DbSet<InventoryProduct> InventoryProducts{ get; set; }
        public virtual DbSet<Category> Categories{ get; set; }
        public virtual DbSet<ProductSubstance> ProductSubstances{ get; set; }
        public virtual DbSet<ProductCategory>  ProductCategories{ get; set; }
        public virtual DbSet<ProhibitedSubstance>ProhibitedSubstances { get; set; }
        public virtual DbSet<WriteOffInventoryDocument> WriteOffInventoryDocuments{ get; set; }
        public virtual DbSet<ProductAttribute> ProductAttributes{ get; set; }
        public virtual DbSet<RSII24022021> RSII24022021 { get; set; }

        #endregion

        public PharmacyContext(DbContextOptions<PharmacyContext> options) : base(options)
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=160048; Integrated Security = true");
            base.OnConfiguring(optionsBuilder);
        }
    }
}