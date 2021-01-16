using Pharmacy.Core.Entities.Base;
using Pharmacy.Core.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.Models.Users
{
    public class UserUpsertRequest
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime? DateOfBirth { get; set; }

        [Required]
        public int? CountryId { get; set; }
        [Required]
        public int? CityId { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
        [Required]
        public int PharmacyBranchId { get; set; }

        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PasswordConfirmation { get; set; }


        public List<int> Roles { get; set; } = new List<int>();


        public static implicit operator Person(UserUpsertRequest model)
        {
            Person person = new Person()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth,
                CountryId = model.CountryId == 0 ? null : model.CountryId,
                CityId = model.CityId == 0 ? null : model.CityId,
                Address = model.Address,
                Note = model.Note
            };

            return person;
        }

        public static implicit operator User(UserUpsertRequest model)
        {
            var passwordSalt = Cryptography.Salt.Create();
            var passwordHash = Cryptography.Hash.Create(model.Password, passwordSalt);
            User user = new User()
            {
                Id = model.Id,
                Username = model.Username,
                Email = model.Email,
                Phone = model.Phone,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash
            };

            return user;
        }

    }
}
