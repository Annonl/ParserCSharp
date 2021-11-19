using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public void Download(string searchQuery)
        {

        }
    }
}
