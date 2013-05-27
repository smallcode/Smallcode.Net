using Machine.Specifications;
using Smallcode.Net.Extensions;

namespace Smallcode.Net.Test.Extensions
{
    [Tags("字符", "扩展")]
    public class 加密扩展规范
    {
        public It 必须正确加密md5 = () => { "ABCD1234".CalculateMd5Hash().ShouldEqual("361633153A464830A1FE85DEC5EFAB17"); };
    }
}