using NUnit.Framework;
using OpenQA.Selenium;

namespace testing1.Page
{
    public class CheckboxPage: BasePage
    {
        private const string AddressUrl = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";
        private IWebElement firstCheckbox => Driver.FindElement(By.Id("isAgeSelected"));
        private IWebElement result => Driver.FindElement(By.Id("txtAge"));

        public CheckboxPage(IWebDriver webdriver) : base(webdriver) { }

        public void NavigateToPage()
        {
            if (Driver.Url != AddressUrl)
            {
                Driver.Url = AddressUrl;
            }
        }

        public void ClickCheckbox()
        {
            if (!firstCheckbox.Selected)
            {
                firstCheckbox.Click();
            }
        }

        public void VerifyResult()
        {
            Assert.AreEqual("Success - Check box is checked", result.Text, "Text is wrong");
        }
    }
}