using Machine.Specifications;
using Smallcode.Net.Extensions;

namespace Smallcode.Net.Test.Extensions
{
    [Tags("Uri", "扩展"), Ignore("需要打开浏览器")]
    public class Uri扩展规范
    {
        public It 能在浏览器中打开链接 = () => "http://www.baidu.com/".OpenInBrower();
    }
}