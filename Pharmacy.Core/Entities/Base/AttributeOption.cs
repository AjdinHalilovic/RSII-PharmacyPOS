using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Core.Entities.Base
{
    [Table(Constants.Tables.AttributeOptions)]
    public class AttributeOption : IEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required, ForeignKey(nameof(Attribute))]
        public int AttributeId { get; set; }
        [Required]
        public string Value { get; set; }

        public DateTime? DeletedDateTime { get; set; }

        public Attribute Attribute { get; set; }
    }

  
}