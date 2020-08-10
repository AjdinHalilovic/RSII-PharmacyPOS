using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Core.Entities.Base
{
    [Table(Constants.Tables.InventoryEntries)]
    public class InventoryEntry : IEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required, ForeignKey(nameof(Inventory))]
        public int InventoryId { get; set; }
       [Required]
        public DateTime EntryDateTime { get; set; }
        [Required, ForeignKey(nameof(User))]
        public int UserId { get; set; }
        [Required]
        public string EntryNumber { get; set; }
        public DateTime? DeletedDateTime { get; set; }

        public Inventory Inventory { get; set; }
        public User User { get; set; }
    }

  
}