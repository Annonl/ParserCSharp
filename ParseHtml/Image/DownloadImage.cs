using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ParseHtml.Image
{
    public class DownloadImage
    {
        public string FilePath { get; private set; }
        public DownloadImage(string filePath)
        {
            FilePath = Directory.Exists(filePath) ? filePath : "C:";
        }

        public void Download(string searchQuery,int count)
        {
            ParserImage parser = new ParserImage();
            var resultList = parser.Parse(searchQuery, count);
            WebClient client = new WebClient();
            client.Headers.Add("user-agent",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/59.0.3071.115 Safari/537.36");
            foreach (var res in resultList)
            {
                Uri uri = new Uri(res);
                try
                {
                    client.DownloadFile(uri, FilePath + res.Split('/').Last());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }
    }
}
