using System.Text.RegularExpressions;

namespace Unfluff.Extensions
{
    public static class StringExtensions
    {
        private static readonly Regex HttpRegex = new Regex("^(http|https)://", RegexOptions.IgnoreCase);

        private static readonly Regex UrlRegex = new Regex(
            @"(http|ftp|https)://[\w-]+(\.[\w-]+)+([\w.,@?^=%&:/~+#-]*[\w@?^=%&/~+#-])?",
            RegexOptions.Singleline);

        /// <summary>
        ///     Checks if a string value is a valid URL.
        /// </summary>
        /// <param name="value">Value to check.</param>
        /// <returns>True if valid URL.</returns>
        public static bool IsValidUrl(this string value)
        {
            return UrlRegex.IsMatch(value);
        }

        /// <summary>
        ///     Normalizes a URL: stackoverflow.com -> http://stackoverflow.com.
        /// </summary>
        /// <param name="value">Value to normalize.</param>
        /// <returns>Normalized URL.</returns>
        public static string NormalizeUrl(this string value)
        {
            return HttpRegex.IsMatch(value) ? value : $"http://{value}";
        }
    }
}