using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Html.Parser;

namespace ParseHtml
{
    class ParserWorker<T> where T : class
    {
        private IParserSettings parserSettings;
        private HtmlLoader loader;

        public bool IsActive { get; private set; }
        public IParser<T> Parser { get; private set; }
        public IParserSettings ParserSettings
        {
            get => parserSettings;
            set
            {
                parserSettings = value;
                loader = new HtmlLoader(value);
            }
        }
        public ParserWorker(IParser<T> parser)
        {
            Parser = parser;
        }

        public void Start(int count)
        {
            IsActive = true;
            Work(count);
        }

        private async void Work(int count)
        {
            string url = loader.GetSource(count);
            var parserDocument = new HtmlParser();
            var document = await parserDocument.ParseDocumentAsync(url);
            var result = Parser.Parse(document);

        }
    }
}
