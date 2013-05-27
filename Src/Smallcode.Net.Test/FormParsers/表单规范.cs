using System;
using System.Net;
using Machine.Specifications;

namespace Smallcode.Net.Test.FormParsers
{
    public class 表单规范
    {
        protected static FormParser Form;
        protected static string Html;
        protected static HttpWebRequest Request;
        protected static Uri BaseUri;

        public Establish 初始化Request =
            () =>
            {
                BaseUri = new Uri("https://login.sina.com.cn/signup/signup.php");
            };

    }
}