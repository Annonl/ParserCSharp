using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Html.Dom;

namespace ParseHtml.ArticleYandex
{
    class ArticleParser : IParser<string>
    {
        public string Parse(IHtmlDocument document)
        {
            var elements = document.GetElementsByClassName("ZBQJP");
            StringBuilder result = new StringBuilder();
            foreach (var element in elements)
            {
                result.Append(element.TextContent);
            }

            return result.ToString();
        }
    }
}
