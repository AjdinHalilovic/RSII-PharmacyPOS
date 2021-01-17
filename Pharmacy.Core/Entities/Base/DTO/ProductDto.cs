using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pharmacy.Core.Entities.Base.DTO
{
    public class ProductDto:BaseDto
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string MeasurementUnit { get; set; }
        public string Categories { get; set; }
        public int SubstancesNumber { get; set; }
        public int AttributeNumber { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public int OrderNumber { get; set; }
    }
}
