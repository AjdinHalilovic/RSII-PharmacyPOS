using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using System.Text;

namespace Pharmacy.Core.Entities.Base.DTO
{
    public class BillDto
    {
        [Key]
        public int Id { get; set; }
        public string Number { get; set; }
        public string UserFullName { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string CreatedDateTimeFormated => $"{CreatedDateTime.ToShortDateString()} {CreatedDateTime.ToShortTimeString()}";
        public string Total { get; set; }
        public decimal Amount { get; set; }
    }
}
