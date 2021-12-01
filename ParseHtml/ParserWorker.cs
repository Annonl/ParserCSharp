using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AngleSharp.Html.Parser;

namespace ParseHtml
{
    public class ParserWorker<T> where T : class
    {
        private IParserSettings parserSettings;
        private HtmlLoader loader;
        public IParser<T> Parser { get; private set; }

        public event Action<object, T> OnNewData;
        public event Action<object> OnCompleted;

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

        public void Start()
        {
            Work();
        }

        private void Work()
        {
            for (int i = parserSettings.StartPoint; i <= parserSettings.EndPoint; i++)
            {
                var source = loader.GetSource(i);
                var parserDocument = new HtmlParser();
                var document = parserDocument.ParseDocument(source.Result);
                var result = Parser.Parse(document);
                OnNewData?.Invoke(this, result);
            }
        }
    }
}
