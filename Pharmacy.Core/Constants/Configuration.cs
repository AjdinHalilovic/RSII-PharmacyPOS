using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Pharmacy.Core.Constants
{
    public static class Configuration
    {
        public static readonly List<SystemLanguage> SupportedSystemLanguages = new List<SystemLanguage>
        {
            new SystemLanguage
            {
                Title = "English",
                Name = "en-us",
                Icon = "/app/media/img/languages/us.svg",
                DateFormat = "MM/dd/yyyy",
                DateTimeFormat="MM/dd/yyyy hh:mm tt",
                ClockTimeType = 12,
                CultureInfo = new CultureInfo("en-US"),
                Default = false,
                ShortTitle = "EN",
                CookieName = "c=en-US|uic=en-US"
            },
            new SystemLanguage
            {
                Title = "Bosanski",
                Name = "bs-latn-ba",
                Icon = "/app/media/img/languages/bs.svg",
                DateFormat = "dd.MM.yyyy",
                DateTimeFormat="dd.MM.yyyy HH:mm",
                ClockTimeType = 24,
                CultureInfo = new CultureInfo("bs-Latn-BA"),
                Default = true,
                ShortTitle = "BS",
                CookieName = "c=bs-Latn-BA|uic=bs-Latn-BA"
            }
        };

        public static class DatabaseConnections
        {
            public const string MainDatabaseConnectionString = "PharmacyDatabase";
        }

        public static class ApplicationDefaults
        {

            public const int ThumbnailWidth = 640;
            public const int ThumbnailHeight = 360;

            public const int PageSize = 10;

        }
        public class EncryptionKeys
        {
            public const string DefaultEncryptKey = "DefaultEncryptKey";

        }

        public const string EnDateTimeTimezoneFromat = "yyyy-MM-dd";

        public static string DefaultCulture => SupportedSystemLanguages.Where(sl => sl.Default).Select(sl => sl.Name).Single();
        public static CultureInfo DefaultCultureObj => SupportedSystemLanguages.Where(sl => sl.Default).Select(x=>x.CultureInfo).Single();
        public static int CurrentClockTimeType => SupportedSystemLanguages.Single(sl => sl.Name == CultureInfo.CurrentCulture.Name).ClockTimeType;


        public const string RequestVerificationToken = "__RequestVerificationToken";
        public const string RequestVerificationTokenHeader = "X-XSRF-TOKEN";

        public const string SharedResourcePath = "Resources";
        public const string SharedResourceFileName = "SharedResource";

        public const string ErrorsPath = "/error/{0}";

        public const string RecaptchaSiteKey = "6LdkyaQUAAAAANHU5j-wdq7QfXpYe-r2nZ2hjTJg";
        public const string RecaptchaSecretKey = "6LdkyaQUAAAAAOCu66WsrvHrMEWtmginupTri9JD";

        public const string RecaptchaLandingSiteKey = "6LcRpgAVAAAAALYvOXU9tF_iKzvHz7aCq-hNQFEX";
        public const string RecaptchaLandingSecretKey = "6LcRpgAVAAAAAKCqqbtAwmOVR4SWroiLLuSzOiIn";

        //TEMPORARY
        public const string WebUrl = "https://pharmacy.com";
        public const string TestWebUrl = "https://test.pharmacy.com";

        public const string EmailRegexString = "^[a-zA-Z0-9.!#$%&'*+\\/=?^_`{|}~-]+@[a-zA-Z0-9.-]+[.]{1}[a-zA-Z]{2,}$";
        public const string PhoneRegexString = "^[+]{1}[(]{1}[0-9]{3}[)]{1}[0-9]{2} [0-9]{3}[-][0-9]{3,4}[_]{0,1}$";
    }

    public class SystemLanguage
    {
        public string Title { get; set; }
        public string ShortTitle { get; set; }
        public string Name { get; set; }
        public string CookieName { get; set; }
        public string Icon { get; set; }
        public string DateFormat { get; set; }
        public string DateTimeFormat { get; set; }
        public int ClockTimeType { get; set; }
        public bool Default { get; set; }
        public CultureInfo CultureInfo { get; set; }
    }



}
