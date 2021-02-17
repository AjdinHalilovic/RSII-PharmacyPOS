using System.Linq;
using System.Threading.Tasks;
using Pharmacy.Core.Entities.Base;
using Pharmacy.Infrastructure.Contexts.Base;
using Pharmacy.Infrastructure.Repositories.Base.IRepository;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Core.Models;
using Pharmacy.Core.Entities.Base.DTO;
using System.Collections.Generic;

namespace Pharmacy.Infrastructure.Repositories.Base.Repository
{
    public class WriteOffInventoryDocumentsRepository : Repository<WriteOffInventoryDocument, int>, IWriteOffInventoryDocumentsRepository
    {
        public WriteOffInventoryDocumentsRepository(PharmacyContext context) : base(context)
        {
        }

        public async Task<IEnumerable<WriteOffInventoryDocumentDto>> GetAllDtosByParametersAsync(BaseSearchObject search)
        {
            var query = Context.WriteOffInventoryDocuments.Include(x => x.InventoryProduct).ThenInclude(x => x.Product).AsQueryable();

            if (search.PharmacyBranchId.HasValue)
            {
                query = query.Where(x => x.InventoryProduct.Product.PharmacyBranchId == search.PharmacyBranchId);
            }
            if (!string.IsNullOrWhiteSpace(search.SearchTerm))
            {
                query = query.Where(x => x.InventoryProduct.Product.Name.ToLower().StartsWith(search.SearchTerm) || x.InventoryProduct.Product.Code.ToLower().StartsWith(search.SearchTerm));
            }

            query = query.Where(x => !x.DeletedDateTime.HasValue);

            var list = await query.Select(x => new WriteOffInventoryDocumentDto()
            {
                Id = x.Id,
                CreatedDateTime = x.WriteOffDateTime,
                Product = x.InventoryProduct.Product.Name,
                ProductCode = x.InventoryProduct.Product.Code,
                ProductId = x.InventoryProduct.ProductId,
                Quantity = x.Quantity,
                Reason = x.Reason,
                Type = $"WRITE OFF - {x.Reason}"
            }).ToListAsync();

            return list;
        }

    }
}
