using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pharmacy.Core.Entities.Base.DTO
{
    public class PersonDto
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string DateOfBirthFormated => DateOfBirth.HasValue ? DateOfBirth.Value.ToShortDateString() : "/";
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PlaceFormated => $"{Country}, {City}, {Address}";
    }
}
