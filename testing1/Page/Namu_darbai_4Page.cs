using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace testing1.Page
{
    public class Namu_darbai_4Page: BasePage
    {
        private SelectElement multiDropdown => new SelectElement(Driver.FindElement(By.Id("cars")));
        
        private IWebElement submitButton => Driver.FindElement(By.CssSelector("body > form > input[type=submit]"));

        private IWebElement result => Driver.FindElement(By.CssSelector("body > div.w3-container.w3-large.w3-border"));
            //XPath("/html/body/div[1]"));
        
        public Namu_darbai_4Page(IWebDriver webdriver) : base(webdriver) {}
        
        public void AcceptCookies()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d =>
                d.FindElement(By.Id("accept-choices"))
                    .Displayed); 
            Driver.FindElement(By.Id("accept-choices")).Click();
        }
        public void ClickSubmitButton()
        {
            submitButton.Click();
        }

        public void SelectCars(List<string> cars)
        {
            Driver.SwitchTo().Frame(0);
            multiDropdown.DeselectAll();
            Actions action = new Actions(Driver);
            action.KeyDown(Keys.Command);

            foreach (string car in cars)
            {
                foreach (IWebElement option in multiDropdown.Options)
                {
                    if (car.Equals(option.Text) && !option.Selected)
                    {
                        action.Click(option);
                        break;
                    }
                }
            }
            action.KeyUp(Keys.Command);
            action.Build().Perform();
        }
        
        public void VerifySelectedCarsResult(List<string> allCars)
        {
            foreach(string car in allCars)
            {
                Assert.IsTrue(result.Text.Contains(car.ToLower()), 
                    $"{car} car is not present, visible text {result.Text}");
            }
        }
    }
}