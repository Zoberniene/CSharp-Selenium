using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace testing1.Page
{
    public class Papildomi_ND_ActivePage : BasePage
    {
        private IWebElement close_pop_up => Driver.FindElement(By.CssSelector("#page-wrapper > aside > div > header > span"));
        private IWebElement accept_cookies_btn => Driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[4]/div[2]/div/button"));
        //private IWebElement accept_cookies_btn => Driver.FindElement(By.CssSelector(".accept-cookies-button"));
        private IWebElement hours => Driver.FindElement(By.XPath("//*[@id='calculator-pace']/form/div[2]/div/label[1]/input"));
        private IWebElement minutes => Driver.FindElement(By.XPath("//*[@id='calculator-pace']/form/div[2]/div/label[2]/input"));
        private IWebElement distance =>
            Driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(3) > div > label > input[type=number]"));

        //private SelectElement distanceDropdown => new SelectElement(Driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(3) > div > select")));
        private SelectElement distanceDropdown => new SelectElement(Driver.FindElement(By.XPath("//*[@id='calculator-pace']/form/div[3]/div/select")));
        
        private SelectElement paceDropdown => new SelectElement(Driver.FindElement(By.XPath("//*[@id='calculator-pace']/form/div[4]/div/select")));
        
        private IWebElement calculateButton => Driver.FindElement(By.CssSelector(".calculate-btn"));
        
        private IWebElement paceResult => Driver.FindElement(By.XPath("//*[@id='calculator-pace']/form/div[4]/div/label[2]/input"));
        public Papildomi_ND_ActivePage(IWebDriver webdriver) : base(webdriver) {}
        
        public void ClosePopUp(){
            close_pop_up.Click();
        }
    
        public void AcceptCookies(){
            accept_cookies_btn.Click();
        }
    
        public void InsertHours(string hour)
        {
            hours.SendKeys(hour);
        }
        
        public void InsertMinutes(string min)
        {
            minutes.SendKeys(min);
        }
        
        public void InsertDistance(string km)
        {
            distance.SendKeys(km);
        }

        public void SelectDistanceKilometers()
        {
            distanceDropdown.SelectByIndex(0);
            //distanceDropdown.SelectByValue("km");
            //distanceDropdown.SelectByText("Kilometers");
            
        }
        
        public void SelectPacePerKm()
        {
            paceDropdown.SelectByIndex(0);
        }
        
        public void CalculateButton()
        {
            calculateButton.Click();
        }
        
        public void VerifyPaceResult(string pace)
        {
            Assert.AreEqual(pace, paceResult.GetAttribute("value"), "Pace result is wrong");
        }
    }
}