using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace testing1.Page
{
    public class Baigiamasis_projektas_AirbnbPage: BasePage
    {
        private const string AddressUrl = "https://www.airbnb.com/";
        
        private IWebElement flexibleButton => Driver.FindElement(By.CssSelector("#site-content > div > div > div:nth-child(1) > div:nth-child(2) > div > div._jdvs9l4 > div > div._16xcv07v > div._kk9qp6 > a"));
        private IWebElement locationInput => Driver.FindElement(By.CssSelector("#bigsearch-query-detached-query-input"));
        private IWebElement profileButton => Driver.FindElement(By.Id("field-guide-toggle"));
        private IWebElement signupButton => Driver.FindElement(By.CssSelector(".\\_14tt8lmp > .\\_ojs7nk"));
        private IWebElement phoneInput => Driver.FindElement(By.CssSelector("#phoneInputLogin"));
        private IWebElement continueButton => Driver.FindElement(By.CssSelector(".\\_m9v25n"));
        private IWebElement errorMessage => Driver.FindElement(By.CssSelector("#phone-number-error-Login"));
        private IWebElement errorMessage2 => Driver.FindElement(By.CssSelector("body > div:nth-child(22) > section > div > div > div._z4lmgp > div > div._12kfhdn > div > form > div > div._152qbzi > section > div.mbv7i5o.dir.dir-ltr > div"));
        private SelectElement countryDropdown => new SelectElement(Driver.FindElement(By.Id("country")));

        private IWebElement checkIn => Driver.FindElement(By.CssSelector("body > div:nth-child(7) > div > div > div:nth-child(1) > div > div > div._16grqhk > div._siy8gh > div > header > div > div._1gzu4h3 > div._zusf8ed > div > div > div > form > div._1rrb221v > div > div._1l6jpwo > div:nth-child(1) > div > div"));
        private IWebElement flexibleCheckIn => Driver.FindElement(By.CssSelector("#tab--tabs--1"));
        private IWebElement weekOption => Driver.FindElement(By.CssSelector("#flexible_trip_lengths-one_week > button"));
        private IWebElement september => Driver.FindElement(By.CssSelector("#flexible_trip_dates-september > button"));
        private IWebElement october => Driver.FindElement(By.CssSelector("#flexible_trip_dates-october > button"));
        private IWebElement february => Driver.FindElement(By.CssSelector("#flexible_trip_dates-february > button"));
        private IWebElement guestsButton => Driver.FindElement(By.CssSelector("body > div:nth-child(7) > div > div > div:nth-child(1) > div > div > div._16grqhk > div._siy8gh > div > header > div > div._1gzu4h3 > div._zusf8ed > div > div > div > form > div._1rrb221v > div > div._1yulsurh > div._37ivfdq"));
        private IWebElement increaseGuestsNum => Driver.FindElement(By.CssSelector("#stepper-adults > button:nth-child(3)"));
        private IWebElement searchButton => Driver.FindElement(By.CssSelector("body > div:nth-child(7) > div > div > div:nth-child(1) > div > div > div._16grqhk > div._siy8gh > div > header > div > div._1gzu4h3 > div._zusf8ed > div > div > div > form > div._1rrb221v > div > div._1yulsurh > div._w64aej > button"));
        private IWebElement experiencesButton => Driver.FindElement(By.CssSelector("body > div:nth-child(7) > div > div > div:nth-child(1) > div > div > div._16grqhk > div._siy8gh > div > header > div > div._1gzu4h3 > div._zusf8ed > div > div > div > form > div._17fy1ix > div._36rlri > a"));
        
        public Baigiamasis_projektas_AirbnbPage(IWebDriver webdriver) : base(webdriver) {}
        
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

        public void VerifyWrongPhoneNumberMessage()
        {
            var error = "Phone number is too short or contains invalid characters.";
            Assert.AreEqual(error, errorMessage.Text, "Wrong message");
        }
        
        public void VerifyTooLongPhoneNumberMessage()
        {
            Assert.AreEqual("We can't send a code to this phone number. Try using a different one.", errorMessage2.Text, "Wrong message");
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
            //Thread.Sleep(3000);
            //october.Click();
            //Thread.Sleep(3000);
            //february.Click();
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
        
        public void ChooseExperiences()
        {
            experiencesButton.Click();
        }
        
        private void WaitForResult()
        { 
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d =>
                d.FindElement(By.Id("field-guide-toggle"))
                    .Enabled);
        }
    }
}