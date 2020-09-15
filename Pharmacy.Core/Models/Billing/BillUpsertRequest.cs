using Pharmacy.Core.Entities.Base;
using Pharmacy.Core.Entities.Base.DTO;
using Pharmacy.Core.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.Models.Billing
{
    public class BillUpsertRequest
    {
        public List<BillItem> BillItems { get; set; } = new List<BillItem>();

    }
}
