using Pharmacy.Core.Entities.Base;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.Repositories.Base.IRepository
{
    public interface IPharmaciesRepository : IRepository<Pharmacy.Core.Entities.Base.Pharmacy, int>
    {
        Task<Pharmacy.Core.Entities.Base.Pharmacy> GetByUniqueIdentifier(string identifier);
    }
}
