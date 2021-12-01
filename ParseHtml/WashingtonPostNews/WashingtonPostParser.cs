using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom;

namespace ParseHtml.WashingtonPostNews
{
   public class WashingtonPostParser : IParser<List<News.News>>
    {
        private string text;
        public List<News.News> Parse(IHtmlDocument document)
        {
            List<News.News> result = new List<News.News>();
            var elements = document.GetElementsByClassName("post-item");
            foreach (var element in elements)
            {
                string title = element.QuerySelectorAll("h2")
                    .First(item => item.ClassName != null && item.ClassName.Contains("post-title")).TextContent;
                string url = element.GetElementsByClassName("post-title").First().QuerySelectorAll("a").Attr("href")
                    .First();
                url = url.Replace("../", "");
                ParserWorker<string> parser = new ParserWorker<string>(new ArticleParser());
                parser.ParserSettings = new ArticleSettings(url);
                parser.OnNewData += ParserOnOnNewData;
                parser.Start();
                string textNews = text;
                result.Add(new News.News(title, textNews));
            }
            return result;
        }

        private void ParserOnOnNewData(object arg1, string arg2)
        {
            text = arg2;
        }
    }
}
