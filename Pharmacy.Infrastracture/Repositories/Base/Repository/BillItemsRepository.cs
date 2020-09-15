using System.Linq;
using System.Threading.Tasks;
using Pharmacy.Core.Entities.Base;
using Pharmacy.Infrastructure.Contexts.Base;
using Pharmacy.Infrastructure.Repositories.Base.IRepository;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Core.Entities.Base.DTO;
using System.Collections.Generic;
using Pharmacy.Core.Models;

namespace Pharmacy.Infrastructure.Repositories.Base.Repository
{
    public class BillItemsRepository : Repository<BillItem, int>, IBillItemsRepository
    {
        public BillItemsRepository(PharmacyContext context) : base(context)
        {
        }
        public async Task<IEnumerable<BillItemDto>> GetAllDtosByParametersAsync(BaseSearchObject search)
        {
            var query = Context.BillItems.Include(x=>x.Bill).Include(x => x.Product).AsQueryable();

            if (search.PharmacyBranchId.HasValue)
            {
                query = query.Where(x => x.Product.PharmacyBranchId == search.PharmacyBranchId);
            }

            if (!string.IsNullOrWhiteSpace(search.SearchTerm))
            {
                query = query.Where(x => x.Product.Name.ToLower().StartsWith(search.SearchTerm) || x.Product.Code.ToLower().StartsWith(search.SearchTerm));
            }

            query = query.Where(x => !x.DeletedDateTime.HasValue);

            var list = await query.Select(x => new BillItemDto()
            {
                Id = x.Id,
                CreatedDateTime = x.Bill.CreatedDateTime,
                Product = x.Product.Name,
                ProductCode = x.Product.Code,
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                Type = "SALES - InvoiceNo "+x.Bill.Number
            }).ToListAsync();

            return list;
        }


    }
}
