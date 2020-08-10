using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Core.Entities.Base
{
    [Table(Constants.Tables.Users)]
    public class User : IEntity
    {
        [Key,
         ForeignKey(nameof(Person)),
         DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Username { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required,
         StringLength(100)]
        public string PasswordHash { get; set; }

        [Required,
         StringLength(100)]
        public string PasswordSalt { get; set; }

        [Required,
         DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }

        public DateTime? DeletedDateTime { get; set; }



        public Person Person { get; set; }




        public string AccessToken { get; set; }
        public DateTime? TokenExpirationDateTime { get; set; } //rename....

        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenExpirationDateTime { get; set; }


        public DateTime? CreatedTokenDateTime { get; set; }
        public DateTime? UpdateDateTime { get; set; } //rename...
    }

  
}