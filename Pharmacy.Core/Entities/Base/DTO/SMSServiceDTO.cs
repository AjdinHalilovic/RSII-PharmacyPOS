using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Core.Entities.Base.DTO
{
    public class SMSServiceDTO
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Handle { get; set; }
        public string Message { get; set; }
        public string From { get; set; }
        public long To { get; set; } //38761000000
    }
}
