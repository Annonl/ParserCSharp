namespace ParseHtml.News
{
   public  class NewsSettings : IParserSettings
    {
        public string BaseUrl { get; set; } = "https://www.vyatsu.ru";
        public string Prefix { get; set; } = "/internet-gazeta/page:{CurrentId}";
        public int StartPoint { get; }
        public int EndPoint { get; }
        public NewsSettings(int countPages)
        {
            StartPoint = 1;
            EndPoint = countPages;
        }
    }
}
