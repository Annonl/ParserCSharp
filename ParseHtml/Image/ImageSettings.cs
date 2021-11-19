using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseHtml.Image
{
    class ImageSettings : IParserSettings
    {
        public string BaseUrl { get; set; } = "https://yandex.ru/images/search";
        public string Prefix { get; set; }
    }
}
