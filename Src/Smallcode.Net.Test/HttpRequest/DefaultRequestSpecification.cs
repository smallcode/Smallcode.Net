using System.Net;
using Machine.Specifications;
using Smallcode.Net.Extensions;

namespace Smallcode.Net.Test.HttpRequest
{
    [Tags("Net")]
    public class DefaultRequestSpecification : RequestSpecification
    {
        public Because Of = () => { Request = new Url(UriString).CreateRequest(); };

        public It 能正确设置Method = () => Request.Method.ToUpper().ShouldEqual("GET");
        public It 能正确设置Uri = () => Request.RequestUri.ToString().ShouldEqual(UriString);
        public It 能正确设置UserAgent = () => Request.UserAgent.ShouldEqual(HttpWebRequestUserAgent.IE);

        public It 能正确设置AcceptEncoding =
            () => Request.Headers[HttpRequestHeader.AcceptEncoding].ShouldEqual("gzip,deflate");

        public It 能正确设置Referer = () => Request.Referer.ShouldBeNull();
        public It Cookies为null = () => Request.CookieContainer.ShouldBeNull();
        public It 设置Cookie时会抛出异常 = () => Catch.Exception(() => Request.SetCookie("foo", "bar")).ShouldBeOfType<CookieException>();
        public It 获取Cookie时会抛出异常 = () => Catch.Exception(() => Request.SetCookie("foo", "bar")).ShouldBeOfType<CookieException>();
        public It 能正确设置AllowAutoRedirect = () => Request.AllowAutoRedirect.ShouldBeTrue();
    }
}