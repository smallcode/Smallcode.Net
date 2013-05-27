using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Security.Permissions;
using Microsoft.Win32;

namespace Smallcode.Net.Extensions
{
    public static class UriExtensions
    {
        /// <summary>
        /// 用默认浏览器打开链接
        /// </summary>
        /// <param name="url">链接</param>
        /// <param name="isNewWindow">是否在新窗口中打开</param>
        [SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
        public static void OpenInBrower(this string url, bool isNewWindow = false)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new UriFormatException("链接为空");
            }
            try
            {
                var key = Registry.ClassesRoot.OpenSubKey(@"http\shell\open\command", false);
                if (key == null) throw new NullReferenceException("找不到默认的浏览器"); ;
                var defaultBrowserPath = ((string)key.GetValue(null, null)).Split('"')[1];
                var info = new ProcessStartInfo(defaultBrowserPath, url);
                if (isNewWindow)
                {
                    using (var process = new Process())
                    {
                        process.StartInfo = info;
                        process.Start();
                    }
                }
                else
                    Process.Start(info);
                //打开特定浏览器的方法：System.Diagnostics.Process.Start(@"D:\Program Files\360\360se3\360se.exe", url);
            }
            catch (Win32Exception)
            {
                //System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo("IExplore.exe", sUrl);   
                Process.Start(url);
            }
        }

        public static HttpWebRequest CreateRequest(this Uri uri)
        {
            var request = ((HttpWebRequest)WebRequest.Create(uri));
            //取消100-Continue请求头，速度提升5~20倍左右(根据淘宝API记载),只对POST有效
            request.ServicePoint.Expect100Continue = false;
            //是否使用 Nagle 不使用 提高效率
            request.ServicePoint.UseNagleAlgorithm = false;
            //网络连接并发数量，修改后速度有质的提升
            request.ServicePoint.ConnectionLimit = 65500;
            //数据是否缓冲 false 提高效率 
            request.AllowWriteStreamBuffering = false;
            //request.Proxy = null;
            //request.KeepAlive = false;
            return request.WithUserAgent().SetAcceptEncoding();
        }
    }
}