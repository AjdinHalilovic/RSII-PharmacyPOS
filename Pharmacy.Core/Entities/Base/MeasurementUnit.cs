using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Core.Entities.Base
{
    [Table(Constants.Tables.MeasurementUnits)]
    public class MeasurementUnit : IEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ShortName { get; set; }
        public DateTime? DeletedDateTime { get; set; }
    }

  
}