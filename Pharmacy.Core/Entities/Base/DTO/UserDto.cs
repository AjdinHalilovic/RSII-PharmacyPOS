using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pharmacy.Core.Entities.Base.DTO
{
    public class UserDto
    {
        [Key]
        public int Id { get; set; }

        public string Token { get; set; }
        public int UserId { get; set; }


        public DateTime? LastLogin { get; set; }
        public bool Active { get; set; }
    }
}
