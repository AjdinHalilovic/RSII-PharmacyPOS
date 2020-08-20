using Pharmacy.Core.Entities.Base;
using Pharmacy.Core.Entities.Base.DTO;
using Pharmacy.Core.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.Models.Settins
{
    public class AttributeUpsertRequest : BaseInsertRequest
    {
        public List<AttributeOption> AttributeOptions { get; set; } = new List<AttributeOption>();

    }
}
