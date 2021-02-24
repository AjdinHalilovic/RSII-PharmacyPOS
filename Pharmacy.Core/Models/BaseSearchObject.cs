using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Core.Models
{
    public class BaseSearchObject
    {
        public string SearchTerm { get; set; }
        public string EqualSearchTerm { get; set; }
        public int? PharmacyBranchId { get; set; }
        public bool IncludeBranchFiltering { get; set; }
        public int? PharmacyId { get; set; }

        public List<int> ListIds { get; set; }
    }
}
