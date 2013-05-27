using System;
using System.Text;

namespace Smallcode.Net.Extensions
{
    /// <summary>
    ///     字符转义和编码
    /// </summary>
    public static partial class StringExtensions
    {
        ///// <summary>
        /////     编码（转义）为十六进制表示形式。所有字符在转义之前都会先转换为 UTF-8 格式。（对RFC 2396 保留字符不进行转换）
        ///// </summary>
        //public static string EscapeDataString(this string source)
        //{
        //    return Uri.EscapeDataString(source);
        //}

        /// <summary>
        ///     编码（转义）为十六进制表示形式，所有字符在转义之前都会先转换为指定的编码格式（默认为GBK）格式。（对RFC 2396 保留字符不进行转换）
        /// </summary>
        /// <param name="source">要进行编码的字符串</param>
        /// <param name="urlEncoding">编码枚举类型</param>
        /// <returns>经过编码的字符串</returns>
        public static string EscapeDataStringBy(this string source, UrlEncoding urlEncoding = UrlEncoding.GB2312)
        {
            if (Uri.IsWellFormedUriString(source, UriKind.RelativeOrAbsolute)) return source; //对RFC 2396 保留字符不进行转换
            var bytes = urlEncoding.ToEncoding().GetBytes(source);
            var re = new StringBuilder();
            foreach (var @byte in bytes)
                re.Append(Uri.HexEscape((char)@byte)); //等价于： re.Append("%" + @byte.ToString("X2"));
            return re.ToString();
        }
    }
}