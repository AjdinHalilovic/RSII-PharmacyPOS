using System.Linq;
using System.Threading.Tasks;
using Pharmacy.Core.Entities.Base;
using Pharmacy.Infrastructure.Contexts.Base;
using Pharmacy.Infrastructure.Repositories.Base.IRepository;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Core.Models.Billing;
using System.Collections.Generic;
using Pharmacy.Core.Entities.Base.DTO;

namespace Pharmacy.Infrastructure.Repositories.Base.Repository
{
    public class ProductAttributesRepository : Repository<ProductAttribute, int>, IProductAttributesRepository
    {
        public ProductAttributesRepository(PharmacyContext context) : base(context)
        {
        }


        public IEnumerable<ProductAttribute> GetByPharmacyBranchId(int pharmacyBranchId)
        {
            return Context.ProductAttributes.Include(x => x.Attribute).Where(x => x.Attribute.PharmacyBranchId == pharmacyBranchId);
        }

        public async Task<IEnumerable<ProductAttributeDto>> GetByParametersAsync(AttributeSearchObject search)
        {
            var query = Context.ProductAttributes.Include(x => x.Attribute).Include(x => x.AttributeOption).AsQueryable();
            if (search.ProductId.HasValue)
            {
                query = query.Where(x => search.ProductId == x.ProductId);
            }
            if (!string.IsNullOrWhiteSpace(search.SearchTerm))
            {
                query = query.Where(x => x.Attribute.Name.ToLower().Equals(search.SearchTerm));
            }
            if (search.ListIds != null && search.ListIds.Length > 0)
            {
                query = query.Where(x => search.ListIds.Contains(x.AttributeId));
            }
            query = query.Where(x => !x.DeletedDateTime.HasValue);
            var list = await query.Select(x => new ProductAttributeDto()
            {
                Id = x.Id,
                Attribute = x.Attribute.Name, AttributeId = x.AttributeId,
                AttributeOptionId = x.AttributeOptionId, AttributeOptionValue = x.AttributeOption.Value
            }).ToListAsync();

            return list;
        }

        public async Task<IEnumerable<ProductAttribute>> GetByProductIdsAsync(List<int> productIds)
        {
            return await Context.ProductAttributes.Include(x=>x.Product).Where(x => productIds.Contains(x.ProductId)).ToListAsync();
        }

    }
}
