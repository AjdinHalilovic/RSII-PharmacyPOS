namespace Pharmacy.Core.Constants.Configurations
{
    public class TokenConfiguration
    {
        public  string Issuer { get; set; }
        public  string Audience { get; set; }
        public  string SecurityString { get; set; }

        public  double AccessExpiresInMinutes { get; set; }
        public double RefreshExpiresInMinutes { get; set; }
    }
}
