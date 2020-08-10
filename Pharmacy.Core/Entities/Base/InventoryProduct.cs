using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Core.Entities.Base
{
    [Table(Constants.Tables.InventoryProducts)]
    public class InventoryProduct : IEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required, ForeignKey(nameof(Inventory))]
        public int InventoryId { get; set; }

        [Required, ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        [Required]
        public decimal Quantity { get; set; }
        

        public DateTime? DeletedDateTime { get; set; }

        public Inventory Inventory { get; set; }
        public Product Product { get; set; }
    }

  
}