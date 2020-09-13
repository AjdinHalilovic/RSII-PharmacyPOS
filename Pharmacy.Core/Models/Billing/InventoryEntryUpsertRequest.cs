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
    public class InventoryEntryUpsertRequest
    {
        public int Id { get; set; }

        [Required]
        public string EntryNumber { get; set; }
        [Required]
        public DateTime EntryDateTime { get; set; }

        public List<InventoryEntryProduct> EntryProducts { get; set; } = new List<InventoryEntryProduct>();


        public static implicit operator InventoryEntry(InventoryEntryUpsertRequest model)
        {
            InventoryEntry product = new InventoryEntry()
            {
                Id = model.Id,
                EntryNumber = model.EntryNumber,
                EntryDateTime = model.EntryDateTime
            };

            return product;
        }


    }
}
