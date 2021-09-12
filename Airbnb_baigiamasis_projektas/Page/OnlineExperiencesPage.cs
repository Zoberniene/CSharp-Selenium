using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Airbnb_baigiamasis_projektas.Page
{
    public class OnlineExperiencesPage: BasePage
    {
        private IWebElement filters => Driver.FindElement(By.CssSelector("#menuItemButton-dynamicMoreFilters > button"));
        private IWebElement french => Driver.FindElement(By.CssSelector("#filterItem-host_language-checkbox-experience_languages-2-row-checkbox"));
        private IWebElement dance => Driver.FindElement(By.CssSelector("#menuItemButton-toggleItem-taxonomy-Dance-Dance > button"));
        private IWebElement danceResult => Driver.FindElement(By.XPath("//*[@id='ExploreLayoutController']/div/div[1]/div[2]/div/div/div/div[1]//h2/div"));
        private IWebElement danceResultNumber => Driver.FindElement(By.CssSelector("#ExploreLayoutController > div > div:nth-child(1) > div._twmmpk > div > div:nth-child(1) > div > div > div > div:nth-child(1) > div > div > div > div > div"));
        private IWebElement showResultsButton => Driver.FindElement(By.CssSelector("._pmpl8qu:nth-child(2)"));

        public OnlineExperiencesPage(IWebDriver webdriver) : base(webdriver) {}
        
        public void ChooseFilters(){
            filters.Click();
        }
        
        public void ChooseLanguage(){
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d =>
                d.FindElement(By.CssSelector("#filterItem-host_language-checkbox-experience_languages-2-row-checkbox"))
                    .Enabled);
            french.Click();
        }
        
        public void ShowFilteredResults(){
            showResultsButton.Click();
        }
        
        public void ChooseDance(){
            WaitForResult();
            dance.Click();
        }
        
        public void VerifyFilteredResults()
        {
            Assert.IsTrue(dance.GetAttribute("class").Contains("_5jd9dh5"));
            Assert.AreEqual("Dance", danceResult.Text, "Wrong category heading");
            Assert.AreEqual("5 results based on your filters", danceResultNumber.Text, "Wrong filtered items number");
            
        }
        
        private void WaitForResult()
        { 
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d =>
                d.FindElement(By.CssSelector("#menuItemButton-toggleItem-taxonomy-Dance-Dance > button"))
                    .Enabled);
        }
    }
}