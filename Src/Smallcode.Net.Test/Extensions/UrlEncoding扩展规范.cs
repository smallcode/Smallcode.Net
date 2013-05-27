using System.Text;
using Machine.Specifications;
using Smallcode.Net.Extensions;

namespace Smallcode.Net.Test.Extensions
{
    [Tags("字符", "扩展")]
    public class UrlEncoding扩展规范
    {
        public It 能获取Gb2312编码 =
            () => UrlEncoding.GB2312.ToEncoding().ShouldEqual(Encoding.GetEncoding("gb2312"));
        public It 能获取Utf8编码 =
            () => UrlEncoding.UTF8.ToEncoding().ShouldEqual(Encoding.UTF8);
        public It 能获取默认编码 =
            () => UrlEncoding.NONE.ToEncoding().ShouldEqual(Encoding.Default);

        public It Gb2312编码和gbk编码是相同的 =
            () => (Encoding.GetEncoding("gb2312").Equals(Encoding.GetEncoding("gbk"))).ShouldBeTrue();

    }
}