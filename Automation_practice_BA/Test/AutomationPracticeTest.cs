using NUnit.Framework;

namespace Automation_practice_BA.Test
{
    public class AutomationPracticeTest: BaseTest
    {
        [Test]
        public static void TestBuySearchedItem()
        {
            homePage.NavigateToPage();
            homePage.InsertSearchProductName("printed");
            homePage.ClickSearchButton();
            homePage.VerifySearchResults();
            homePage.AddItemToCart();
            homePage.VerifyIfItemWasAddedToCart();
            homePage.ProceedToCart();
            cartPage.VerifyCartItemsNumber();
            cartPage.ClickProceedToCheckoutButton();
            cartPage.CreateNewAccount();
            cartPage.FillPersonalInformation();
            cartPage.ProceedToShipping();
            cartPage.AgreeToTermsOfService();
            cartPage.ProceedToPayment();
            cartPage.ChoosePaymentMethod();
            cartPage.ConfirmOrder();
            cartPage.VerifyOrderIsConfirmed();
        }
    }
}