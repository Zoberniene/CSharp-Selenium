using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using testing1.Drivers;
using testing1.Page;
using testing1.Tools;

namespace testing1.Test
{
    public class BaseTest
    {
        protected static IWebDriver driver;
        public static Baigiamasis_projektas_AirbnbPage baigiamasisProjektasAirbnbPage;
        public static AirbnbFexiblePage airbnbFexiblePage;
        public static AirbnbSearchResultsPage airbnbSearchResultsPage;
        

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            driver = CustomDriver.GetChrome();
            baigiamasisProjektasAirbnbPage = new Baigiamasis_projektas_AirbnbPage(driver);
            airbnbFexiblePage = new AirbnbFexiblePage(driver);
            airbnbSearchResultsPage = new AirbnbSearchResultsPage(driver);
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