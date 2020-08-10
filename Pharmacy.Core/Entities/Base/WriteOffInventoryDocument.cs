using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Core.Entities.Base
{
    [Table(Constants.Tables.WriteOffInventoryDocuments)]
    public class WriteOffInventoryDocument : IEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required, ForeignKey(nameof(InventoryProduct))]
        public int InventoryProductId { get; set; }

        [Required, ForeignKey(nameof(User))]
        public int UserId { get; set; }
        [Required]
        public DateTime WriteOffDateTime { get; set; }
        [Required]
        public int Quantity { get; set; }
        public string Reason { get; set; }
        public DateTime? DeletedDateTime { get; set; }

        public InventoryProduct InventoryProduct { get; set; }
        public User User { get; set; }
    }

  
}