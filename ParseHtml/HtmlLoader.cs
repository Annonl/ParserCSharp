using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ParseHtml
{
    internal class HtmlLoader
    {
        private readonly HttpClient client;
        private readonly string url;
        public HtmlLoader(IParserSettings settings)
        {
            client = new HttpClient();
            url = $"{settings.BaseUrl}{settings.Prefix}";
        }

        public async Task<string> GetSource(int count)
        {
            var currentUrl = url.Replace("{CurrentId}", count.ToString());
            var response = await client.GetAsync(currentUrl);
            if (response.StatusCode == HttpStatusCode.OK)
                return await response.Content.ReadAsStringAsync();
            return null;
        }
    }
}
