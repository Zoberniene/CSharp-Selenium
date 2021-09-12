using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Airbnb_baigiamasis_projektas.Page
{
    public class LuxeResultsPage: BasePage
    {
        private IWebElement luxeheading => Driver.FindElement(By.CssSelector("._fninp ._twmmpk > div > div:nth-child(2) > div > div > div > div:nth-child(1) > div > div > div > div > h2 > div"));
        private IWebElement guestsNum => Driver.FindElement(By.CssSelector("#ExploreLayoutController > div._fninp > div:nth-child(1) > div._zdxht7 > div > div._rrw786 > section > div._1snxcqc"));
        IReadOnlyCollection<IWebElement> luxeResults => Driver.FindElements(By.CssSelector("._e296pg ._1mx6kqf a"));
        public LuxeResultsPage(IWebDriver webdriver) : base(webdriver) {}
        
        public void VerifyLuxeResults()
        {
            Assert.IsTrue(luxeheading.Text.Contains("Airbnb Luxe homes in"), "Wrong heading");
            Assert.IsTrue(guestsNum.Text.Contains("9 guests"), "Wrong guests number");
            foreach (IWebElement luxury in luxeResults)
            {
                Assert.IsTrue(luxury.GetAttribute("href").Contains("luxury"), "Wrong luxury filter");
            }
        }

    }
}