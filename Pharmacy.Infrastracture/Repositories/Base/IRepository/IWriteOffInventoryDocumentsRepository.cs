using Pharmacy.Core.Entities.Base;
using Pharmacy.Core.Entities.Base.DTO;
using Pharmacy.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.Repositories.Base.IRepository
{
    public interface IWriteOffInventoryDocumentsRepository : IRepository<WriteOffInventoryDocument, int>
    {
        Task<IEnumerable<WriteOffInventoryDocumentDto>> GetAllDtosByParametersAsync(BaseSearchObject search);
    }
}
