using System.Text.RegularExpressions;

namespace Smallcode.Net.Extensions
{
    /// <summary>
    ///     字符串替换
    /// </summary>
    public static partial class StringExtensions
    {
        /// <summary>
        ///     清除所有空字符（如：换行、连续多个空格等）
        /// </summary>
        public static string ReplaceBlankSpaces(this string source, string replace = " ")
        {
            return Regex.Replace(source.Trim(), @"\s+", replace);
            //return source.Replace("\n", string.Empty).Replace("\r", string.Empty);//只去除所有换行
        }

        /// <summary>
        ///     清除换行
        /// </summary>
        public static string RepalceLine(this string source, string replace = "")
        {
            return source.Replace(@"\r\n", replace).Replace(@"\n", replace).Replace(@"\r", replace);
        }

        /// <summary>
        ///     清除或替换所有网址格式
        /// </summary>
        public static string RepalceUrl(this string source, string replace = "")
        {
            return Regex.Replace(source, @"(http(s)?://)?([A-Za-z0-9-]+\.)+[A-Za-z]+(/[\w-./?%&=]*)?", replace,
                                 RegexOptions.IgnoreCase).ReplaceBlankSpaces();
        }

        /// <summary>
        ///     清除或替换所有a标签中的href属性
        /// </summary>
        public static string ReplaceHref(this string source, string replace = "")
        {
            return Regex.Replace(source, @"href\s*=\s*(""|')([^""'])*(""|')", replace, RegexOptions.IgnoreCase);
        }

        /// <summary>
        ///     清除或替换所有html标签
        /// </summary>
        public static string ClearHtmlTags(this string source)
        {
            return Regex.Replace(source, "<[^>]*>", string.Empty);
        }

        /// <summary>
        ///     清除转义符
        /// </summary>
        public static string ClearEscape(this string source)
        {
            return source.RegexReplace(@"\\([""/]{1})", "$1");
        }

        /// <summary>
        ///     正则替换
        /// </summary>
        public static string RegexReplace(this string source, string pattern, string replacement = "")
        {
            return Regex.Replace(source, pattern, replacement, RegexOptions.IgnoreCase);
        }
    }
}