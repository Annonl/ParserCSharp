using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;

namespace ParseHtml.Book
{
    public class BookParser : IParser<List<ReviewBook>>
    {
        public List<ReviewBook> Parse(IHtmlDocument document)
        {
            var reviews = document.QuerySelectorAll("div")
                .Where(item => item.ClassName != null && item.ClassName.Contains("col-12"));
            var result = new List<ReviewBook>();
            foreach (var review in reviews)
            {
                if (!review
                    .QuerySelectorAll("div").HasClass("box-bd notice") && !review
                    .QuerySelectorAll("div").HasClass("box-page-pagination"))
                {
                    int grade = GetGrade(review);
                    string nameBook = GetNameBook(review);
                    string author = GetNameAuthor(review);
                    string rev = GetReviewText(review);
                    string authorReview = GetAuthorReview(review);
                    result.Add(new ReviewBook()
                    {
                        BookAuthor = author,
                        Grade = grade,
                        NameBook = nameBook,
                        Review = rev,
                        ReviewerName = authorReview
                    });
                }
            }
            return result;
        }

        private string GetAuthorReview(IElement review)
        {
            var nameAuthorReviewElement = review.QuerySelectorAll("div")
                .First(item => item.ClassName != null && item.ClassName.Contains("col"))
                .QuerySelectorAll("a").Last();
            return nameAuthorReviewElement.TextContent;
        }

        private string GetReviewText(IElement review)
        {
            var reviewLink = review.QuerySelectorAll("div")
                .First(item => item.ClassName != null && item.ClassName.Contains("universal-blocks-content"))
                .QuerySelectorAll("a").Last(item => item.ClassName == null);
            var link = reviewLink.GetAttribute("href");
            HtmlLoader loader = new HtmlLoader(new BookSettings() { Prefix = link });
            var source = loader.GetSource(0);
            var parserDocument = new HtmlParser();
            var document = parserDocument.ParseDocument(source.Result);
            ReviewParser parser = new ReviewParser(link.Split('#').Last());
            return parser.Parse(document);
        }

        private string GetNameAuthor(IElement review)
        {
            var nameAuthorElement = review.QuerySelectorAll("p")
                .First(item => item.ClassName != null && item.ClassName.Contains("universal-blocks-description"))
                .QuerySelectorAll("a").Last();
            return nameAuthorElement.TextContent;
        }

        private string GetNameBook(IElement review)
        {
            var nameBookElement = review.QuerySelectorAll("p")
                .First(item => item.ClassName != null && item.ClassName.Contains("universal-blocks-description"))
                .QuerySelectorAll("a").First();
            return nameBookElement.TextContent;
        }

        private int GetGrade(IElement review)
        {
            var gradeClass = review
                .QuerySelectorAll("div").First(item => item.ClassName != null && item.ClassName.Contains("rating disabled star"));
            int.TryParse(gradeClass.ClassName.Last().ToString(), out var grade);
            return grade;
        }
    }
}
