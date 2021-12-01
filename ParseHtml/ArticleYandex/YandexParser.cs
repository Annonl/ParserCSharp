using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;

namespace ParseHtml.ArticleYandex
{
    public class YandexParser : IParser<List<Article>>
    {
        private string text;
        public List<Article> Parse(IHtmlDocument document)
        {
            List<Article> result = new List<Article>();
            var elements = document.GetElementsByClassName("pHw5W").First().QuerySelectorAll("div");
            foreach (var element in elements)
            {
                string title = element.GetAttribute("data-zone-data");
                Regex regex = new Regex("(?<=\"materialTitle\":\")(.*)(?=\"})");
                MatchCollection matchCollection = regex.Matches(title);
                title = matchCollection.First().Value;
                string url = element.GetElementsByClassName("_2qvOO").Attr("href").First();
                ParserWorker<string> parser = new ParserWorker<string>(new ArticleParser());
                parser.ParserSettings = new ArticleSettings(url);
                parser.OnNewData += ParserOnOnNewData;
                parser.Start();
                string textArticle = text;
                result.Add(new Article(title,textArticle));
            }
            return result;
        }

        private void ParserOnOnNewData(object arg1, string arg2)
        {
            text = arg2;
        }
    }
}
