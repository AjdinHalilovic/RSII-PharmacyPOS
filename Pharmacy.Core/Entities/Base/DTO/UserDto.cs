﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pharmacy.Core.Entities.Base.DTO
{
    public class UserDto
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PharmacyId { get; set; }
        public int InventoryId { get; set; }
        public int PharmacyBranchId { get; set; }
        public string AccessToken { get; set; }
        public string UserFullName { get; set; }


        public bool Active { get; set; }
    }
}
