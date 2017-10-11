﻿using System;
using BJSS.Api;
using BJSS.Enums;
using BJSS.Pages;
using BJSS.Pages.Factories;
using BJSS.TestObjects;
using TechTalk.SpecFlow;

namespace BJSS.BddSteps
{
    [Binding]
    public class BuyItemsSteps
    {
        [Given(@"I am logged in")]
        public void GivenIAmLoggedIn()
        {
            PageFactory.HomePage.NavigateTo();
            var loginButton = WaitHelper.SpinUntilVisible(PageFactory.WebDriver, PageFactory.HomePage.NavBar.LoginButton, AppSettings.TimeoutInSeconds);
            loginButton.Click();

            var user = new AutomationPracticeUserBuilder().HasAccount().Build();

            WaitHelper.SpinUntilVisible(PageFactory.WebDriver, PageFactory.LoginPage.AlreadyRegisteredPage.EmailTextBox, AppSettings.TimeoutInSeconds, "Login page was not hit in time.");

            PageFactory.LoginPage.AlreadyRegisteredPage.EmailTextBox.Clear();
            PageFactory.LoginPage.AlreadyRegisteredPage.EmailTextBox.SendKeys(user.Email);

            PageFactory.LoginPage.AlreadyRegisteredPage.PasswordTextBox.Clear();
            PageFactory.LoginPage.AlreadyRegisteredPage.PasswordTextBox.SendKeys(user.Password);

            PageFactory.LoginPage.AlreadyRegisteredPage.SubmitButton.Click();

            WaitHelper.SpinUntilHit(PageFactory.WebDriver, PageFactory.MyAccountPage, AppSettings.TimeoutInSeconds);
        }

        [When(@"I Quick View an item")]
        public void WhenIQuickViewAnItem()
        {
            PageFactory.HomePage.NavigateTo();

            var featureditems = PageFactory.HomePage.FeaturedItems;

            // todo : make this view quickview (used other way so I can get the rest of the stuff done)
            featureditems[0].Click();

            /*Actions builder = new Actions(PageFactory.WebDriver);
            builder.MoveToElement(featureditems[0]).Perform();*/

            // By locator = By.ClassName("quick-view");

            //Actions builder = new Actions(PageFactory.WebDriver);
          //  IWebElement element = featureditems[0];
           // builder.MoveToElement(element).Build().Perform();
            // driver.manage().timeouts().implicitlyWait(10, TimeUnit.Seconds)
        }

        [When(@"I change the size of the item")]
        public void WhenIChangeTheSizeOfTheItem()
        {
            //ScenarioContext.Current.Pending();
        }

        [When(@"I add that item to my basket")]
        public void WhenIAddThatItemToMyBasket()
        {
            PageFactory.ProductPage.BuyButton.Click();
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

        [AfterScenario()]
        public void AfterScenario()
        {
            PageFactory.CleanUp();
        }

        [Given(@"I am using (.*)")]
        public void GivenIAmUsing(string browserString)
        {
            // todo: make PageFactory.Browser into Enum
            var browser = (Browser)Enum.Parse(typeof(Browser), browserString);
            PageFactory.Browser = browser;
        }
    }
}
