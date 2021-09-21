using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Automation_practice_BA.Page
{
    public class CartPage: BasePage
    {
        private IWebElement productsQuantity => Driver.FindElement(By.CssSelector("#summary_products_quantity"));
        private IWebElement proceedToCheckoutButton => Driver.FindElement(By.CssSelector("a.standard-checkout.button-medium"));
        private IWebElement emailInput => Driver.FindElement(By.CssSelector("#email_create"));
        private IWebElement firstNameInput => Driver.FindElement(By.CssSelector("#customer_firstname"));
        private IWebElement lastNameInput => Driver.FindElement(By.CssSelector("#customer_lastname"));
        private IWebElement passwordInput => Driver.FindElement(By.CssSelector("#passwd"));
        private IWebElement firstName => Driver.FindElement(By.CssSelector("#firstname"));
        private IWebElement lastName => Driver.FindElement(By.CssSelector("#lastname"));
        private IWebElement addressInput => Driver.FindElement(By.CssSelector("#address1"));
        private IWebElement cityInput => Driver.FindElement(By.CssSelector("#city"));
        private IWebElement postalCodeInput => Driver.FindElement(By.CssSelector("#postcode"));
        private IWebElement mobilePhoneInput => Driver.FindElement(By.CssSelector("#phone_mobile"));
        private IWebElement registerButton => Driver.FindElement(By.CssSelector("#submitAccount"));
        private SelectElement state => new SelectElement(Driver.FindElement(By.Id("id_state")));
        private IWebElement createAnAccountButton => Driver.FindElement(By.CssSelector("#SubmitCreate"));
        private IWebElement proceedToShippingButton => Driver.FindElement(By.CssSelector("#center_column > form > p > button"));
        private IWebElement termsOfServiceCheckbox => Driver.FindElement(By.CssSelector("#cgv"));
        private IWebElement proceedToPaymentButton => Driver.FindElement(By.CssSelector("#form > p > button"));
        private IWebElement payByCheckOption => Driver.FindElement(By.CssSelector("#HOOK_PAYMENT > div:nth-child(2) > div > p > a"));
        private IWebElement confirmOrderButton => Driver.FindElement(By.CssSelector("#cart_navigation > button"));
        private IWebElement orderConfirmation => Driver.FindElement(By.CssSelector("#center_column > p.alert"));
        private IWebElement backToOrdersButton => Driver.FindElement(By.CssSelector("#center_column > p.cart_navigation.exclusive > a"));
        private IWebElement orderStatus => Driver.FindElement(By.CssSelector("#order-list > tbody > tr > td.history_state > span"));
        public CartPage(IWebDriver webdriver) : base(webdriver) {}
        
        public void VerifyCartItemsNumber()
        {
            Assert.AreEqual("1 Product", productsQuantity.Text, "Wrong items number");
        }
        
        public void ClickProceedToCheckoutButton()
        {
            proceedToCheckoutButton.Click();
        }

        public void CreateNewAccount()
        {
            emailInput.SendKeys("anrl@kl.bn");
            createAnAccountButton.Click();
        }
        
        public void FillPersonalInformation()
        {
            firstNameInput.Clear();
            firstNameInput.SendKeys("Mike");
            lastNameInput.Clear();
            lastNameInput.SendKeys("Wallie");
            passwordInput.Clear();
            passwordInput.SendKeys("Catdog12345");
            firstName.Clear();
            firstName.SendKeys("Mike");
            lastName.Clear();
            lastName.SendKeys("Wallie");
            addressInput.Clear();
            addressInput.SendKeys("Po Box 226");
            cityInput.Clear();
            cityInput.SendKeys("Coffee Springs");
            state.SelectByText("Alabama");
            postalCodeInput.Clear();
            postalCodeInput.SendKeys("36318");
            mobilePhoneInput.Clear();
            mobilePhoneInput.SendKeys("(334) 996-0085");
            registerButton.Click();
        }

        public void ProceedToShipping()
        {
            proceedToShippingButton.Click();
        }

        public void AgreeToTermsOfService()
        {
            termsOfServiceCheckbox.Click();
        }
        
        public void ProceedToPayment()
        {
            proceedToPaymentButton.Click();
        }
        
        public void ChoosePaymentMethod()
        {
            payByCheckOption.Click();
        }
        public void ConfirmOrder()
        {
            confirmOrderButton.Click();
        }
        
        public void VerifyOrderIsConfirmed()
        {
            Assert.AreEqual("Your order on My Store is complete.", orderConfirmation.Text, "Wrong order confirmation");
            Assert.IsTrue(orderConfirmation.GetAttribute("class").Contains("alert-success"));
            backToOrdersButton.Click();
            Assert.AreEqual("On backorder", orderStatus.Text, "Wrong order status");
        }
    }
}