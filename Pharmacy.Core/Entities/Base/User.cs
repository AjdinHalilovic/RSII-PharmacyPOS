using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Core.Entities.Base
{
    [Table(Constants.Tables.Users)]
    public class User : IEntity
    {
        [Key,
         DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }



        public string AccessToken { get; set; }
        public DateTime? TokenExpirationDateTime { get; set; } //rename....

        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenExpirationDateTime { get; set; }


        public DateTime? CreatedTokenDateTime { get; set; } 
        public DateTime? UpdateDateTime { get; set; } //rename...


        public string FbPsid { get; set; }



        public bool IsDeleted { get; set; }

    }
}