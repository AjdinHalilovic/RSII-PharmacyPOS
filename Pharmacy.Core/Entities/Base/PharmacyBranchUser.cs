using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Core.Entities.Base
{
    [Table(Constants.Tables.PharmacyBranchUsers)]
    public class PharmacyBranchUser : IEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, ForeignKey(nameof(User))]
        public int UserId { get; set; }
        
        [Required, ForeignKey(nameof(PharmacyBranch))]
        public int PharmacyBranchId { get; set; }
        [Required]
        public DateTime StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public DateTime? DeletedDateTime { get; set; }

        public PharmacyBranch PharmacyBranch { get; set; }
        public User User { get; set; }

    }

  
}