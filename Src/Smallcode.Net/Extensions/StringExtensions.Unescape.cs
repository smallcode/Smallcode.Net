using System;
using System.Net;
using System.Text.RegularExpressions;

namespace Smallcode.Net.Extensions
{
    /// <summary>
    ///     字符反转义和解码
    /// </summary>
    public static partial class StringExtensions
    {
        /// <summary>
        ///     Url通用解码器
        /// </summary>
        public static string UrlUnescape(this string source)
        {
            return Uri.UnescapeDataString(source);
        }

        /// <summary>
        ///     可对“\u624b\u673a\u65b0”解码
        /// </summary>
        public static string UUnescape(this string source)
        {
            return Regex.Unescape(source);
        }

        /// <summary>
        ///     解码HTML转义字符（如将 &lt; 或者 &#60; 解码为小于号）
        /// </summary>
        public static string HtmlDecode(this string source)
        {
            return WebUtility.HtmlDecode(source);
        }
    }
}