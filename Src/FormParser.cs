using System;
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using Smallcode.Net.Extensions;

namespace Smallcode.Net
{
    public class FormParser
    {
        private readonly HtmlNode _form;

        public FormParser(string html)
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            _form = htmlDocument.DocumentNode.SelectSingleNode("//form[1]");
            if (_form == null) throw new Exception("在HTML源代码中找不到Form标签");
        }

        public FormData FormData
        {
            get
            {
                var data = new FormData();
                var nodes = _form.SelectNodes("//input[@type!='submit'] | //input[@type!='button'] | //select | //textarea");
                if (nodes == null) return data;
                foreach (var node in nodes)
                {
                    var name = node.GetAttributeValue("name");
                    if (!(string.IsNullOrWhiteSpace(name) || data.ContainsKey(name)))
                        data.Set(name, node.GetAttributeValue("value", ""));
                }
                return data;
            }
        }

        public string GetAction(Uri baseUri)
        {
            return _form.GetAttributeValue("action", "").MakeAbsoluteUri(baseUri);
        }

        public string GetImageUrl(Uri baseUri, string xPath)
        {
            var img = _form.SelectSingleNode(xPath);
            return img != null ? img.GetAttributeValue("src").MakeAbsoluteUri(baseUri) : string.Empty;
        }
    }
}