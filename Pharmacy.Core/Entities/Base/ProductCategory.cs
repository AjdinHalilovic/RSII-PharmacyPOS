using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Core.Entities.Base
{
    [Table(Constants.Tables.ProductCategories)]
    public class ProductCategory : IEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required, ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        [Required, ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

        public DateTime? DeletedDateTime { get; set; }

        public Category Category { get; set; }
        public Product Product { get; set; }
    }

  
}