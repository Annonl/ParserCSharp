namespace ParseHtml.News
{
    public class News
    {
        public string Title { get; }
        public string Text { get; }

        public News(string title, string text)
        {
            Title = title;
            Text = text;
        }
    }
}
