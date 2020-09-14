using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.Models.Settings
{
    public class ProhibitedSubstanceSearchObject : BaseSearchObject
    {
        public int? SubstanceId { get; set; }
        public int? ProhibitedSubstanceId { get; set; }
        public int[] ListIds { get; set; }

    }
}
