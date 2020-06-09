namespace Pharmacy.Core.Constants.Configurations
{
    public class DatabaseConfiguration
    {
        public string BaseConnectionString { get; set; }

        public int ConnectionTimeout { get; set; } = 5;
    }
}
