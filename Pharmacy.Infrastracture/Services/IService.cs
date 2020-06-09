namespace Pharmacy.Infrastructure.Services
{
    public interface IService<TEntity, in TPk> where TEntity : class
    {
        TEntity GetById(TPk id);
    }
}
