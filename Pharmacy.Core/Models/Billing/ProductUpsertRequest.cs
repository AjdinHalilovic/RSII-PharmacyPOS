using Pharmacy.Core.Entities.Base;
using Pharmacy.Core.Entities.Base.DTO;
using Pharmacy.Core.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.Models.Billing
{
    public class ProductUpsertRequest
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public int? MeasurementUnitId { get; set; }
        [Required]
        public decimal Price { get; set; }

        public string Description { get; set; }



        public List<int> Categories { get; set; } = new List<int>();
        public List<int> Substances { get; set; } = new List<int>();
        public List<ProductAttribute> ProductAttributes { get; set; } = new List<ProductAttribute>();


        public static implicit operator Product(ProductUpsertRequest model)
        {
            Product product = new Product()
            {
                Id = model.Id,
                Name = model.Name,
                Code = model.Code,
                Price = model.Price,
                Description = model.Description,
                MeasurementUnitId = model.MeasurementUnitId.GetValueOrDefault()
            };

            return product;
        }


    }
}
