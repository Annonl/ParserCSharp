namespace ParseHtml.Book
{
    class BookSettings : IParserSettings
    {
        public string BaseUrl { get; set; } = "https://bookmix.ru/comments/";
        public string Prefix { get; set; } = "index.phtml?begin=0&num_point={CurrentReview}";
    }
}
