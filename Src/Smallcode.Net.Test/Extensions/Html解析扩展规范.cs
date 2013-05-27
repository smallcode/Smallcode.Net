using System;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using Machine.Specifications;
using Smallcode.Net.Exceptions;

namespace Smallcode.Net.Test.Extensions
{
    [Tags("字符", "扩展")]
    public class Html解析扩展规范
    {
        public static Html EmptyHtml;
        public static Html Html;
        public Establish Content = () =>
            {
                EmptyHtml = Html.Parse(string.Empty);
                Html = Html.Parse("<div class=\"class\" id=\"id\" name=\"name\"><a href=\"http://www.test.com\">click me</a></div><div class=\"class other\" id=\"other\"><a href=\"http://www.test1.com\">click me</a></div>");
            };

        #region 单节点
        public It 无法解析时能抛出异常 = () => Catch.Exception(() => EmptyHtml.FindElement(By.CssSelector("div"))).ShouldBeOfType<NotFoundException>();

        public It 必须能用TagName解析 = () => Html.FindElement(By.TagName("div")).ShouldMatch(ConditionId());

        public It 必须能用id解析 = () => Html.FindElement(By.Id("id")).ShouldMatch(ConditionId());

        public It 必须能用ClassName解析 = () => Html.FindElement(By.ClassName("class")).ShouldMatch(ConditionId());

        public It 必须能用xPath解析 = () => Html.FindElement(By.XPath("//div")).ShouldMatch(ConditionId());

        public It 必须能用LinkText解析 = () => Html.FindElement(By.LinkText("click me")).ShouldMatch(ConditionHref());

        public It 必须能用PartialLinkText解析 = () => Html.FindElement(By.PartialLinkText("click")).ShouldMatch(ConditionHref());

        public It 必须能用Css解析 = () =>
            {
                Html.FindElement(By.CssSelector(".class")).ShouldMatch(ConditionId());
                Html.FindElement(By.CssSelector("#id")).ShouldMatch(ConditionId());
                Html.FindElement(By.CssSelector("div")).ShouldMatch(ConditionId());
                Html.FindElement(By.CssSelector("div.class")).ShouldMatch(ConditionId());
                Html.FindElement(By.CssSelector("div#id")).ShouldMatch(ConditionId());
                Html.FindElement(By.CssSelector("div.class.other")).ShouldMatch(h => h.GetAttribute("id") == "other");//必须同时匹配两个class
                Html.FindElement(By.CssSelector("div#other.other")).ShouldMatch(h => h.GetAttribute("id") == "other");//必须同时匹配id和class
                Html.FindElement(By.CssSelector("div.class > a")).ShouldMatch(ConditionHref());//选择div.class的直接子标签a
                Html.FindElement(By.CssSelector("div[name=name].class")).ShouldMatch(ConditionId());//必须同时匹配属性name和类class
            };
        #endregion

        #region 多节点
        public It 无法解析集合时返回空集合 = () => EmptyHtml.FindElements(By.CssSelector("div")).Count.ShouldEqual(0);

        public It 必须能用TagName解析集合 = () => Html.FindElements(By.TagName("div")).ShouldMatch(ConditionIds());

        public It 必须能用ClassName解析集合 = () => Html.FindElements(By.ClassName("class")).ShouldMatch(ConditionIds());

        public It 必须能用xPath解析集合 = () => Html.FindElements(By.XPath("//div")).ShouldMatch(ConditionIds());

        public It 必须能用LinkText解析集合 = () => Html.FindElements(By.LinkText("click me")).ShouldMatch(ConditionHrefs());

        public It 必须能用PartialLinkText解析集合 = () => Html.FindElements(By.PartialLinkText("click")).ShouldMatch(ConditionHrefs());

        public It 必须能用Css解析集合 = () =>
        {
            Html.FindElements(By.CssSelector("div")).ShouldMatch(ConditionIds());
            Html.FindElements(By.CssSelector("div.class")).ShouldMatch(ConditionIds());
        };
        #endregion

        private static Expression<Func<Html, bool>> ConditionId()
        {
            return h => h["class"] == "class" && h["id"] == "id" && h["name"] == "name"; ;
        }

        private static Expression<Func<ReadOnlyCollection<Html>, bool>> ConditionIds()
        {
            return list => list.Count == 2 && list[0].GetAttribute("id") == "id" && list[1].GetAttribute("id") == "other";
        }

        private static Expression<Func<Html, bool>> ConditionHref()
        {
            return h => h.GetAttribute("href") == "http://www.test.com";
        }

        private static Expression<Func<ReadOnlyCollection<Html>, bool>> ConditionHrefs()
        {
            return list => list.Count == 2 && list[0].GetAttribute("href") == "http://www.test.com" && list[1].GetAttribute("href") == "http://www.test1.com";
        }

    }
}