namespace ParseHtml.WashingtonPostNews
{
    class ArticleSettings : IParserSettings
    {
        public string BaseUrl { get; set; } = "https://washingtonnewspost.com";
        public string Prefix { get; set; } = "/news/usa/";
        public int StartPoint { get; }
        public int EndPoint { get; }

        public ArticleSettings(string prefix)
        {
            StartPoint = 1;
            EndPoint = 1;
            Prefix += prefix;
        }
    }
}
