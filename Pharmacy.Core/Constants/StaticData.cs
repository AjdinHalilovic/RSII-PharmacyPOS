using System.Collections.Generic;

namespace Pharmacy.Core.Constants
{
    public static class StaticData
    {
        public static IEnumerable<string> PhotoFormats = new List<string>
        {
            ".jpeg",
            ".jpg",
            ".bmp",
            ".png",
            ".gif"
        };

        public static IEnumerable<string> DocumentFormats = new List<string>
        {
            ".xls",
            ".xlsx",
            ".doc",
            ".docx",
            ".pptx",
            ".ppt",
            ".pdf",
            ".txt",
            ".sql",
            ".7zip",
            ".zip",
            ".rar",
            ".html",
            ".css",
            ".js",
            ".xml",
            ".apk",
            ".exe",
            ".jar"
        };
    }
}
