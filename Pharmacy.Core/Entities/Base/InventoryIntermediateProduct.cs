using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Core.Entities.Base
{
    [Table(Constants.Tables.InventoryIntermediateProducts)]
    public class InventoryIntermediateProduct : IEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required, ForeignKey(nameof(InventoryIntermediate))]
        public int InventoryIntermediateId { get; set; }

        [Required, ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        public DateTime? DeletedDateTime { get; set; }

        public InventoryIntermediate InventoryIntermediate { get; set; }
        public Product Product { get; set; }
    }

  
}