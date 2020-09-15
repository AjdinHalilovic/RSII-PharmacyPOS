using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pharmacy.Core.Entities.Base.DTO
{
    public class BillItemDto
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public int ProductId { get; set; }
        public string Product { get; set; }
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
    }
}
