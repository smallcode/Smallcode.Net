using System.Text.RegularExpressions;

namespace Smallcode.Net.Extensions
{
    /// <summary>
    ///     取值
    /// </summary>
    public static partial class StringExtensions
    {
        public static bool TryGetJsonValue(this string json, string key, out string value)
        {
            var format = string.Format(@"([""']*){0}\1\s*:\s*([""']*)(?<value>.*?)\2", key);
            return json.TryGetMatchValue(@"[\{,]+\s*" + format + @"\s*[,\1|\}]+", out value, 3);
        }

        public static bool TryGetUrlValue(this string url, string key, out string value)
        {
            return url.TryGetMatchValue(GetUrlPattern(key), out value, 3);
        }

        public static bool TryGetMatchValue(this string input, string pattern, out string value, int groupsIndex = 1,
                                            RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.Compiled)
        {
            var match = Regex.Match(input, pattern, options);
            value = match.Success ? match.Groups[groupsIndex].Value : string.Empty;
            return match.Success;
        }

        public static string GetJsonValue(this string json, string key)
        {
            string value;
            TryGetJsonValue(json, key, out value);
            return value;
        }

        public static string GetUrlValue(this string url, string key)
        {
            string value;
            TryGetUrlValue(url, key, out value);
            return value;
        }

        public static string GetMatchValue(this string input, string pattern,
                                           int groupsIndex = 1,
                                           RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.Compiled)
        {
            string value;
            TryGetMatchValue(input, pattern, out value, groupsIndex, options);
            return value;
        }

        private static string GetUrlPattern(string keyPattern)
        {
            return string.Format(@"([""']*){0}\1\s*=\s*([""']*)(?<value>[^&\s]*)\2", keyPattern);
        }


    }
}