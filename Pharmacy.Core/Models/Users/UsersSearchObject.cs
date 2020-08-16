using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.Models.Users
{
    public class UsersSearchObject
    {
        public int? NotId { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
    }
}
