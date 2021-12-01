namespace ParseHtml.WashingtonPostNews
{
    public class WashingtonPostSettings: IParserSettings
    {
        public string BaseUrl { get; set; } = "https://washingtonnewspost.com";
        public string Prefix { get; set; } = "/news/usa/page/{CurrentId}/";
        public int StartPoint { get; }
        public int EndPoint { get; }

        public WashingtonPostSettings(int countNews)
        {
            StartPoint = 1;
            EndPoint = countNews;
        }
    }
}
