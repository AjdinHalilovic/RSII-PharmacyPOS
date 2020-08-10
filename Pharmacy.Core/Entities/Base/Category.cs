using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Core.Entities.Base
{
    [Table(Constants.Tables.Categories)]
    public class Category : IEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required, ForeignKey(nameof(PharmacyBranch))]
        public int PharmacyBranchId { get; set; }
        [Required]
        public string Name { get; set; }

        public DateTime? DeletedDateTime { get; set; }

        public PharmacyBranch PharmacyBranch { get; set; }
    }

  
}