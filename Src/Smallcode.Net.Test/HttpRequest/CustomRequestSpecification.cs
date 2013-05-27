using System.Net;
using Machine.Specifications;
using Smallcode.Net.Extensions;

namespace Smallcode.Net.Test.HttpRequest
{
    [Tags("Net")]
    public class CustomRequestSpecification : RequestSpecification
    {
        public static CookieContainer Cookie;
        public static string Referer;
        public static string UserAgent;
        public static string AcceptEncoding;
        public static Url Url;

        public Establish Content = () =>
            {
                Referer = "http://weibo.com";
                UserAgent =
                    "Mozilla/5.0 (Windows NT 5.1) AppleWebKit/537.1 (KHTML, like Gecko) Chrome/21.0.1180.89 Safari/537.1";
                AcceptEncoding = "gizp";
                Cookie = new CookieContainer();
                Url = new Url(UriString).Append("foo", "bar");
            };

        public Because Of = () =>
            {
                Request = Url.CreateRequest()
                                        .WithCookies(Cookie)
                                        .WithReferer(Referer)
                                        .WithUserAgent(UserAgent)
                                        .SetAcceptEncoding(AcceptEncoding)
                                        .NotRedirect()
                                        .ByAjax();
            };

        public It 能正确设置Uri = () => Request.RequestUri.ToString().ShouldEqual(Url.ToString());
        public It 能正确设置Referer = () => Request.Referer.ShouldEqual(Referer);
        public It 能正确设置UserAgent = () => Request.UserAgent.ShouldEqual(UserAgent);
        public It 能正确设置Cookies = () => Request.CookieContainer.ShouldEqual(Cookie);
        public It 可以设置和获取Cookie = () => Request.SetCookie("foo", "bar").GetCookie("foo").ShouldEqual("bar");
        public It 能正确设置Ajax = () => Request.Headers["X-Requested-With"].ShouldEqual("XMLHttpRequest");

        public It 能正确设置AcceptEncoding =
            () => Request.Headers[HttpRequestHeader.AcceptEncoding].ShouldEqual(AcceptEncoding);

        public It 能正确设置AllowAutoRedirect = () => Request.AllowAutoRedirect.ShouldBeFalse();
    }
}