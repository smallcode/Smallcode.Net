using Machine.Specifications;

namespace Smallcode.Net.Test.HttpRequest
{
    [Tags("Net")]
    public class FormDataSpecification
    {
        public static FormData Data;

        public Establish Content = () =>
            {
                Data = new FormData();
            };

        public Because Of =
            () => Data.Set("foo", "ball")
                      .Set("int", 1)
                      .Set("long", 5786724301)
                      .SetZero("zero")
                      .SetTrue("true")
                      .SetFalse("false")
                      .SetEmpty("empty")
                      .Set(string.Empty, "none");

        public It 必须获得字符串 =
            () => { Data.ToString().ShouldEqual("foo=ball&int=1&long=5786724301&zero=0&true=1&false=0&empty=&none"); };

        public It 长度必须正确 = () => { Data.Count.ShouldEqual(8); };

        public It 可以重复设置key = () => { new FormData().Set("key", "value").Set("key", "value").Count.ShouldEqual(1); };

        public It 可以设置随机整数 = () => { new FormData().SetRandomInteger("key", 8)["key"].Length.ShouldEqual(8); };

        public It 可以设置随机小数 = () =>
            {
                var data = new FormData().SetRandomFloat("key", 8)["key"];
                data.ShouldStartWith("0.");
                data.Length.ShouldEqual(10);
            };

        public It 可以设置随机Unix时间戳 = () => { new FormData().SetUnixTimestamp("key", 8)["key"].Length.ShouldEqual(8); };
    }
}