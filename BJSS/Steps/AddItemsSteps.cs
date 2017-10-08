
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BJSS.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace BJSS.Steps
{
    [Binding]
    public class AddItemsSteps
    {
        private const string EMAIL = "katiecookson@hotmail.com";
        private const string PASSWORD = "BJSSTest";

        [Given(@"I am logged in")]
        public void GivenIAmLoggedIn()
        {
            // maybe navigate should be a class?
            PageFactory.HomePage.NavigateTo();
           var loginButton = AssertHelper.SpinUntilVisible(PageFactory.WebDriver, PageFactory.HomePage.NavBar.LoginButton, 5);
           // PageFactory.HomePage.NavBar.LoginButton.Click();
           loginButton.Click();

            Assert.That(PageFactory.LoginPage.IsHit(), Is.True, "Login page was not loaded.");

            PageFactory.LoginPage.AlreadyRegisteredPage.EmailTextBox.Clear();
            PageFactory.LoginPage.AlreadyRegisteredPage.EmailTextBox.SendKeys(EMAIL);

            PageFactory.LoginPage.AlreadyRegisteredPage.PasswordTextBox.Clear();
            PageFactory.LoginPage.AlreadyRegisteredPage.PasswordTextBox.SendKeys(PASSWORD);

            PageFactory.LoginPage.AlreadyRegisteredPage.SubmitButton.Click();

            // System.Threading.Thread.Sleep(5000);

            //Assert.That(_myAccountPage.IsHit(), Is.True, "My Account Page was not hit");
            AssertHelper.SpinUntilHit(PageFactory.WebDriver, PageFactory.MyAccountPage, secondsTimeout: 5);
        }

        [When(@"I Quick View an item")]
        public void WhenIQuickViewAnItem()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I change the size of the item")]
        public void WhenIChangeTheSizeOfTheItem()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I add that item to my basket")]
        public void WhenIAddThatItemToMyBasket()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I continue shopping")]
        public void WhenIContinueShopping()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I Quick View a different item")]
        public void WhenIQuickViewADifferentItem()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I view the basket")]
        public void ThenIViewTheBasket()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the items are the correct size")]
        public void ThenTheItemsAreTheCorrectSize()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"their prices are correct")]
        public void ThenTheirPricesAreCorrect()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Total Products is the sum of the two items")]
        public void ThenTotalProductsIsTheSumOfTheTwoItems()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Total equals the Total Products \+ Shipping")]
        public void ThenTotalEqualsTheTotalProductsShipping()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I proceed through checkout to payment")]
        public void ThenIProceedThroughCheckoutToPayment()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
