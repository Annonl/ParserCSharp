using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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
            driver.Navigate().GoToUrl("https://www.google.com/imghp?hl=ru&ogbl");

            IWebElement element = driver.FindElement(By.ClassName("gLFyf gsfi"));
            element.SendKeys(searchQuery);

            // Get the search results panel that contains the link for each result.
            IWebElement resultsPanel = driver.FindElement(By.ClassName("Tg7LZd"));

            ReadOnlyCollection<IWebElement> searchResults = resultsPanel.FindElements(By.ClassName("wXeWr islib nfEiy"));
            var result = new List<string>();
            foreach (IWebElement searchResult in searchResults)
            {
                result.Add(searchResult.GetAttribute("href"));
            }
            return result;
        }
    }
}
