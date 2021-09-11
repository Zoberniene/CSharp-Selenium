using System.Threading;
using NUnit.Framework;

namespace Airbnb_baigiamasis_projektas.Test
{
    public class AirbnbTest: BaseTest
    {
        [Test]
        public static void TestFlexibleBeachfront()
        {
            homePage.NavigateToPage();
            homePage.ClickFlexibleButton();
            flexiblePage.ChooseBeachfrontOption();
            flexiblePage.VerifyBeachfrontResults();
        }

        [Test]
        public static void TestWeekendFilter()
        {
            homePage.NavigateToPage();
            homePage.ClickFlexibleButton();
            flexiblePage.ClickAnytimeButton();
            flexiblePage.ClickWeekendButton();
            flexiblePage.ClickSaveButton();
            flexiblePage.VerifyWeekendResults();
        }
        
        /*[Test]
        public static void TestPriceFilter() //netikrinta
        {
            homePage.NavigateToPage();
            homePage.ClickFlexibleButton();
            flexiblePage.ClickOnFilters();
            flexiblePage.InsertPriceRange();
        }*/
        
        [Test]
        public static void TestSignupInsertWrongPhoneNumber() 
        {
            homePage.NavigateToPage();
            Thread.Sleep(5000);
            homePage.ClickProfileButton();
            homePage.ClickSignupButton();
            homePage.SelectCountry();
            homePage.InsertPhoneNumber("4566");
            homePage.ClickContinueButton();
            homePage.VerifyWrongPhoneNumberError(); 
        }

        [Test]
        public static void TestAveragePriceFor2AdultsOctober()
        {
            homePage.NavigateToPage();
            homePage.InsertLocationInput();
            homePage.AddDate();
            homePage.AddGuests();
            homePage.ClickSearchButton();
            searchResultsPage.ClickPriceButton();
            searchResultsPage.VerifyAveragePriceResults();
        }
        
        [Test]
        public static void TestOnlineExperiencesLanguageDanceFilter()
        {
            homePage.NavigateToPage();
            homePage.ChooseOnlineExperiences();
            onlineExperiencesPage.ChooseFilters();
            onlineExperiencesPage.ChooseLanguage();
            onlineExperiencesPage.ShowFilteredResults();
            onlineExperiencesPage.ChooseDance();
            onlineExperiencesPage.VerifyFilteredResults();
        }
    }
}