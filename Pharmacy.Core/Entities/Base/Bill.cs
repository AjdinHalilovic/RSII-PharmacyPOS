using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Core.Entities.Base
{
    [Table(Constants.Tables.Bills)]
    public class Bill : IEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, ForeignKey(nameof(User))]
        public int AddUserId { get; set; }

        [Required, ForeignKey(nameof(PharmacyBranch))]
        public int PharmacyBranchId { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public DateTime CreatedDateTime { get; set; }
        public DateTime? CancelDateTime { get; set; }
        [Required]
        public decimal Total { get; set; }
        public DateTime? DeletedDateTime { get; set; }

        public PharmacyBranch PharmacyBranch { get; set; }
        public User User { get; set; }
    }

  
}