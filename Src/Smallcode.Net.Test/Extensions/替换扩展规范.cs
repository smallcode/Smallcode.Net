using Machine.Specifications;
using Smallcode.Net.Extensions;

namespace Smallcode.Net.Test.Extensions
{
    [Tags("字符", "扩展")]
    public class 替换扩展规范
    {
        public It 必须正确清除或替换空字符 = () =>
            {
                @"   hello   
            world  ".ReplaceBlankSpaces().ShouldEqual("hello world");

                @"   hello   
            world  ".ReplaceBlankSpaces("").ShouldEqual("helloworld");
            };

        public It 必须正确清除或替换换行 = () =>
            {
                @"\r\n hello \r\n world \r\n".RepalceLine().ShouldEqual(" hello  world ");
                @"hello\r\nworld".RepalceLine("").ShouldEqual("helloworld");
            };

        public It 必须正确清除或替换所有网址格式 = () =>
            {
                @"hello http://www.baidu.com world".RepalceUrl().ShouldEqual("hello world");
                @"hello http://www.baidu.com world".RepalceUrl("the").ShouldEqual("hello the world");
            };

        public It 必须正确清除或替换a标签中的href属性 =
            () => { @"<a href=""http://www.baidu.com"">baidu</a>".ReplaceHref().ShouldEqual("<a >baidu</a>"); };

        public It 必须正确清除或替换所有html标签 =
            () => { @"<a href=""http://www.baidu.com"">baidu</a>".ClearHtmlTags().ShouldEqual("baidu"); };

        public It 必须正确清除转义字符 = () =>
            {
                var str = @"<a class=\""hi\""><\/a>";
                str.ClearEscape().ShouldEqual(@"<a class=""hi""></a>");
            };

        public It 必须正确替换匹配项 =
            () => { "......aa11我我.....".RegexReplace(@"(\W)\1+", "$1").ShouldEqual(".aa11我我."); //替换掉连续相同的非字符（即符号之类的）
            };
    }
}