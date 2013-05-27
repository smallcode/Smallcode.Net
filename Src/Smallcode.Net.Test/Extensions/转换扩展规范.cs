using Machine.Specifications;
using Smallcode.Net.Extensions;

namespace Smallcode.Net.Test.Extensions
{
    [Tags("字符", "扩展")]
    public class 转换扩展规范
    {
        public It 必须正确将字符串转换为字典形式 = () =>
            {
                const string input = @" ?a=1&c=&b=""2""&";
                var dic = input.ToDictionary();
                dic["a"].ShouldEqual("1");
                dic["b"].ShouldEqual("2");
                dic["c"].ShouldEqual("");
            };

        //public It 必须正确将字符串转换为json = () =>
        //    {
        //        var json =
        //            "{ plugin: 'jquery-json', version: 2.4, bookes:[{name:'book1'},{name:'book2'}] }".ToJsonObject();
        //        json["version"].Value.ShouldEqual("2.4");
        //        json["bookes"][0]["name"].Value.ShouldEqual("book1");
        //    };

        //public It 必须正确解析Json字符串中的值 = () =>
        //    {
        //        const string json =
        //            @"{ plugin: 'jquery-json', version: 2.4, bookes:[{name:'book1'},{name:'book2'}],""html"":""content"", ""style"":""color: rgb(153, 153, 153);"" }";
        //        string plugin;
        //        string html;
        //        string version;
        //        json.TryGetJsonValue("plugin", out plugin).ShouldBeTrue();
        //        json.TryGetJsonValue("version", out version).ShouldBeTrue();
        //        json.TryGetJsonValue("html", out html).ShouldBeTrue();
        //        plugin.ShouldEqual("jquery-json");
        //        version.ShouldEqual("2.4");
        //        html.ShouldEqual("content");

        //        json.GetJsonValue("plugin").ShouldEqual("jquery-json");
        //        json.GetJsonValue("version").ShouldEqual("2.4");
        //        json.GetJsonValue("html").ShouldEqual("content");
        //        json.GetJsonValue("style").ShouldEqual("color: rgb(153, 153, 153);");
        //    };

        public It 必须正确解析Url字符串中的值 = () =>
            {
                const string input = @" ?a=1&c=&b=""2""&";
                string a;
                string b;
                string c;
                input.TryGetUrlValue("a", out a).ShouldBeTrue();
                input.TryGetUrlValue("b", out b).ShouldBeTrue();
                input.TryGetUrlValue("c", out c).ShouldBeTrue();
                a.ShouldEqual("1");
                b.ShouldEqual("2");
                c.ShouldEqual("");

                input.GetUrlValue("a").ShouldEqual("1");
                input.GetUrlValue("b").ShouldEqual("2");
                input.GetUrlValue("c").ShouldEqual("");
            };

        public It 必须正确转换为数字 = () =>
            {
                "123".ToInt().ShouldEqual(123);
            };
    }
}