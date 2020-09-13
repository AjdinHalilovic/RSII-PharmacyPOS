using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.Models.Billing
{
    public class InventoryIntermediateProductsSearchObject : BaseSearchObject
    {
        public bool FromInventoryProducts { get; set; }
        public bool ToInventoryProducts { get; set; }

        public int? FromInventoryId { get; set; }
        public int? ToInventoryId { get; set; }
    }
}
