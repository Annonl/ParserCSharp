using AngleSharp.Html.Dom;

namespace ParseHtml
{
    public interface IParser<T> where T : class
    {
        T Parse(IHtmlDocument document);
    }
}
