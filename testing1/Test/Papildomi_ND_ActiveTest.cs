using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using testing1.Page;

namespace testing1.Test
{
    public class Papildomi_ND_ActiveTest
    {
        private static Papildomi_ND_ActivePage page;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            IWebDriver chrome = new ChromeDriver();
            page = new Papildomi_ND_ActivePage(chrome);

            chrome.Manage().Window.Maximize();
            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            chrome.Url = "https://www.active.com/fitness/calculators/pace";
            page.ClosePopUp();
            page.AcceptCookies();
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            //page.CloseBrowser();
        }
        
        [TestCase("1", "5", "13", "05", TestName = "13km_per1hour5min_pace5min/km")]
        public static void TestCases(string hour, string min, string km, string pace)
        {
            page.InsertHours(hour);
            page.InsertMinutes(min);
            page.InsertDistance(km);
            page.SelectDistanceKilometers();
            page.SelectPacePerKm();
            page.CalculateButton();
            page.VerifyPaceResult(pace);
        }

    }
}