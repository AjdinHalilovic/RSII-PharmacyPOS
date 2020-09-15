using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Core.Entities.Base
{
    [Table(Constants.Tables.BillItems)]
    public class BillItem : IEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required, ForeignKey(nameof(Bill))]
        public int BillId { get; set; }

        [Required, ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        public decimal Total { get; set; }

        public DateTime? DeletedDateTime { get; set; }

        public Bill Bill { get; set; }
        public Product Product { get; set; }
    }

  
}