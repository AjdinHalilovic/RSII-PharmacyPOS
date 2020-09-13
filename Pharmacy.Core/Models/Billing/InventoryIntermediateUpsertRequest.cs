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
    public class InventoryIntermediateUpsertRequest
    {
        public int Id { get; set; }

        [Required]
        public int ToInventoryId { get; set; }
        [Required]
        public DateTime CreatedDateTime { get; set; }

        public List<InventoryIntermediateProduct> IntermediateProducts { get; set; } = new List<InventoryIntermediateProduct>();


        public static implicit operator InventoryIntermediate(InventoryIntermediateUpsertRequest model)
        {
            InventoryIntermediate product = new InventoryIntermediate()
            {
                Id = model.Id,
                ToInventoryId = model.ToInventoryId,
                CreatedDateTime = model.CreatedDateTime
            };

            return product;
        }


    }
}
