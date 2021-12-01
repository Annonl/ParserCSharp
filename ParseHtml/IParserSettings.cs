namespace ParseHtml
{
    public interface IParserSettings
    {
        public string BaseUrl { get; set; }
        public string Prefix { get; set; }
        public int StartPoint { get; }
        public int EndPoint { get; }
    }
}
