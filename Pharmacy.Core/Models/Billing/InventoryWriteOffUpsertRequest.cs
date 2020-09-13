using Pharmacy.Core.Entities.Base;
using Pharmacy.Core.Entities.Base.DTO;
using Pharmacy.Core.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.Models.Billing
{
    public class InventoryWriteOffUpsertRequest
    {
        public int Id { get; set; }

        [Required]
        public string Reason { get; set; }
        [Required]
        public DateTime WriteOffDateTime { get; set; }

        public int ProductId { get; set; }
        public int Quantity { get; set; }



        public static implicit operator WriteOffInventoryDocument(InventoryWriteOffUpsertRequest model)
        {
            WriteOffInventoryDocument product = new WriteOffInventoryDocument()
            {
                Id = model.Id,
                WriteOffDateTime = model.WriteOffDateTime,
                Reason = model.Reason,
                Quantity = model.Quantity
            };

            return product;
        }


    }
}
