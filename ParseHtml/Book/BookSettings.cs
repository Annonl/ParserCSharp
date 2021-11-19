namespace ParseHtml.Book
{
    public class BookSettings : IParserSettings
    {
        public string BaseUrl { get; set; } = "https://bookmix.ru/comments/";
        public string Prefix { get; set; } = "index.phtml?begin=0&num_point={CurrentId}";
    }
}
