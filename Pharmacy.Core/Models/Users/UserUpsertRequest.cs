using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.Models.Users
{
    public class UserUpsertRequest
    {
        
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime? DateOfBirth { get; set; }

        [Required]
        public int? CountryId { get; set; }
        [Required]
        public int? CityId { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }



        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PasswordConfirmation { get; set; }


        public List<int> Roles { get; set; } = new List<int>();
    }
}
