using System.Collections.Generic;
using System.Security.Claims;

namespace Pharmacy.Core.Helpers.TokenProcessor
{
    public interface ITokenProcessor
    {
        #region Refresh token
        string GenerateRefreshToken();
        string ConvertTokenFormatIfNedeed(string token);
        #endregion

        #region Access token
        string GenerateAccessToken(Claim[] claims);
        bool IsValidToken(string token);
        IEnumerable<Claim> GetTokenClaims(string token);
        #endregion
    }
}
