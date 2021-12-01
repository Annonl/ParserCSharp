using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseHtml.ArticleYandex
{
    public class YandexSettings : IParserSettings
    {
        public string BaseUrl { get; set; } = "https://market.yandex.ru";
        public string Prefix { get; set; } = "/journal/";
        public int StartPoint { get; } = 1;
        public int EndPoint { get; } = 1;

        public YandexSettings(string prefix)
        {
            Prefix += prefix;
        }
    }
}
