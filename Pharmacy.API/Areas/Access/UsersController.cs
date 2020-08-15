using Microsoft.AspNetCore.Mvc;
using Pharmacy.API.Controllers;
using Pharmacy.API.Filters;
using Pharmacy.Core.Constants.Configurations;
using Pharmacy.Core.Entities.Base;
using Pharmacy.Core.Entities.Base.DTO;
using Pharmacy.Core.Helpers;
using Pharmacy.Core.Helpers.TokenProcessor;
using Pharmacy.Core.Models.Access;
using Pharmacy.Core.Models.Users;
using Pharmacy.Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.API.Areas.Access
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : BaseController
    {
        #region Properties

        private readonly TokenConfiguration _tokenConfiguration;
        private readonly ITokenProcessor _tokenProcessor;

        #endregion

        public UsersController(IDataUnitOfWork dataUnitOfWork, ITokenProcessor tokenProcessor, TokenConfiguration tokenConfiguration) :
            base(dataUnitOfWork)
        {
            _tokenProcessor = tokenProcessor;
            _tokenConfiguration = tokenConfiguration;
        }

        #region Get
        [HttpGet,TokenValidation]
        public async Task<IActionResult> Get([FromQuery] UsersSearchObject search)
        {
            try
            {
                var users = await DataUnitOfWork.BaseUow.UsersRepository.GetAllByParametersAsync(search);

                return Ok(users);
            }
            catch (Exception ex)
            {

                return BadRequest();
                throw;
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await DataUnitOfWork.BaseUow.UsersRepository.GetByIdAsync(id));
        }
        #endregion

        #region Access

        [HttpPost, Route("Login/Token")]
        public async Task<ActionResult> Access([FromBody] LoginRequest model)
        {
            try
            {
                User user = DataUnitOfWork.BaseUow.UsersRepository.GetByUsernameOrEmailAddress(model.Username);
                if (user == null || !Cryptography.Hash.Validate(model.Password, user.PasswordSalt, user.PasswordHash))
                    return BadRequest("Incorrect username and/or password.");

                UserDto userAccount = await DataUnitOfWork.BaseUow.UsersRepository.GetByUserIdAndInstitutionIdAsync(user.Id);
                if (!userAccount.Active) return BadRequest("Your account is not active.");

                return Ok(await CreateAndSaveTokenAsync(userAccount));
            }
            catch (Exception ex)
            {

                return InternalServerError(ex.InnerExceptionMessage());
            }
        }

        #endregion

        #region Refresh

        [HttpPost, TokenValidation(true), Route("Login/Refresh")]
        public async Task<ActionResult<TokenResponse>> Refresh([FromHeader] string authentication, [FromHeader] string refreshToken)
        {
            try
            {
                UserDto user = await DataUnitOfWork.BaseUow.UsersRepository.GetByUserTokensAndInstitutionIdAsync(_tokenProcessor.ConvertTokenFormatIfNedeed(authentication), refreshToken);
                if (user == null)
                    return Gone("Bad refresh token!");

                return Ok(await CreateAndSaveTokenAsync(user));
            }
            catch (Exception ex)
            {

                return InternalServerError(ex.InnerExceptionMessage());
            }
        }

        #endregion

        //#region Auth user

        //[HttpGet, TokenValidation, Route("Login/Auth")]
        //public async Task<ActionResult<UserDetailsDto>> GetLoggedUser()
        //{
        //    ClaimUser loggedUser = ClaimUser;

        //    try
        //    {
        //        int userId = loggedUser.UserId;
        //        int organizationId = loggedUser.OrganizationId ?? 0;

        //        UserAuth user = DataUnitOfWork.AuthUow.UsersAuthRepository.GetById(userId); //2
        //        if (user == null) return Unauthorized("Authorization(Object) - Something went wrong!");

        //        PersonDto person = DataUnitOfWork.AuthUow.PersonsAuthRepository.GetPersonByUserId(userId); //3
        //        if (person == null) return Unauthorized("Authorization(Id) - Something went wrong!");

        //        OrganizationAuth organization =
        //            DataUnitOfWork.AuthUow.OrganizationsAuthRepository.GetByOrganizationId(loggedUser.OrganizationId.GetValueOrDefault()); //5

        //        UserDetailsDto userDetails;
        //        if (organization == null) // PROVJERITI NA OSNOVU DOMENE
        //        { // PATIENT
        //            userDetails = new UserDetailsDto(user, person, BaseUri.ToString())
        //            {
        //                UserType = Enumerations.UserType.Patient
        //            };
        //        }
        //        else
        //        {
        //            userDetails = new UserDetailsDto(user, person, BaseUri.ToString(), organization)
        //            {
        //                UserType = Enumerations.UserType.Staff,
        //                Summary = new SummaryDto(),
        //                Settings = new SettingsDto
        //                {
        //                    AssignDefaultQuestionnaireEnabled = true,
        //                    CreateCheckInProcessEnabled = true
        //                }
        //            };
        //        }

        //        return Ok(userDetails);
        //    }
        //    catch (Exception ex)
        //    {

        //        return InternalServerError(ex.InnerExceptionMessage());
        //    }
        //}

        //[HttpPut, TokenValidation, Route("User/Update")]
        //public async Task<ActionResult> PutLoggedUser(UserUpdateDTO model)
        //{
        //    ClaimUser loggedUser = ClaimUser;

        //    try
        //    {
        //        DataUnitOfWork.AuthUow.BeginTransaction();

        //        int userId = loggedUser.UserId;
        //        int organizationId = loggedUser.OrganizationId ?? 0;

        //        UserAuth user = DataUnitOfWork.AuthUow.UsersAuthRepository.GetById(userId); //2
        //        if (user == null) return Unauthorized("Authorization(Object) - Something went wrong!");

        //        PersonAuth person = DataUnitOfWork.AuthUow.PersonsAuthRepository.GetByUserId(userId); //3
        //        if (person == null) return Unauthorized("Authorization(Id) - Something went wrong!");

        //        person.FirstName = model.FirstName ?? person.FirstName;
        //        person.LastName = model.LastName ?? person.LastName;
        //        person.FullName = person.FirstName + " " + person.LastName;
        //        person.ProfileImage = model.Photo ?? person.ProfileImage;
        //        user.Email = model.Email ?? user.Email;
        //        user.Phone = model.PhoneNumber ?? user.Phone;

        //        DataUnitOfWork.AuthUow.UsersAuthRepository.Update(user);
        //        DataUnitOfWork.AuthUow.UsersAuthRepository.SaveChanges();

        //        DataUnitOfWork.AuthUow.PersonsAuthRepository.Update(person);
        //        DataUnitOfWork.AuthUow.PersonsAuthRepository.SaveChanges();

        //        DataUnitOfWork.AuthUow.CommitTransaction();
        //        return Ok("User data updated!");
        //    }
        //    catch (Exception ex)
        //    {

        //        return InternalServerError(ex.InnerExceptionMessage());
        //    }
        //}

        //#endregion

        #region Logout

        [HttpGet, TokenValidation(true)]
        [Route("Logout")]
        public async Task<ActionResult> Logout()
        {
            try
            {
                int? userId = ClaimUser?.UserId;

                if (!userId.HasValue) return Unauthorized("Authorization(Id) - Something went wrong!");

                User user = DataUnitOfWork.BaseUow.UsersRepository.GetById(userId.Value);
                if (user == null) return Unauthorized("Authorization(User Object) - Something went wrong!");

                user.CreatedTokenDateTime = null;
                user.AccessToken = null;
                user.TokenExpirationDateTime = null;
                user.RefreshToken = null;
                user.RefreshTokenExpirationDateTime = null;

                DataUnitOfWork.BaseUow.UsersRepository.Update(user);
                await DataUnitOfWork.BaseUow.UsersRepository.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
                throw;
            }
        }

        #endregion

        #region Helpers
        private async Task<TokenResponse> CreateAndSaveTokenAsync(UserDto user)
        {
            Claim[] claims =
            {
                new Claim(type: nameof(Person), value: user.UserId.ToString()),
            };

            string accessToken = _tokenProcessor.GenerateAccessToken(claims);
            string refreshToken = _tokenProcessor.GenerateRefreshToken();

            int accessTokenExpiresIn = (int)_tokenConfiguration.AccessExpiresInMinutes;
            int refreshTokenExpiresIn = (int)_tokenConfiguration.RefreshExpiresInMinutes;

            User baseUser = await DataUnitOfWork.BaseUow.UsersRepository.GetByIdAsync(user.UserId);

            baseUser.AccessToken = accessToken;
            baseUser.TokenExpirationDateTime = DateTime.Now.AddMinutes(accessTokenExpiresIn);
            baseUser.RefreshToken = refreshToken;
            baseUser.RefreshTokenExpirationDateTime = DateTime.Now.AddMinutes(refreshTokenExpiresIn);
            baseUser.CreatedTokenDateTime = DateTime.Now;

            DataUnitOfWork.BaseUow.UsersRepository.Update(baseUser);
            await DataUnitOfWork.BaseUow.UsersRepository.SaveChangesAsync();

            return new TokenResponse
            {
                UserFullName = user.UserFullName,
                AccessToken = accessToken,
                AccessTokenExpiresIn = accessTokenExpiresIn,
                RefreshToken = refreshToken,
                RefreshTokenExpiresIn = refreshTokenExpiresIn
            };
        }
        #endregion
    }
}
