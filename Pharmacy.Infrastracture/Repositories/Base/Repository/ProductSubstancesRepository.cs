﻿using System.Linq;
using System.Threading.Tasks;
using Pharmacy.Core.Entities.Base;
using Pharmacy.Infrastructure.Contexts.Base;
using Pharmacy.Infrastructure.Repositories.Base.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Pharmacy.Core.Models.Billing;
using Pharmacy.Infrastracture.Helpers;
using Pharmacy.Infrastracture;

namespace Pharmacy.Infrastructure.Repositories.Base.Repository
{
    public class ProductSubstancesRepository : Repository<ProductSubstance, int>, IProductSubstancesRepository
    {
        public ProductSubstancesRepository(PharmacyContext context) : base(context)
        {
        }

        public IEnumerable<ProductSubstance> GetByPharmacyBranchId(int pharmacyBranchId)
        {
            return Context.ProductSubstances.Include(x => x.Product).Where(x => x.Product.PharmacyBranchId == pharmacyBranchId);
        }
        public async Task<IEnumerable<ProductSubstance>> GetByParametersAsync(SubstanceSearchObject search)
        {
            var query = Context.ProductSubstances.Include(x => x.Substance).AsQueryable();
            if (search.ProductId.HasValue)
            {
                query = query.Where(x => search.ProductId == x.ProductId);
            }
            if (!string.IsNullOrWhiteSpace(search.SearchTerm))
            {
                query = query.Where(x => x.Substance.Name.ToLower().Equals(search.SearchTerm));
            }
            if (search.ListIds != null && search.ListIds.Length > 0)
            {
                query = query.Where(x => search.ListIds.Contains(x.SubstanceId));
            }
            query = query.Where(x => !x.DeletedDateTime.HasValue);
            var list = await query.ToListAsync();

            return list;
        }

        public async Task<IEnumerable<ProductSubstance>> GetByProductIdsAsync(List<int> productIds)
        {
            return await Context.ProductSubstances.Include(x => x.Product).Where(x => productIds.Contains(x.ProductId)).ToListAsync();
        }

        public async Task<bool> CheckProhibitedSubstances(ProductSubstanceSearchObject search)
        {
            var productIds = string.Join(",", search.ProhibitedProductIds);
            return await DbConnection.QueryFunctionFirstOrDefaultAsync<bool>(DbObjects.BaseDbObjects.Functions.ProductSubstances.productsubstances_anyprohibitedsubstance, new { pProductId = search.ProductId, pProductIds = productIds });
        }


    }
}
