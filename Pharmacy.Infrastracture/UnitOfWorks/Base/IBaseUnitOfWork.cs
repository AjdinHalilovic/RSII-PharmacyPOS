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

        IAttributesRepository AttributesRepository{ get; }
        IAttributeOptionsRepository AttributeOptionsRepository { get; }
        IBillsRepository BillsRepository { get; }
        IBillItemsRepository BillItemsRepository { get; }
        ICategoriesRepository CategoriesRepository { get; }
        ICitiesRepository CitiesRepository { get; }
        ICountriesRepository CountriesRepository { get; }
        IInventoriesRepository InventoriesRepository { get; }
        IInventoryEntriesRepository InventoryEntriesRepository { get; }
        IInventoryEntryProductsRepository InventoryEntryProductsRepository { get; }
        IInventoryIntermediateProductsRepository InventoryIntermediateProductsRepository { get; }
        IInventoryIntermediatesRepository InventoryIntermediatesRepository { get; }
        IInventoryProductsRepository InventoryProductsRepository { get; }
        IMeasurementUnitsRepository MeasurementUnitsRepository { get; }
        IPersonsRepository PersonsRepository{ get; }
        IPharmaciesRepository PharmaciesRepository{ get; }
        IPharmacyBranchesRepository PharmacyBranchesRepository{ get; }
        IPharmacyBranchUsersRepository PharmacyBranchUsersRepository{ get; }
        IProductsRepository ProductsRepository{ get; }
        IProductAttributesRepository ProductAttributesRepository{ get; }
        IProductCategoriesRepository ProductCategoriesRepository{ get; }
        IProductSubstancesRepository ProductSubstancesRepository{ get; }
        IProhibitedSubstancesRepository ProhibitedSubstancesRepository{ get; }
        IRolesRepository RolesRepository{ get; }
        ISubstancesRepository SubstancesRepository{ get; }
        IUsersRepository UsersRepository{ get; }
        IUserRolesRepository UserRolesRepository{ get; }
        IWriteOffInventoryDocumentsRepository WriteOffInventoryDocumentsRepository{ get; }
        IRSII24022021Repository RSII24022021Repository { get; }

        #endregion
    }
}
