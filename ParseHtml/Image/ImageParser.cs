using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AngleSharp.Html.Dom;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ParseHtml.Image
{
    public class ParserImage
    {
        public List<string> Parse(string searchQuery)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.ru/imghp?hl=ru&ogbl");

            IWebElement element = driver.FindElement(By.ClassName("gLFyf"));
            element.SendKeys(searchQuery);

            // Get the search results panel that contains the link for each result.
            IWebElement resultsPanel = driver.FindElement(By.ClassName("Tg7LZd"));
            resultsPanel.Click();
            IList<IWebElement> Imghref = resultsPanel.FindElements(By.ClassName("rg_i"));
            List<IWebElement> searchResults;
            Thread.Sleep(10000);
            try
            {
                searchResults = resultsPanel.FindElements(By.ClassName("wXeWr")).Take(20).ToList();
            }
            catch (Exception e)
            {
                searchResults = resultsPanel.FindElements(By.ClassName("wXeWr")).Take(20).ToList();
            }
            var result = new List<string>();
            foreach (IWebElement searchResult in Imghref)
            {
                result.Add(searchResult.GetAttribute("href"));
            }
            return result;
        }
    }
}
