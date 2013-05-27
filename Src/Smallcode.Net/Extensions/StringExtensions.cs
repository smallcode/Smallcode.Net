using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Smallcode.Net.Extensions
{
    public static partial class StringExtensions
    {
        /// <summary>
        ///     截取字符串
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <param name="startTag">开始标记</param>
        /// <param name="endTag">结束标记</param>
        /// <param name="isContainsStartTag">截取后的内容是否包含开始标记</param>
        /// <param name="isContainsEndTag">截取后的内容是否包含结束标记</param>
        /// <returns>所截取到的内容</returns>
        public static string CutString(this string source, string startTag, string endTag,
                                       bool isContainsStartTag = false, bool isContainsEndTag = false)
        {
            var start = source.IndexOf(startTag, StringComparison.Ordinal);
            if (start < 0) return string.Empty;
            if (!isContainsStartTag) start += startTag.Length;
            var end = source.LastIndexOf(endTag, StringComparison.Ordinal);
            if (end < 0) return string.Empty;
            if (isContainsEndTag) end += endTag.Length;
            var length = end - start;
            return length > 0 ? source.Substring(start, length).Trim() : string.Empty;
        }

        /// <summary>
        ///     是否为空
        /// </summary>
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        ///     是否为空
        /// </summary>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        /// <summary>
        ///     是否为数字
        /// </summary>
        public static bool IsNumberic(this string text)
        {
            return new Regex(@"^\d+$").IsMatch(text);
        }

        ///// <summary>
        /////     计算字符串的字节长度的一半，多出半个则算一个。半角算半个，全角算一个。
        ///// </summary>
        //public static int HalfOfByteCount(this string source)
        //{
        //    var isTwo = Encoding.Default.GetByteCount(source) % 2 == 0;
        //    var count = Encoding.Default.GetByteCount(source) / 2;
        //    return isTwo ? count : count + 1;
        //}

        /// <summary>
        /// 格式化字符串
        /// </summary>
        public static string FormatWith(this string format, params object[] args)
        {
            return string.Format(format, args);
        }

        //以下三个是出于效能考虑
        public static string FormatWith(this string format, object arg0)
        {
            return string.Format(format, arg0);
        }

        public static string FormatWith(this string format, object arg0, object arg1)
        {
            return string.Format(format, arg0, arg1);
        }

        public static string FormatWith(this string format, object arg0, object arg1, object arg2)
        {
            return string.Format(format, arg0, arg1, arg2);
        }
    }
}