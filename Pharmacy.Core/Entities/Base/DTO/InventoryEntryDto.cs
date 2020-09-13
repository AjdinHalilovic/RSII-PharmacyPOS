using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pharmacy.Core.Entities.Base.DTO
{
    public class InventoryEntryDto
    {
        [Key]
        public int Id { get; set; }
        public string EntryNumber { get; set; }
        public string FullName { get; set; }
        public DateTime EntryDateTime { get; set; }
        public string EntryDateTimeFormated => $"{EntryDateTime.ToShortDateString()} {EntryDateTime.ToShortTimeString()}";
    }
}
