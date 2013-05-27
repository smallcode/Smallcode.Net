using Machine.Specifications;

namespace Smallcode.Net.Test.HttpRequest
{
    [Tags("Net")]
    public class UrlEncodeSpecification
    {
        public It 默认编码 = () =>
        {
            new FormData().Set("name", "名字").ToString().ShouldEqual("name=名字");
        };

        public It 正确编码None = () =>
        {
            new FormData().Set("name", "名字").Encoding(UrlEncoding.NONE).ToString().ShouldEqual("name=名字");
        };

        public It 正确编码Utf8 = () =>
        {
            new FormData().Set("name", "名字").Encoding(UrlEncoding.UTF8).ToString().ShouldEqual("name=%E5%90%8D%E5%AD%97");
        };

        public It 正确编码Gb2312 = () =>
            {
                new FormData().Set("name", "名字").Encoding(UrlEncoding.GB2312).ToString().ShouldEqual("name=%C3%FB%D7%D6");
            };

    }
}