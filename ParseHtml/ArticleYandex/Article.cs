using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseHtml.ArticleYandex
{
   public class Article
   {
       public string Title { get; set; }
       public string Text { get; set; }

       public Article(string title, string text)
       {
           Title = title;
           Text = text;
       }
    }
}
