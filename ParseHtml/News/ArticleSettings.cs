namespace ParseHtml.News
{
    class ArticleSettings : IParserSettings
    {
        public string BaseUrl { get; set; } = "https://www.vyatsu.ru";
        public string Prefix { get; set; }
        public int StartPoint => 1;
        public int EndPoint => 1;

        public ArticleSettings(string prefix)
        {
            Prefix = prefix;
        }
    }
}
