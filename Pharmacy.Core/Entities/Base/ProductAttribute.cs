using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Core.Entities.Base
{
    [Table(Constants.Tables.ProductAttributes)]
    public class ProductAttribute : IEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required, ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        [Required, ForeignKey(nameof(Attribute))]
        public int AttributeId { get; set; }
        [Required, ForeignKey(nameof(AttributeOption))]
        public int AttributeOptionId { get; set; }

        public DateTime? DeletedDateTime { get; set; }

        public Product Product { get; set; }
        public Attribute Attribute { get; set; }
        public AttributeOption AttributeOption { get; set; }
    }

  
}