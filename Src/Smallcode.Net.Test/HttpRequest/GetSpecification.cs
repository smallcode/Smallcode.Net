using System.Net;
using Machine.Specifications;
using Smallcode.Net.Extensions;

namespace Smallcode.Net.Test.HttpRequest
{
    [Tags("Net")]
    public class GetSpecification : RequestSpecification
    {
        public Establish Content = () =>
        {
            Request = new Url(UriString).CreateRequest();
            Request.Get();
        };
        public It Method为Get = () =>
            {
                Request.Method.ShouldEqual(HttpWebRequestMethod.GET.ToString());
            };

        public It 能获取gzip压缩格式的网页 =
            () => new Url("http://www.sina.com").CreateRequest().GetHttpResponse().ContentEncoding.ShouldEqual("gzip");

        public It 能访问新浪 = () => new Url("http://www.sina.com").CreateRequest().Get().ShouldContain("新浪");
        public It 能访问淘宝 = () =>
            {
                const string url = "http://www.taobao.com/";
                var cookie = new CookieContainer();
                var request = new Url(url).CreateRequest().WithCookies(cookie);
                var result = request.Get();//第一次获取可能会返回跳转页，需再次获取
                if (!result.Contains("淘宝"))
                {
                    result = new Url(url).CreateRequest().WithCookies(cookie).Get();
                }
                result.ShouldContain("淘宝");
            };
        public It 能访问网易 = () => new Url("http://www.163.com").CreateRequest().Get().ShouldContain("网易");
        public It 能访问搜狐 = () => new Url("http://www.sohu.com").CreateRequest().Get().ShouldContain("搜狐");
        public It 能访问百度 = () => new Url("http://www.baidu.com").CreateRequest().Get().ShouldContain("百度");
        public It 能访问QQ空间 = () => new Url("http://i.qq.com").CreateRequest().Get().ShouldContain("QQ空间");

        public It 能获取字节数组 =
            () => new Url("http://login.sina.com.cn/cgi/pin.php").CreateRequest()
                                .GetBytes()
                                .Length.ShouldBeGreaterThan(0);

        public It 能获取跳转地址 = () => new Url("http://www.google.com").CreateRequest().NotRedirect().Get().ShouldStartWith("http://www.google.com.hk/url");

    }
}