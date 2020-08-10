using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Core.Entities.Base
{
    [Table(Constants.Tables.Pharmacies)]
    public class Pharmacy : IEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string PharmacyUniqueIdentifier { get; set; }
        [Required]
        public string Name { get; set; }
        [Required,ForeignKey(nameof(User))]
        public int OwnerUserId { get; set; }
        public DateTime? DeletedDateTime { get; set; }
        public User User { get; set; }
    }

  
}