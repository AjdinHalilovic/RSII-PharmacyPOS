using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Core.Entities.Base
{
    [Table(Constants.Tables.InventoryEntryProducts)]
    public class InventoryEntryProduct : IEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required, ForeignKey(nameof(InventoryEntry))]
        public int InventoryEntryId { get; set; }
       [Required]
        public int Quantity { get; set; }
        [Required, ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public DateTime? DeletedDateTime { get; set; }

        public InventoryEntry InventoryEntry { get; set; }
        public Product Product { get; set; }
    }

  
}