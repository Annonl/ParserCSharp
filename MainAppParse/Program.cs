using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Text.Encodings.Web;
using ParseHtml;
using ParseHtml.Book;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using ParseHtml.Image;

namespace MainAppParse
{
    class Program
    {
        static void Main(string[] args)
        {
            int step = -1;
            while (step != 0)
            {
                Menu();
                if (int.TryParse(Console.ReadLine(), out step))
                    DoAction(step);
                else
                    step = 0;
            }
        }

        private static void DoAction(int step)
        {
            Console.Clear();
            switch (step)
            {
                case 1:
                    SaveBookReview();
                    Console.WriteLine("Saving was successful");
                    break;
                case 2:
                    SaveImages();
                    Console.WriteLine("Saving was successful");
                    break;
            }
            Console.ReadKey();
            Console.Clear();
        }

        private static void SaveImages()
        {
            Console.WriteLine("Input file path:");
            string path = Console.ReadLine();
            DownloadImage download = new DownloadImage(path);
            Console.WriteLine("Input search query:");
            string search = Console.ReadLine();
            Console.WriteLine("Input count image:");
            int count;
            if (int.TryParse(Console.ReadLine(), out count))
                download.Download(search, count);
            else
                Console.WriteLine("Number input incorrect.");
        }

        private static void SaveBookReview()
        {
            ParserWorker<List<ReviewBook>> reviews = new ParserWorker<List<ReviewBook>>(new BookParser());
            reviews.ParserSettings = new BookSettings();
            Console.WriteLine("Input count reviews:");
            reviews.OnNewData += parser_OnNewData;
            int count = 0;
            if (int.TryParse(Console.ReadLine(), out count))
            {
                reviews.Start(count);
            }
        }

        private static void parser_OnNewData(object arg1, List<ReviewBook> arg2)
        {
            Console.WriteLine("Input file directory");
            string path = Console.ReadLine();
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string json = JsonSerializer.Serialize(arg2,options);
            File.WriteAllText(path + "\\reviews.json", json);
        }

        private static void Menu()
        {
            Console.WriteLine("Choose further action:");
            Console.WriteLine("\t1 - Save book reviews;");
            Console.WriteLine("\t2 - Save pictures;");
            Console.WriteLine("\t0 - Exit");
        }
    }
}
