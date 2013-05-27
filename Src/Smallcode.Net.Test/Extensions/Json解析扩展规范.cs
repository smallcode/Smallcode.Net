using System.Collections.Generic;
using Machine.Specifications;
using Smallcode.Net.Extensions;

namespace Smallcode.Net.Test.Extensions
{
    public class Ajax
    {
        public int Code { get; set; }
        public string Msg { get; set; }
        public string Style { get; set; }
        public Data Data { get; set; }
    }
    public class Data
    {
        public string Html { get; set; }
        public IList<Book> Bookes { get; set; }
    }
    public class Book
    {
        public string Name { get; set; }
    }
    [Tags("字符", "扩展")]
    public class Json解析扩展规范
    {
        public static string JsonString;
        public Establish Content = () =>
            {
                JsonString = @"{ code: '10000', msg: 'success', data:{html:'html',bookes:[{name:'book1'},{name:'book2'}]},""style"":""color: rgb(153, 153, 153);"" }";
            };
        public It 必须正确将字符串转换为jObject = () =>
            {
                var json = JsonString.ToJObject();
                json["code"].ShouldEqual(10000);
                json["msg"].ShouldEqual("success");
                json["style"].ShouldEqual("color: rgb(153, 153, 153);");
                json["data"]["bookes"][0]["name"].ShouldEqual("book1");
            };

        public It 必须正确将字符串转换为自定义类型 = () =>
        {
            var test = JsonString.ToJson<Ajax>();
            test.Code.ShouldEqual(10000);
            test.Msg.ShouldEqual("success");
            test.Style.ShouldEqual("color: rgb(153, 153, 153);");
            test.Data.Html.ShouldEqual("html");
            test.Data.Bookes.Count.ShouldEqual(2);
            test.Data.Bookes[0].Name.ShouldEqual("book1");
            test.Data.Bookes[1].Name.ShouldEqual("book2");
        };

    }
}