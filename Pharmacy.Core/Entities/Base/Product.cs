using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Core.Entities.Base
{
    [Table(Constants.Tables.Products)]
    public class Product : IEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required, ForeignKey(nameof(PharmacyBranch))]
        public int PharmacyBranchId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        public string Description { get; set; }
        [Required, ForeignKey(nameof(MeasurementUnit))]
        public int MeasurementUnitId { get; set; }

        public DateTime? DeletedDateTime { get; set; }

        public MeasurementUnit MeasurementUnit { get; set; }
        public PharmacyBranch PharmacyBranch { get; set; }

    }

  
}