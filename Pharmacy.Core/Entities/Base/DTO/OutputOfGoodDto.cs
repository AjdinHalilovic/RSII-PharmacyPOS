using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pharmacy.Core.Entities.Base.DTO
{
    public class OutputOfGoodDto
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string CreatedDateTimeFormated => $"{CreatedDateTime.ToShortDateString()} {CreatedDateTime.ToShortTimeString()}";
        public int ProductId { get; set; }
        public string Product { get; set; }
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
        public string Reason { get; set; }
        public string Type { get; set; }

        public static implicit operator OutputOfGoodDto(WriteOffInventoryDocumentDto model)
        {
            OutputOfGoodDto product = new OutputOfGoodDto()
            {
                Id = model.Id,
                CreatedDateTime = model.CreatedDateTime,
                Product = model.Product,
                ProductCode = model.ProductCode,
                ProductId = model.ProductId,
                Quantity = model.Quantity,
                Reason = model.Reason,
                Type = model.Type
            };

            return product;
        }

        public static implicit operator OutputOfGoodDto(InventoryIntermediateProductDto model)
        {
            OutputOfGoodDto product = new OutputOfGoodDto()
            {
                Id = model.Id,
                CreatedDateTime = model.CreatedDateTime,
                Product = model.Product,
                ProductCode = model.ProductCode,
                ProductId = model.ProductId,
                Quantity = model.Quantity,
                Type = model.Type
            };

            return product;
        }
    }
}
