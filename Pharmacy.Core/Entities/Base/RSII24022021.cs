using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Core.Entities.Base
{
    [Table(Constants.Tables.RSII24022021)]
    public class RSII24022021 : IEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required, ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public bool Maliciozan { get; set; }

        public DateTime? CreatedDateTime { get; set; }
        public DateTime? DeletedDateTime { get; set; }

        public User User { get; set; }
    }

  
}