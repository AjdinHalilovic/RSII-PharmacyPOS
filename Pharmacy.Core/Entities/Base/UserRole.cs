using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Core.Entities.Base
{
    [Table(Constants.Tables.UserRoles)]
    public class UserRole : IEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, ForeignKey(nameof(User))]
        public int UserId { get; set; }
        [Required, ForeignKey(nameof(Pharmacy))]
        public int PharmacyId { get; set; }
        [Required, ForeignKey(nameof(PharmacyBranch))]
        public int PharmacyBranchId { get; set; }
        [Required, ForeignKey(nameof(Role))]
        public int RoleId { get; set; }
        public DateTime? DeletedDateTime { get; set; }

        public User User { get; set; }
        public Pharmacy Pharmacy { get; set; }
        public PharmacyBranch PharmacyBranch { get; set; }
        public Role Role { get; set; }
    }

  
}