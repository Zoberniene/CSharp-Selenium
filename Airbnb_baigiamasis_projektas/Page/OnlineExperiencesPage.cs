using NUnit.Framework;
using OpenQA.Selenium;

namespace Airbnb_baigiamasis_projektas.Page
{
    public class OnlineExperiencesPage: BasePage
    {
        private IWebElement filters => Driver.FindElement(By.CssSelector("#menuItemButton-dynamicMoreFilters > button"));
        private IWebElement showAllLanguages => Driver.FindElement(By.CssSelector("body > div:nth-child(25) > section > div > div > div._z4lmgp > div > div._12k64q0 > div:nth-child(3) > section > div:nth-child(3) > div._cfvh61 > div > button"));
        private IWebElement french => Driver.FindElement(By.CssSelector("#filterItem-host_language-checkbox-experience_languages-2-row-checkbox"));
        private IWebElement dance => Driver.FindElement(By.CssSelector("#menuItemButton-toggleItem-taxonomy-Dance-Dance > button"));
        private IWebElement danceResult => Driver.FindElement(By.CssSelector("#ExploreLayoutController > div > div:nth-child(1) > div._twmmpk > div > div:nth-child(1) > div > div > div > div:nth-child(1) > div > div > div > div > h2 > div"));
        private IWebElement danceResultNumber => Driver.FindElement(By.CssSelector("#ExploreLayoutController > div > div:nth-child(1) > div._twmmpk > div > div:nth-child(1) > div > div > div > div:nth-child(1) > div > div > div > div > div"));

        
        private IWebElement showResultsButton => Driver.FindElement(By.CssSelector("body > div:nth-child(23) > section > div > div > div._z4lmgp > div > footer > button"));
        
        public OnlineExperiencesPage(IWebDriver webdriver) : base(webdriver) {}
        
        public void ChooseFilters(){
            filters.Click();
            
            /*Actions action = new Actions(Driver);
            action.MoveToElement(showAllLanguages);
            action.Build().Perform();
            showAllLanguages.Click();*/
        }
        
        public void ChooseLanguage(){
            french.Click();
        }
        
        public void ShowFilteredResults(){
            showResultsButton.Click();
        }
        
        public void ChooseDance(){
            dance.Click();
        }
        
        public void VerifyFilteredResults()
        {
            //galima pacekinti, kad atsiranda taikytu filtru skaicius prie filters button
            Assert.IsTrue(filters.GetAttribute("class").Contains("_qc44h1f"));
            Assert.IsTrue(dance.GetAttribute("class").Contains("_5jd9dh5"));
            Assert.AreEqual("Dance", danceResult.Text, "Wrong category");
            Assert.AreEqual("5 results based on your filters", danceResultNumber.Text, "Wrong filtered items number");
        }
    }
}