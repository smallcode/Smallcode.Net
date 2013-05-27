using System;
using System.Linq;
using System.Collections.ObjectModel;
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using Smallcode.Net.Extensions;

namespace Smallcode.Net
{
    public class Html
    {
        private Html(string html)
        {
            _htmlNode = html.ToHtmlNode();
        }

        internal protected Html(HtmlNode htmlNode)
        {
            _htmlNode = htmlNode;
        }

        public static Html Parse(string html)
        {
            return new Html(html);
        }

        private readonly HtmlNode _htmlNode;

        #region Html Members

        /// <summary>
        /// 获取属性
        /// </summary>
        /// <param name="attributeName">属性名</param>
        /// <returns>属性值</returns>
        public string GetAttribute(string attributeName)
        {
            return _htmlNode.GetAttributeValue(attributeName);
        }

        /// <summary>
        /// 通过下标访问属性
        /// </summary>
        /// <param name="attributeName">属性名</param>
        /// <returns>属性值</returns>
        public string this[string attributeName]
        {
            get { return GetAttribute(attributeName); }
        }

        /// <summary>
        /// 标签名称，如A标签，Div标签等
        /// </summary>
        public string TagName
        {
            get { return _htmlNode.Name; }
        }

        /// <summary>
        /// 文本，等同于InnerText
        /// </summary>
        public string Text
        {
            get { return _htmlNode.InnerText; }
        }

        /// <summary>
        /// Html文本，可更改
        /// </summary>
        public string InnerHtml
        {
            get { return _htmlNode.InnerHtml; }
            set { _htmlNode.InnerHtml = value; }
        }

        public string OuterHtml
        {
            get { return _htmlNode.OuterHtml; }
        }

        #endregion

        #region ISearchContext Members

        public Html FindElement(By by)
        {
            return by.FindElement(this);
        }

        public ReadOnlyCollection<Html> FindElements(By by)
        {
            return by.FindElements(this);
        }

        #endregion

        #region IFindsByLinkText Members

        internal Html FindElementByLinkText(string linkText)
        {
            return FindElementsByLinkText(linkText).FirstOrNoSuchElement(linkText);
        }

        internal ReadOnlyCollection<Html> FindElementsByLinkText(string linkText)
        {
            var results = _htmlNode.CssSelect("a").Where(h => h.InnerText == linkText).Select(htmlNode => new Html(htmlNode));
            return new ReadOnlyCollection<Html>(results.ToList());
        }

        #endregion

        #region IFindsById Members

        internal Html FindElementById(string id)
        {
            return FindElementByCssSelector(String.Format("#{0}", id));
        }

        internal ReadOnlyCollection<Html> FindElementsById(string id)
        {
            return FindElementsByCssSelector(String.Format("#{0}", id));
        }

        #endregion

        //#region IFindsByName Members

        //internal Html FindElementByName(string name)
        //{
        //    return FindElementsByName(name).FirstOrNoSuchElement(name);
        //}

        //internal ReadOnlyCollection<Html> FindElementsByName(string name)
        //{
        //    return FindElementsByCssSelector(String.Format("*[name='{0}']", name));
        //}

        //#endregion

        #region IFindsByTagName Members

        internal Html FindElementByTagName(string tagName)
        {
            return FindElementByCssSelector(tagName);
        }

        internal ReadOnlyCollection<Html> FindElementsByTagName(string tagName)
        {
            return FindElementsByCssSelector(tagName);
        }

        #endregion

        #region IFindsByClassName Members

        internal Html FindElementByClassName(string className)
        {
            return FindElementByCssSelector(String.Format(".{0}", className));
        }

        internal ReadOnlyCollection<Html> FindElementsByClassName(string className)
        {
            return FindElementsByCssSelector(String.Format(".{0}", className));
        }

        #endregion

        #region IFindsByXPath Members

        internal Html FindElementByXPath(string xpath)
        {
            return FindElementsByXPath(xpath).FirstOrNoSuchElement(xpath);
        }

        internal ReadOnlyCollection<Html> FindElementsByXPath(string xpath)
        {
            var collection = _htmlNode.SelectNodes(xpath);
            var results = collection
                .Select(htmlNode => new Html(htmlNode))
                .ToList();
            return new ReadOnlyCollection<Html>(results);
        }

        #endregion

        #region IFindsByPartialLinkText Members

        internal Html FindElementByPartialLinkText(string partialLinkText)
        {
            return FindElementsByPartialLinkText(partialLinkText).FirstOrNoSuchElement(partialLinkText);
        }

        internal ReadOnlyCollection<Html> FindElementsByPartialLinkText(string partialLinkText)
        {
            var results = _htmlNode.CssSelect("a").Where(h => h.InnerText.Contains(partialLinkText)).Select(htmlNode => new Html(htmlNode));
            return new ReadOnlyCollection<Html>(results.ToList());
        }

        #endregion

        #region IFindsByCssSelector Members

        internal Html FindElementByCssSelector(string cssSelector)
        {
            return FindElementsByCssSelector(cssSelector).FirstOrNoSuchElement(cssSelector);
        }

        internal ReadOnlyCollection<Html> FindElementsByCssSelector(string cssSelector)
        {
            var results = _htmlNode.CssSelect(cssSelector).Select(htmlNode => new Html(htmlNode)).ToList();
            return new ReadOnlyCollection<Html>(results.ToList());
        }

        #endregion
    }
}