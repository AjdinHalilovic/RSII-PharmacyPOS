using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pharmacy.Core.Entities.Base.DTO
{
    public class PharmacyBranchDto : BaseDto
    {
        public int PharmacyId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string BranchIdentifier { get; set; }
        public bool Central { get; set; }
    }
}
