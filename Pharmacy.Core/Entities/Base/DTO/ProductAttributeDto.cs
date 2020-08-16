using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pharmacy.Core.Entities.Base.DTO
{
    public class ProductAttributeDto
    {
        [Key]
        public int Id { get; set; }
        public string Attribute { get; set; }
        public string AttributeOptionValue { get; set; }
    }
}
