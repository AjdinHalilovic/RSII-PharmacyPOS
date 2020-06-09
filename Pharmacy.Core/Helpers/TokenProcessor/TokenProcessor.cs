using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Pharmacy.Core.Constants.Configurations;
using Microsoft.IdentityModel.Tokens;

namespace Pharmacy.Core.Helpers.TokenProcessor
{
    public class TokenProcessor : ITokenProcessor
    {
        private readonly TokenConfiguration _tokenConfiguration;

        public TokenProcessor(TokenConfiguration tokenConfiguration)
        {
            _tokenConfiguration = tokenConfiguration;
        }

        #region Access token

        public string GenerateAccessToken(Claim[] claims)
        {
            if (claims is null || claims.Length == 0)
                throw new ArgumentException("Arguments to create token are not valid.");

            var securityTokenDescriptor = new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
            {
                Issuer = _tokenConfiguration.Issuer,
                Audience = _tokenConfiguration.Audience,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_tokenConfiguration.AccessExpiresInMinutes),
                SigningCredentials = new SigningCredentials(GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
            };

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            string token = jwtSecurityTokenHandler.WriteToken(securityToken);

            return token;
        }

        public bool IsValidToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                throw new ArgumentException("Given token is null or empty.");

            TokenValidationParameters tokenValidationParameters = GetTokenValidationParameters();

            try
            {
                new JwtSecurityTokenHandler().ValidateToken(token, tokenValidationParameters, out SecurityToken _);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Claim> GetTokenClaims(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                throw new ArgumentException("Given token is null or empty.");

            TokenValidationParameters tokenValidationParameters = GetTokenValidationParameters();

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            ClaimsPrincipal tokenValid = jwtSecurityTokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken _);

            return tokenValid.Claims;
        }

        #endregion

        #region Refresh token

        public string GenerateRefreshToken()
        {
            byte[] randomNumber = new byte[32];
            using (RandomNumberGenerator radnomNumber = RandomNumberGenerator.Create())
            {
                radnomNumber.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        //izbaci ovu kentru
        public string ConvertTokenFormatIfNedeed(string token)
        {
            return token.Replace("Bearer ", string.Empty);
        }

        #endregion


        #region Helpers
        private SecurityKey GetSymmetricSecurityKey()
        {
            byte[] symmetricKey = Convert.FromBase64String(_tokenConfiguration.SecurityString);
            return new SymmetricSecurityKey(symmetricKey);
        }

        private TokenValidationParameters GetTokenValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidIssuer = _tokenConfiguration.Issuer,
                ValidateAudience = true,
                ValidAudience = _tokenConfiguration.Audience,
                IssuerSigningKey = GetSymmetricSecurityKey()
            };
        }
        #endregion
    }
}
