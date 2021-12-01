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
using ParseHtml.ArticleYandex;
using ParseHtml.Image;
using ParseHtml.News;
using ParseHtml.WashingtonPostNews;

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
                case 3:
                    SaveVyatSUNews();
                    Console.WriteLine("Saving was successful");
                    break;
                case 4:
                    SaveWashingtonPostNews();
                    Console.WriteLine("Saving was successful");
                    break;
                case 5:
                    SaveYandexArticle();
                    Console.WriteLine("Saving was successful");
                    break;
            }
            Console.ReadKey();
            Console.Clear();
        }

        private static void SaveYandexArticle()
        {
            ParserWorker<List<Article>> parser = new ParserWorker<List<Article>>(new YandexParser());
            parser.ParserSettings = new YandexSettings("gadgets");
            parser.OnNewData += ParserOnOnNewData;
            parser.Start();
        }

        private static void ParserOnOnNewData(object arg1, List<Article> arg2)
        {
            Console.WriteLine("Input file directory");
            string path = Console.ReadLine();
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string json = JsonSerializer.Serialize(arg2, options);
            File.WriteAllText(path + "\\article + " + DateTime.Now.Ticks + ".json", json);
        }

        private static void SaveWashingtonPostNews()
        {
            ParserWorker<List<News>> parser = new ParserWorker<List<News>>(new WashingtonPostParser());
            Console.WriteLine("Enter the number of pages to download");
            int countNews;
            if (int.TryParse(Console.ReadLine(), out countNews))
            {
                parser.ParserSettings = new WashingtonPostSettings(countNews);
                parser.OnNewData += ParserOnOnNewData;
                parser.Start();
            }
        }

        private static void SaveVyatSUNews()
        {
            ParserWorker<List<News>> parser = new ParserWorker<List<News>>(new NewsParser());
            Console.WriteLine("Enter the number of pages to download");
            int countNews;
            if (int.TryParse(Console.ReadLine(), out countNews))
            {
                parser.ParserSettings = new NewsSettings(countNews);
                parser.OnNewData += ParserOnOnNewData; 
                parser.Start();
            }
        }

        private static void ParserOnOnNewData(object arg1, List<News> arg2)
        {
            Console.WriteLine("Input file directory");
            string path = Console.ReadLine();
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string json = JsonSerializer.Serialize(arg2, options);
            File.WriteAllText(path + "\\news + " + DateTime.Now.Ticks + ".json", json);
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
            Console.WriteLine("Input count reviews:");
            reviews.OnNewData += parser_OnNewData;
            int count;
            if (int.TryParse(Console.ReadLine(), out count))
            {
                reviews.ParserSettings = new BookSettings(count);
                reviews.Start();
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
            Console.WriteLine("\t3 - Save VyatSU news;");
            Console.WriteLine("\t4 - Save Washington Post news;");
            Console.WriteLine("\t5 - Save Yandex article;");
            Console.WriteLine("\t0 - Exit");
        }
    }
}
