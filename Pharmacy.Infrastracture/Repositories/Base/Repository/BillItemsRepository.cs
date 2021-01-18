using System.Linq;
using System.Threading.Tasks;
using Pharmacy.Core.Entities.Base;
using Pharmacy.Infrastructure.Contexts.Base;
using Pharmacy.Infrastructure.Repositories.Base.IRepository;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Core.Entities.Base.DTO;
using System.Collections.Generic;
using Pharmacy.Core.Models;
using Pharmacy.Core.Models.Billing;
using Pharmacy.Infrastracture.Helpers;
using Pharmacy.Infrastracture;

namespace Pharmacy.Infrastructure.Repositories.Base.Repository
{
    public class BillItemsRepository : Repository<BillItem, int>, IBillItemsRepository
    {
        public BillItemsRepository(PharmacyContext context) : base(context)
        {
        }

        public async Task<IEnumerable<BillItem>> GetByRelatedProductIdAsync(int pRelatedProductId)
        {
            return await DbConnection.QueryFunctionAsync<BillItem>(DbObjects.BaseDbObjects.Functions.BillItems.billitems_getbyrelatedproductid, new { pRelatedProductId });
        }

        public async Task<IEnumerable<BillItemDto>> GetAllDtosByParametersAsync(BillItemSearchObject search)
        {
            var query = Context.BillItems.Include(x=>x.Bill).Include(x => x.Product).AsQueryable();

            if (search.BillId.HasValue)
            {
                query = query.Where(x => x.BillId == search.BillId);
            }

            if (search.PharmacyBranchId.HasValue)
            {
                query = query.Where(x => x.Product.PharmacyBranchId == search.PharmacyBranchId);
            }

            if (search.ProductId.HasValue)
            {
                query = query.Where(x => x.ProductId == search.ProductId);
            }

            if (!string.IsNullOrWhiteSpace(search.SearchTerm))
            {
                query = query.Where(x => x.Product.Name.ToLower().StartsWith(search.SearchTerm) || x.Product.Code.ToLower().StartsWith(search.SearchTerm));
            }

            if (search.DateFrom.HasValue)
            {
                query = query.Where(x => x.Bill.CreatedDateTime >= search.DateFrom);
            }

            if (search.DateTo.HasValue)
            {
                query = query.Where(x => x.Bill.CreatedDateTime <= search.DateTo);
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
                Price = x.UnitPrice,
                Amount = x.Total,
                Type = "SALES - InvoiceNo "+x.Bill.Number
            }).ToListAsync();

            return list;
        }


    }
}
