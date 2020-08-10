using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Core.Entities.Base
{
    [Table(Constants.Tables.Persons)]
    public class Person : IEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        [ForeignKey(nameof(Country))]
        public int? CountryId { get; set; }
        [ForeignKey(nameof(City))]
        public int? CityId { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
        public DateTime? DeletedDateTime { get; set; }

        public Country Country { get; set; }
        public City City { get; set; }
    }

  
}