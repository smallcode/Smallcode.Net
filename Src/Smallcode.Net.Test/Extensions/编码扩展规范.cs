using Machine.Specifications;
using Smallcode.Net.Extensions;

namespace Smallcode.Net.Test.Extensions
{
    [Tags("字符", "扩展")]
    public class 编码扩展规范
    {
        public static string Words;

        public Establish Content
            = () =>
                {
                    Words = @"123abcABC,.!";
                };
        public It 正确获取经gbk编码的字符串 = () =>
            {
                @"1我a".EscapeDataStringBy().ShouldEqual("%31%CE%D2%61");
                Words.EscapeDataStringBy().ShouldEqual(Words);
            };

        public It 正确获取经Utf8编码的字符串 =
            () =>
            {
                Words.EscapeDataStringBy(UrlEncoding.UTF8).ShouldEqual(Words);
                @"玉树临风杀猪刀".EscapeDataStringBy(UrlEncoding.UTF8)
                          .ShouldEqual("%E7%8E%89%E6%A0%91%E4%B8%B4%E9%A3%8E%E6%9D%80%E7%8C%AA%E5%88%80");
            };
    }
}