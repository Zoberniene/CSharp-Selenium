using Airbnb_baigiamasis_projektas.Drivers;
using Airbnb_baigiamasis_projektas.Page;
using Airbnb_baigiamasis_projektas.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace Airbnb_baigiamasis_projektas.Test
{
    public class BaseTest
    {
        protected static IWebDriver driver;
        public static HomePage homePage;
        public static FlexiblePage flexiblePage;
        public static SearchResultsPage searchResultsPage;
        public static OnlineExperiencesPage onlineExperiencesPage;
        

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            driver = CustomDriver.GetChrome();
            homePage = new HomePage(driver);
            flexiblePage = new FlexiblePage(driver);
            searchResultsPage = new SearchResultsPage(driver);
            onlineExperiencesPage = new OnlineExperiencesPage(driver);
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