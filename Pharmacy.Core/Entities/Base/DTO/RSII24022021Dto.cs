using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pharmacy.Core.Entities.Base.DTO
{
    public class RSII24022021Dto
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string CreatedDateTimeFormated => CreatedDateTime.HasValue ? $"{CreatedDateTime.Value.ToShortDateString()} {CreatedDateTime.Value.ToShortTimeString()}" : "/";
        public bool Maliciozan { get; set; }
    }
}
