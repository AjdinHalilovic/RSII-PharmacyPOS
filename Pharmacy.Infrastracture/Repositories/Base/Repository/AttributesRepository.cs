using System.Linq;
using System.Threading.Tasks;
using Pharmacy.Core.Entities.Base;
using Pharmacy.Infrastructure.Contexts.Base;
using Pharmacy.Infrastructure.Repositories.Base.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Pharmacy.Infrastructure.Repositories.Base.Repository
{
    public class AttributesRepository : Repository<Attribute, int>, IAttributesRepository
    {
        public AttributesRepository(PharmacyContext context) : base(context)
        {
        }



    }
}
