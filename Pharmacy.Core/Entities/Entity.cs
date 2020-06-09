using System;

namespace Pharmacy.Core.Entities
{
    public class Entity
    {
        public virtual int Id { get; set; }

        public DateTime? CreatedDateTime { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public DateTime? DeletedDateTime { get; set; }
    }
}
