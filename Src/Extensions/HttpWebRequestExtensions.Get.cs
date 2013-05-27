using System;
using System.Net;

namespace Smallcode.Net.Extensions
{
    public static partial class HttpWebRequestExtensions
    {
        /// <summary>
        ///     获取文本形式的Get响应体
        /// </summary>
        /// <param name="request">请求对象</param>
        /// <returns>响应文本</returns>
        public static string Get(this HttpWebRequest request)
        {
            return request
                .Method(HttpWebRequestMethod.GET)
                .GetResponseString();
        }

        /// <summary>
        ///     获取字节数组形式的Get响应体
        /// </summary>
        /// <param name="request">请求对象</param>
        /// <returns>字节数组</returns>
        public static byte[] GetBytes(this HttpWebRequest request)
        {
            using (var response = request.Method(HttpWebRequestMethod.GET).GetHttpResponse())
            {
                return response.GetBytes();
            }
        }
    }
}