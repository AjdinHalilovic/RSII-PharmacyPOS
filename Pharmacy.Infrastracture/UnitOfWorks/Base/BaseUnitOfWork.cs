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

        private IPersonsRepository _personsRepository;
        public IPersonsRepository PersonsRepository => _personsRepository = _personsRepository ?? new PersonsRepository(_pharmacyContext);


        private IAttributesRepository _attributesRepository;
        public IAttributesRepository AttributesRepository => _attributesRepository = _attributesRepository ?? new AttributesRepository(_pharmacyContext);

        private IAttributeOptionsRepository _attributeOptionsRepository;
        public IAttributeOptionsRepository AttributeOptionsRepository => _attributeOptionsRepository = _attributeOptionsRepository ?? new AttributeOptionsRepository(_pharmacyContext);

        private IBillsRepository _billsRepository;
        public IBillsRepository BillsRepository => _billsRepository = _billsRepository ?? new BillsRepository(_pharmacyContext);

        private IBillItemsRepository _billItemsRepository;
        public IBillItemsRepository BillItemsRepository => _billItemsRepository = _billItemsRepository ?? new BillItemsRepository(_pharmacyContext);

        private ICategoriesRepository _categoriesRepository;
        public ICategoriesRepository CategoriesRepository => _categoriesRepository = _categoriesRepository ?? new CategoriesRepository(_pharmacyContext);

        private ICitiesRepository _citiesRepository;
        public ICitiesRepository CitiesRepository => _citiesRepository = _citiesRepository ?? new CitiesRepository(_pharmacyContext);

        private ICountriesRepository _countriesRepository;
        public ICountriesRepository CountriesRepository => _countriesRepository = _countriesRepository ?? new CountriesRepository(_pharmacyContext);

        private IInventoriesRepository _inventoriesRepository;
        public IInventoriesRepository InventoriesRepository => _inventoriesRepository = _inventoriesRepository ?? new InventoriesRepository(_pharmacyContext);

        private IInventoryEntriesRepository _inventoryEntriesRepository;
        public IInventoryEntriesRepository InventoryEntriesRepository => _inventoryEntriesRepository = _inventoryEntriesRepository ?? new InventoryEntriesRepository(_pharmacyContext);

        private IInventoryEntryProductsRepository _inventoryEntryProductsRepository;
        public IInventoryEntryProductsRepository InventoryEntryProductsRepository => _inventoryEntryProductsRepository = _inventoryEntryProductsRepository ?? new InventoryEntryProductsRepository(_pharmacyContext);

        private IInventoryIntermediatesRepository _inventoryIntermediatesRepository;
        public IInventoryIntermediatesRepository InventoryIntermediatesRepository => _inventoryIntermediatesRepository = _inventoryIntermediatesRepository ?? new InventoryIntermediatesRepository(_pharmacyContext);

        private IInventoryIntermediateProductsRepository _inventoryIntermediateProductsRepository;
        public IInventoryIntermediateProductsRepository InventoryIntermediateProductsRepository => _inventoryIntermediateProductsRepository = _inventoryIntermediateProductsRepository ?? new InventoryIntermediateProductsRepository(_pharmacyContext);

        private IInventoryProductsRepository _inventoryProductsRepository;
        public IInventoryProductsRepository InventoryProductsRepository => _inventoryProductsRepository = _inventoryProductsRepository ?? new InventoryProductsRepository(_pharmacyContext);

        private IMeasurementUnitsRepository _measurementUnitsRepository;
        public IMeasurementUnitsRepository MeasurementUnitsRepository => _measurementUnitsRepository = _measurementUnitsRepository ?? new MeasurementUnitsRepository(_pharmacyContext);

        private IPharmaciesRepository _pharmaciesRepository;
        public IPharmaciesRepository PharmaciesRepository => _pharmaciesRepository = _pharmaciesRepository ?? new PharmaciesRepository(_pharmacyContext);

        private IPharmacyBranchesRepository _pharmacyBranchesRepository;
        public IPharmacyBranchesRepository PharmacyBranchesRepository => _pharmacyBranchesRepository = _pharmacyBranchesRepository ?? new PharmacyBranchesRepository(_pharmacyContext);

        private IPharmacyBranchUsersRepository _pharmacyBranchUsersRepository;
        public IPharmacyBranchUsersRepository PharmacyBranchUsersRepository => _pharmacyBranchUsersRepository = _pharmacyBranchUsersRepository ?? new PharmacyBranchUsersRepository(_pharmacyContext);

        private IProductAttributesRepository _productAttributesRepository;
        public IProductAttributesRepository ProductAttributesRepository => _productAttributesRepository = _productAttributesRepository ?? new ProductAttributesRepository(_pharmacyContext);

        private IProductCategoriesRepository _productCategoriesRepository;
        public IProductCategoriesRepository ProductCategoriesRepository => _productCategoriesRepository = _productCategoriesRepository ?? new ProductCategoriesRepository(_pharmacyContext);

        private IProductsRepository _productsRepository;
        public IProductsRepository ProductsRepository => _productsRepository = _productsRepository ?? new ProductsRepository(_pharmacyContext);

        private IProductSubstancesRepository _productSubstancesRepository;
        public IProductSubstancesRepository ProductSubstancesRepository => _productSubstancesRepository = _productSubstancesRepository ?? new ProductSubstancesRepository(_pharmacyContext);

        private IRolesRepository _rolesRepository;
        public IRolesRepository RolesRepository => _rolesRepository = _rolesRepository ?? new RolesRepository(_pharmacyContext);

        private ISubstancesRepository _substancesRepository;
        public ISubstancesRepository SubstancesRepository => _substancesRepository = _substancesRepository ?? new SubstancesRepository(_pharmacyContext);

        private IUserRolesRepository _userRolesRepository;
        public IUserRolesRepository UserRolesRepository => _userRolesRepository = _userRolesRepository ?? new UserRolesRepository(_pharmacyContext);

        private IWriteOffInventoryDocumentsRepository _writeOffInventoryDocumentsRepository;
        public IWriteOffInventoryDocumentsRepository WriteOffInventoryDocumentsRepository => _writeOffInventoryDocumentsRepository = _writeOffInventoryDocumentsRepository ?? new WriteOffInventoryDocumentsRepository(_pharmacyContext);

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
