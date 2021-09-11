using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Airbnb_baigiamasis_projektas.Page
{
    public class LuxePage: BasePage
    {
        private IWebElement locationInput => Driver.FindElement(By.CssSelector("#query"));
        private IWebElement searchButton => Driver.FindElement(By.CssSelector("#submit_btn"));
        private IWebElement luxeheading => Driver.FindElement(By.CssSelector("._fninp ._twmmpk > div > div:nth-child(2) > div > div > div > div:nth-child(1) > div > div > div > div > h2 > div"));
        
        private IWebElement luxeCheckbox => Driver.FindElement(By.CssSelector("#filterItem-listing_tier-switch-tier_ids-2"));
        IReadOnlyCollection<IWebElement> luxeResults => Driver.FindElements(By.CssSelector("._e296pg ._1mx6kqf a"));
        public LuxePage(IWebDriver webdriver) : base(webdriver) {}
        
        public void InsertDestination(){
            WaitForResult();
            locationInput.Clear();
            locationInput.SendKeys("Nice");
        }
        
        public void ClickSearchButton(){
            searchButton.Click();
        }
        
        public void VerifyLuxeResults()
        {
            Assert.AreEqual("Airbnb Luxe homes in Nice", luxeheading.Text, "Wrong luxe heading");
            //Assert.IsTrue(luxeCheckbox.GetAttribute("class").Contains("_1nf9xc2y"));
            //Assert.IsTrue(luxeCheckbox.GetAttribute("aria-checked").Equals("true"));
            foreach (IWebElement luxury in luxeResults)
            {
                Assert.IsTrue(luxury.GetAttribute("href").Contains("luxury"), "Wrong luxury filter");
            }
        }
        
        private void WaitForResult()
        { 
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d =>
                d.FindElement(By.CssSelector("#query"))
                    .Enabled);
        }
    }
    
}