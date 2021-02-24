using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.Models.Users
{
    public class RSII24022021SearchObject : BaseSearchObject
    {
        public int? PersonId { get; set; }
        public DateTime? DateTimeFrom { get; set; }
        public DateTime? DateTimeTo { get; set; }
        public bool Maliciozan { get; set; }
    }
}
