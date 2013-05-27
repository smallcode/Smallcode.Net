using Machine.Specifications;
using Smallcode.Net.Extensions;

namespace Smallcode.Net.Test.Extensions
{
    [Tags("字符", "扩展")]
    public class 其他扩展规范
    {
        public It 必须正确截取字符串 = () =>
            {
                "you are the best one".CutString("are", "best").ShouldEqual("the");
                "you the best one".CutString("are", "best").ShouldBeEmpty();
                "you are the one".CutString("are", "best").ShouldBeEmpty();
                "you the one".CutString("are", "best").ShouldBeEmpty();

                "you are the best one".CutString("you", "one", true, true).ShouldEqual("you are the best one");
                "you are the best one".CutString("you", "one", false, true).ShouldEqual("are the best one");
                "you are the best one".CutString("you", "one").ShouldEqual("are the best");
            };

        public It 必须正确判断是否为数字 = () =>
            {
                "187".IsNumberic().ShouldBeTrue();
                "&#187;".IsNumberic().ShouldBeFalse();
            };

        //public It 必须正确计算字符串长度 = () =>
        //    {
        //        "我".HalfOfByteCount().ShouldEqual(1);
        //        "我我".HalfOfByteCount().ShouldEqual(2);
        //        "aa".HalfOfByteCount().ShouldEqual(1);
        //        "aaa".HalfOfByteCount().ShouldEqual(2);
        //        "。".HalfOfByteCount().ShouldEqual(1);
        //        "..".HalfOfByteCount().ShouldEqual(1);
        //    };
    }
}