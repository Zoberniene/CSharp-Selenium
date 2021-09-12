using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Airbnb_baigiamasis_projektas.Page
{
    public class HomePage: BasePage
    {
        private const string AddressUrl = "https://www.airbnb.com/";
        private IWebElement flexibleButton => Driver.FindElement(By.CssSelector("._16xcv07v ._1hgo2zu"));
        private IWebElement locationInput => Driver.FindElement(By.CssSelector("#bigsearch-query-detached-query-input"));
        private IWebElement profileButton => Driver.FindElement(By.Id("field-guide-toggle"));
        private IWebElement signupButton => Driver.FindElement(By.CssSelector(".\\_14tt8lmp > .\\_ojs7nk"));
        private IWebElement phoneInput => Driver.FindElement(By.CssSelector("#phoneInputLogin"));
        private IWebElement continueButton => Driver.FindElement(By.CssSelector(".\\_m9v25n"));
        private IWebElement errorMessage => Driver.FindElement(By.CssSelector("#phone-number-error-Login"));
        private SelectElement countryDropdown => new SelectElement(Driver.FindElement(By.Id("country")));
        private IWebElement checkIn => Driver.FindElement(By.CssSelector("._1l6jpwo > div:nth-child(1) > div > div"));
        private IWebElement flexibleCheckIn => Driver.FindElement(By.CssSelector("#tab--tabs--1"));
        private IWebElement weekOption => Driver.FindElement(By.CssSelector("#flexible_trip_lengths-one_week > button"));
        private IWebElement september => Driver.FindElement(By.CssSelector("#flexible_trip_dates-september > button"));
        private IWebElement guestsButton => Driver.FindElement(By.CssSelector("._37ivfdq > div"));
        private IWebElement increaseGuestsNum => Driver.FindElement(By.CssSelector("#stepper-adults > button:nth-child(3)"));
        private IWebElement searchButton => Driver.FindElement(By.CssSelector("._w64aej > button"));
        private IWebElement onlineExperiencesButton => Driver.FindElement(By.CssSelector("._36rlri > a"));
        private IWebElement luxe => Driver.FindElement(By.CssSelector("._1gw6tte > footer ._fyxf74 > section:nth-child(1) > ul > li:nth-child(6) > a"));
        public HomePage(IWebDriver webdriver) : base(webdriver) {}
        
        public void NavigateToPage()
        {
            if (Driver.Url != AddressUrl)
            {
                Driver.Url = AddressUrl;
            }
        }
        
        public void ClickFlexibleButton(){
            flexibleButton.Click();
        }
        
        public void ClickProfileButton(){
            WaitForResult();
            profileButton.Click();
        }
        
        public void ClickSignupButton()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d =>
                d.FindElement(By.CssSelector("._w64aej > button"))
                    .Enabled);
            signupButton.Click();
        }
        
        public void InsertPhoneNumber(string num){
            phoneInput.Clear();
            phoneInput.SendKeys(num);
        }
        
        public void ClickContinueButton()
        {
            continueButton.Click();
        }
        public void SelectCountry()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d =>
                d.FindElement(By.Id("country"))
                    .Enabled);
            countryDropdown.SelectByIndex(5);
        }

        public void VerifyWrongPhoneNumberError()
        {
            string error = "Phone number is too short or contains invalid characters.";
            Assert.AreEqual(error, errorMessage.Text, "Wrong message");
        }

        public void InsertLocationInput()
        {
            locationInput.SendKeys("Adeje");
        }
        
        public void AddDate()
        {
            checkIn.Click();
            flexibleCheckIn.Click();
            weekOption.Click();
            september.Click();
        }
        
        public void AddGuests()
        {
            guestsButton.Click();
            increaseGuestsNum.Click();
            increaseGuestsNum.Click();
        }
        
        public void ClickSearchButton()
        {
            searchButton.Click();
        }
        
        public void ChooseOnlineExperiences()
        {
            onlineExperiencesButton.Click();
        }
        
        public void ChooseLuxe()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d =>
                d.FindElement(By.CssSelector("._1gw6tte > footer ._fyxf74 > section:nth-child(1) > ul > li:nth-child(6) > a"))
                    .Enabled);
            luxe.Click();
        }
        
        private void WaitForResult()
        { 
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d =>
                d.FindElement(By.Id("field-guide-toggle"))
                    .Displayed);
        }
    }
}