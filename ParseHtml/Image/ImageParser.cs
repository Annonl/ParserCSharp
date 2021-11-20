using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using AngleSharp.Html.Dom;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ParseHtml.Image
{
    public class ParserImage
    {
        private ImageSettings settings = new ImageSettings();
        private readonly Regex rg = new Regex(@"""url"":""[\w:\/.-]*""");
        public List<string> Parse(string searchQuery, int count)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(settings.BaseUrl);

            IWebElement element = driver.FindElement(By.ClassName("input__control"));
            element.SendKeys(searchQuery);

            IWebElement resultsPanel = driver.FindElement(By.ClassName("websearch-button"));
            resultsPanel.Click();

            Thread.Sleep(10000);
            var result = new List<string>();
            for (int i = 0; i < count; i++)
            {
                var searchResult = resultsPanel.FindElement(By.XPath("//*[contains(@class,'serp-item_pos_" + i + "')]"));
                var str = searchResult.GetAttribute("data-bem");
                var res = rg.Match(str);
                result.Add(res.Value.Substring(7, res.Value.Length - 8));
            }
            return result;
        }
    }
}
