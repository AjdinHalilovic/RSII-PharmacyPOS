using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.Models.Billing
{
    public class ProductSearchObject : BaseSearchObject
    {
        public int PharmacyBranchId { get; set; }
    }
}
