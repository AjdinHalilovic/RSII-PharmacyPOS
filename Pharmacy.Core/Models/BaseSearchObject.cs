using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Core.Models
{
    public class BaseSearchObject
    {
        public string SearchTerm { get; set; }
        public int? PharmacyBranchId { get; set; }
    }
}
