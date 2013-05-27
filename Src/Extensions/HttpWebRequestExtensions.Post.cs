using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;

namespace Smallcode.Net.Extensions
{
    public static partial class HttpWebRequestExtensions
    {
        public static string Post(this HttpWebRequest request)
        {
            request.AllowWriteStreamBuffering = true; //这里需设置，否则会有异常
            return request
                .Method(HttpWebRequestMethod.POST)
                .GetResponseString();
        }

        /// <summary>
        ///     提交表单
        /// </summary>
        /// <param name="request">请求对象</param>
        /// <param name="formData">表单数据</param>
        /// <returns>响应文本</returns>
        public static string Post(this HttpWebRequest request, FormData formData)
        {
            return request
                .Method(HttpWebRequestMethod.POST)
                .SetContentType("application/x-www-form-urlencoded;charset=utf-8")
                .Write(formData)
                .GetResponseString();
        }

        /// <summary>
        ///     提交表单和文件
        /// </summary>
        /// <param name="request">请求对象</param>
        /// <param name="formData">表单数据</param>
        /// <param name="files">文件</param>
        /// <returns>响应文本</returns>
        public static string Post(this HttpWebRequest request, FormData formData,
                                  IDictionary<string, FileItem> files)
        {
            // 随机分隔线
            var boundary = DateTime.Now.Ticks.ToString("X");
            return request
                .Method(HttpWebRequestMethod.POST)
                .SetContentType("multipart/form-data; boundary=" + boundary)
                .Write(formData, files, boundary)
                .GetResponseString();
        }

        /// <summary>
        ///     提交文件
        /// </summary>
        /// <param name="request">请求对象</param>
        /// <param name="fileItem">文件</param>
        /// <returns>响应文本</returns>
        public static string Post(this HttpWebRequest request, FileItem fileItem)
        {
            return request
                .Method(HttpWebRequestMethod.POST)
                .SetContentType("application/octet-stream")
                .Write(fileItem.GetContent())
                .GetResponseString();
        }

        /// <summary>
        ///     写入提交数据
        /// </summary>
        private static HttpWebRequest Write(this HttpWebRequest request, byte[] postData)
        {
            request.ContentLength = postData.Length;
            using (var stream = request.GetRequestStream())
                stream.Write(postData, 0, postData.Length);
            return request;
        }

        /// <summary>
        ///     写入提交数据
        /// </summary>
        private static HttpWebRequest Write(this HttpWebRequest request, FormData formData)
        {
            if (formData.Count > 0)
            {
                //var formDataString = formData.GetFormDataString();
                request.Write(Encoding.UTF8.GetBytes(formData.ToString()));
#if DEBUG
                request.ShowDebugInfo();
                Debug.WriteLine("Form Data:");
                var i = 0;
                foreach (var data in formData)
                {
                    Debug.WriteLine("[{0,-2}] {1,-15} : {2}", ++i, data.Key, data.Value);
                }
#endif
            }
            return request;
        }

        /// <summary>
        ///     写入提交数据
        /// </summary>
        private static HttpWebRequest Write(this HttpWebRequest request,
                                            Dictionary<string, string> formData,
                                            IEnumerable<KeyValuePair<string, FileItem>> files, string boundary)
        {
            request.SendChunked = true; //分段发送数据，尚未经过检验，不知是否有效
            using (var stream = request.GetRequestStream())
            {
                var boundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "\r\n");
                // 组装文本请求参数
                var textPairs = formData.GetEnumerator();
                while (textPairs.MoveNext())
                {
                    var itemBytes =
                        Encoding.UTF8.GetBytes(
                            string.Format(
                                "Content-Disposition:form-data;name=\"{0}\"\r\nContent-Type:text/plain\r\n\r\n{1}",
                                textPairs.Current.Key, textPairs.Current.Value));
                    stream.Write(boundaryBytes, 0, boundaryBytes.Length);
                    stream.Write(itemBytes, 0, itemBytes.Length);
                }

                // 组装文件请求参数
                var filePairs = files.GetEnumerator();
                while (filePairs.MoveNext())
                {
                    var fileItem = filePairs.Current.Value;
                    var itemBytes =
                        Encoding.UTF8.GetBytes(
                            string.Format(
                                "Content-Disposition:form-data;name=\"{0}\";filename=\"{1}\"\r\nContent-Type:{2}\r\n\r\n",
                                filePairs.Current.Key, fileItem.GetFileName(), fileItem.GetMimeType()));
                    stream.Write(boundaryBytes, 0, boundaryBytes.Length);
                    stream.Write(itemBytes, 0, itemBytes.Length);

                    var fileBytes = fileItem.GetContent();
                    stream.Write(fileBytes, 0, fileBytes.Length);
                }
                // 组装尾部
                var endBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");
                stream.Write(endBoundaryBytes, 0, endBoundaryBytes.Length);
            }
            return request;
        }
    }
}