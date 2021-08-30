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
        private IWebElement runButton => Driver.FindElement(By.Id("runbtn"));

        private IWebElement result => Driver.FindElement(By.CssSelector("body > div.w3-container.w3-large.w3-border"));

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
            Driver.SwitchTo().Frame("iframeResult");
            multiDropdown.DeselectAll();
            Actions action = new Actions(Driver);
            action.KeyDown(Keys.Command);
            
            foreach (IWebElement option in multiDropdown.Options)
            {
                if (cars.Contains(option.Text) && !option.Selected)
                {
                    option.Click();
                }
            }
            
            action.KeyUp(Keys.Command);
            action.Build().Perform();
        }

        public void RerunPage()
        {
            Driver.SwitchTo().DefaultContent();
            runButton.Click();
        }
        public void VerifySelectedCarsResult(List<string> allCars)
        {
            WaitForResult();
            foreach(string car in allCars)
            {
                Assert.IsTrue(result.Text.Contains(car.ToLower()), 
                    $"{car} car is not present, visible text {result.Text}");
            }
        }

        private void WaitForResult()
        {
            GetWait().Until(ExpectedConditions.ElementExists(By.CssSelector("body > p")));
        }
    }
}