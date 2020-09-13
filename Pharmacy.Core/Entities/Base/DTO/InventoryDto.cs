using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pharmacy.Core.Entities.Base.DTO
{
    public class InventoryDto
    {
        [Key]
        public int Id { get; set; }
        public string PharmacyBranchIdentifier { get; set; }
    }
}
