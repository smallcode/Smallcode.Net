using Machine.Specifications;
using Smallcode.Net.Extensions;

namespace Smallcode.Net.Test.Extensions
{
    [Tags("字符", "扩展")]
    public class 解码扩展规范
    {
        public It 必须正确解码Url转义字符 = () => { "%E6%88%AA%E5%8F%96".UrlUnescape().ShouldEqual("截取"); };

        public It 必须正确解码转义字符 = () => { @"\u624b\u673a".UUnescape().ShouldEqual("手机"); };

        public It 必须正确解码html转义字符 = () =>
            {
                "&#187;".HtmlDecode().ShouldEqual("»");
                "&#187".HtmlDecode().ShouldEqual("&#187");
            };
    }
}