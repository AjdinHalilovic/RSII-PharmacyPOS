using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Core.Entities.Base
{
    [Table(Constants.Tables.ProductSubstances)]
    public class ProductSubstance : IEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required, ForeignKey(nameof(Substance))]
        public int SubstanceId { get; set; }

        [Required, ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

        public DateTime? DeletedDateTime { get; set; }

        public Substance Substance { get; set; }
        public Product Product { get; set; }
    }

  
}