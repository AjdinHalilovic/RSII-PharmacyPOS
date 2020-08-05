using System.Linq;
using System.Text.RegularExpressions;
using static Pharmacy.Core.Constants.Enumerations;

// ReSharper disable once CheckNamespace
namespace System
{
    public static class Extensions
    {
        #region Exception

        public static string InnerExceptionMessage(this Exception source)
        {
            return source == null ? string.Empty : source.InnerException == null ? source.Message : source.InnerException.Message;
        }

        #endregion

        #region String

        public static int[] CsvToIntArray(this string csv)
        {
            return string.IsNullOrEmpty(csv) ? null : Array.ConvertAll(csv.Split(','), int.Parse);
        }

        public static int[] CsvToUniqueIntArray(this string csv)
        {
            return string.IsNullOrEmpty(csv) ? null : csv.Split(',').Select(int.Parse).Distinct().ToArray();
        }

        public static string Format(this string format, params object[] args)
        {
            return string.Format(format, args);
        }

        public static bool IsSet(this string source)
        {
            return !string.IsNullOrWhiteSpace(source) && !string.IsNullOrEmpty(source);
        }

        public static string Remove(this string source, string value)
        {
            return source.Replace(value, string.Empty);
        }

        public static string StripHtml(this string source)
        {
            return source is null ? null : Regex.Replace(source, @"<[^>]*>", string.Empty);
        }

        public static string RemoveControllerNameSuffix(this string source) => source.Remove("Controller");

        #endregion

    }
}

namespace Pharmacy.Core.Helpers
{
    public static class CustomExtensions
    {
        #region Gender

        public static string Convert(this Gender value)
        {
            switch (value)
            {
                case Gender.Male:
                    return "M";
                case Gender.Female:
                    return "F";
                default:
                    return null;
            }
        }

        public static Gender Convert(this string value)
        {
            switch (value)
            {
                case "M":
                    return Gender.Male;
                default:
                    return Gender.Female;
            }
        }

        #endregion
    }
}