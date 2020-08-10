using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Core.Entities.Base
{
    [Table(Constants.Tables.Roles)]
    public class Role : IEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int RoleLevel { get; set; }
        public DateTime? DeletedDateTime { get; set; }
    }

  
}