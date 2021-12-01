using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Html.Dom;

namespace ParseHtml.News
{
    public class NewsParser : IParser<List<News>>
    {
        private string textNews;
        public List<News> Parse(IHtmlDocument document)
        {
            List<News> result = new List<News>();
            var elements = document.QuerySelectorAll("ul")
                .First(item => item.ClassName != null && item.ClassName.Contains("items")).QuerySelectorAll("li");
            foreach (var element in elements)
            {
                string title = element.QuerySelector("h6").TextContent;
                string url = element.QuerySelectorAll("a")
                    .First(item => item.ClassName != null && item.ClassName.Contains("item")).GetAttribute("href");
                ParserWorker<string> parser = new ParserWorker<string>(new ArticleParser());
                parser.ParserSettings = new ArticleSettings(url);
                parser.OnNewData += ParserOnOnNewData;
                parser.Start();
                string text = textNews;
                result.Add(new News(title,text));
            }
            return result;
        }

        private void ParserOnOnNewData(object arg1, string arg2)
        {
            textNews = arg2;
        }
    }
}
