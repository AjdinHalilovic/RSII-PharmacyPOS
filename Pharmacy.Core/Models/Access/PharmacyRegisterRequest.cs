using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.Models.Access
{
    public class PharmacyRegisterRequest
    {
        [Required]
        public string PharmacyName { get; set; }
        [Required]
        public string PharmacyUniqueIdentifier { get; set; }
        [Required]
        public int? CountryId { get; set; }
        [Required]
        public int? CityId { get; set; }
        public string Address { get; set; }
        [Required]
        public string BranchIdentifier { get; set; }
        public bool CentralBranch { get; set; }
        public bool UseCentralBranchData { get; set; }


        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public string PasswordConfirmation { get; set; }
    }
}
