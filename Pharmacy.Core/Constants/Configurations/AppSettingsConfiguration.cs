namespace Pharmacy.Core.Constants.Configurations
{
    public class AppSettingsConfiguration
    {
        public string ApplicationName { get; set; }

        public string WebRootPath { get; set; }
        public string FileEncryptionKey { get; set; }

        public string DefaultLanguageCode { get; set; }
        public int DefaultPagingFetchSize { get; set; } = 10;

        public SerilogConfiguration Serilog { get; set; }

        public DatabaseConfiguration Database { get; set; }
        public TokenConfiguration Token { get; set; }

        public EmailConfiguration Email { get; set; }
        public FirebaseConfiguration Firebase { get; set; }
    }
}
