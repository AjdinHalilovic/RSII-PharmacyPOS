using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Core.Entities.Base
{
    [Table(Constants.Tables.PharmacyBranches)]
    public class PharmacyBranch : IEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, ForeignKey(nameof(Pharmacy))]
        public int PharmacyId { get; set; }
        [Required, ForeignKey(nameof(Country))]
        public int CountryId { get; set; }
        [Required, ForeignKey(nameof(City))]
        public int CityId { get; set; }
        public string Address { get; set; }
        [Required]
        public string BranchIdentifier { get; set; }
        public bool Central { get; set; }
        public DateTime? DeletedDateTime { get; set; }
        
        public Pharmacy Pharmacy { get; set; }
        public Country Country { get; set; }
        public City City { get; set; }
    }

  
}