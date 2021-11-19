using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Html.Dom;

namespace ParseHtml.Book
{
    class ReviewParser :IParser<string>
    {
        public string Id { get; set; }     
        public ReviewParser(string idComents)
        {
            Id = idComents;
        }
        public string Parse(IHtmlDocument document)
        {
            var d = document.QuerySelectorAll("div")
                .First(item => item.Id != null && item.Id.Contains(Id));
            return d
                .QuerySelectorAll("div")
                .First(item => item.ClassName != null && item.ClassName.Contains("comment-content")).TextContent;
        }
    }
}
