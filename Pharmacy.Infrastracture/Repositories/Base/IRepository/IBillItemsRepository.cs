﻿using Pharmacy.Core.Entities.Base;
using Pharmacy.Core.Entities.Base.DTO;
using Pharmacy.Core.Models;
using Pharmacy.Core.Models.Billing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.Repositories.Base.IRepository
{
    public interface IBillItemsRepository : IRepository<BillItem, int>
    {
        Task<IEnumerable<BillItemDto>> GetAllDtosByParametersAsync(BillItemSearchObject search);
        Task<IEnumerable<BillItem>> GetByRelatedProductIdAsync(int pRelatedProductId);
    }
}
