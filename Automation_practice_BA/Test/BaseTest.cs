using Automation_practice_BA.Drivers;
using Automation_practice_BA.Page;
using Automation_practice_BA.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace Automation_practice_BA.Test
{
    public class BaseTest
    {
        protected static IWebDriver driver;
        public static HomePage homePage;
        public static CartPage cartPage;
        
        
        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            driver = CustomDriver.GetChrome();
            homePage = new HomePage(driver);
            cartPage = new CartPage(driver);
        }

        [TearDown]
        public static void TakeScreenshot()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
                MyScreenshot.MakeScreenshot(driver);
        }
        
        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            //driver.Quit();
        }
    }
}