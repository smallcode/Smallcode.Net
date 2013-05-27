using System.Security.Cryptography;
using System.Text;

namespace Smallcode.Net.Extensions
{
    /// <summary>
    ///     字符串加密
    /// </summary>
    public static partial class StringExtensions
    {
        /// <summary>
        ///     MD5加密方法，类似JS中的hex_md5加密方法
        /// </summary>
        public static string CalculateMd5Hash(this string source)
        {
            var sb = new StringBuilder();
            // step 1, calculate MD5 hash from source
            using (var md5 = MD5.Create())
            {
                var inputBytes = Encoding.ASCII.GetBytes(source);
                var hash = md5.ComputeHash(inputBytes);

                // step 2, convert byte array to hex string
                for (var i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
            }
            return sb.ToString();
        }
    }
}