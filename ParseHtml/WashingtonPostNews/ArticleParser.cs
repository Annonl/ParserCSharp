using AngleSharp.Html.Dom;
using System.Linq;

namespace ParseHtml.WashingtonPostNews
{
    class ArticleParser : IParser<string>
    {
        public string Parse(IHtmlDocument document)
        {
            return document.GetElementsByClassName("entry-content").First().TextContent;
        }
    }
}
