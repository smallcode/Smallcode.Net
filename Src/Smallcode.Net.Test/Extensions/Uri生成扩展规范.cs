using System;
using Machine.Specifications;
using Smallcode.Net.Extensions;

namespace Smallcode.Net.Test.Extensions
{
    [Tags("字符", "扩展")]
    public class Uri生成扩展规范
    {
        public It 必须正确获取绝对地址 =
            () => "/b.php".MakeAbsoluteUri(HttpWwwBaiduComAPhp).ShouldEqual(HttpWwwBaiduComBPhp);

        public It 必须正确由Uri获取绝对地址 =
            () => "/b.php".MakeAbsoluteUri(new Uri(HttpWwwBaiduComAPhp))
                          .ShouldEqual(HttpWwwBaiduComBPhp);

        public static string HttpWwwBaiduComAPhp = "http://www.baidu.com/a.php";
        public static string HttpWwwBaiduComBPhp = "http://www.baidu.com/b.php";
    }
}