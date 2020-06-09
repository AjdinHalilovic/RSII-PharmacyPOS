using Pharmacy.Infrastructure.UnitOfWorks;

namespace Pharmacy.Infrastructure.Services
{
    public abstract class Service<TEntity, TPk> : IService<TEntity, TPk> where TEntity : class
    {
        protected readonly IDataUnitOfWork DataUnitOfWork;
        public Service(IDataUnitOfWork dataUnitOfWork)
        {
            DataUnitOfWork = dataUnitOfWork;
        }

        public abstract TEntity GetById(TPk id);
    }
}
