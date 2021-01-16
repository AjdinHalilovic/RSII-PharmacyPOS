using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.Models.Users
{
    public class PharmacyBranchUserSearchObject : BaseSearchObject
    {
        public int? UserId { get; set; }
    }
}
