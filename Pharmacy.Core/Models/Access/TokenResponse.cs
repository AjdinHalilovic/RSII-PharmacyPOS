using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.Models.Access
{
    public class TokenResponse
    {
        public string AccessToken { get; set; }
        public int AccessTokenExpiresIn { get; set; }

        public string RefreshToken { get; set; }
        public int RefreshTokenExpiresIn { get; set; }
    }
}
