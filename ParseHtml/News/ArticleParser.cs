using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;

namespace ParseHtml.News
{
    class ArticleParser : IParser<string>
    {
        public string Parse(IHtmlDocument document)
        {
            StringBuilder result = new StringBuilder();
            var elements = document.QuerySelectorAll("p");
            foreach (var childNode in elements)
            {
                result.AppendLine(childNode.TextContent);
            }
            return result.ToString(); //document.QuerySelectorAll("div")
            // .First(item => item.ClassName != null && item.ClassName.Contains("content")).TextContent;
        }
    }
}
