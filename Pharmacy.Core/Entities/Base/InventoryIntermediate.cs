using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Core.Entities.Base
{
    [Table(Constants.Tables.InventoryIntermediates)]
    public class InventoryIntermediate : IEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required, ForeignKey(nameof(FromInventory))]
        public int FromInventoryId { get; set; }

        [Required, ForeignKey(nameof(ToInventory))]
        public int ToInventoryId { get; set; }
        [Required, ForeignKey(nameof(User))]
        public int UserId { get; set; }

        [Required]
        public DateTime CreatedDateTime { get; set; }
        
        public DateTime? DeletedDateTime { get; set; }

        public Inventory FromInventory { get; set; }
        public Inventory ToInventory { get; set; }
        public User User { get; set; }
    }

  
}