namespace ParseHtml.Book
{
    public class BookSettings : IParserSettings
    {
        public string BaseUrl { get; set; } = "https://bookmix.ru";
        public string Prefix { get; set; } = "/comments/index.phtml?begin=0&num_point={CurrentId}";
        public int StartPoint { get; }
        public int EndPoint { get; }

        public BookSettings(int countReviews)
        {
            StartPoint = countReviews;
            EndPoint = countReviews;
        }
    }
}
