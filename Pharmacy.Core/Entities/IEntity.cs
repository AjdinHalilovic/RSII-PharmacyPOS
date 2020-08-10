using System;

namespace Pharmacy.Core.Entities
{
    public interface IEntity
    {
        int Id { get; set; }
        DateTime? DeletedDateTime { get; set; }
    }
}