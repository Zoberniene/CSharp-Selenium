using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using testing1.Page;

namespace testing1.Test
{
    public class Baigiamasis_projektas_AirbnbTest: BaseTest
    {

        [Test]
        public static void TestFlexibleBeachfront()
        {
            baigiamasisProjektasAirbnbPage.NavigateToPage();
            baigiamasisProjektasAirbnbPage.ClickFlexibleButton();
            airbnbFexiblePage.ChooseBeachfrontOption();
            airbnbFexiblePage.VerifyBeachfrontResults();
        }

        [Test]
        public static void TestWeekendFilter()
        {
            baigiamasisProjektasAirbnbPage.NavigateToPage();
            baigiamasisProjektasAirbnbPage.ClickFlexibleButton();
            airbnbFexiblePage.ClickButtonAnytime();
            airbnbFexiblePage.ClickButtonWeekend();
            airbnbFexiblePage.ClickButtonSave();
            airbnbFexiblePage.VerifyWeekendResults();
        }
        
        [Test]
        public static void TestSignupInsertWrongPhoneNumber()
        {
            baigiamasisProjektasAirbnbPage.NavigateToPage();
            baigiamasisProjektasAirbnbPage.ClickProfileButton();
            baigiamasisProjektasAirbnbPage.ClickSignupButton();
            baigiamasisProjektasAirbnbPage.SelectCountry();
            baigiamasisProjektasAirbnbPage.InsertPhoneNumber("456");
            baigiamasisProjektasAirbnbPage.ClickContinueButton();
            baigiamasisProjektasAirbnbPage.VerifyWrongPhoneNumberMessage();
        }
        
        [Test]
        public static void TestSignupInsertTooLongPhoneNumber()
        {
            baigiamasisProjektasAirbnbPage.NavigateToPage();
            baigiamasisProjektasAirbnbPage.ClickProfileButton();
            baigiamasisProjektasAirbnbPage.ClickSignupButton();
            baigiamasisProjektasAirbnbPage.InsertPhoneNumber("45699999999997");
            baigiamasisProjektasAirbnbPage.ClickContinueButton();
            baigiamasisProjektasAirbnbPage.VerifyTooLongPhoneNumberMessage();
        }
    }
}