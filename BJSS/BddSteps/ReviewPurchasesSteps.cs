using TechTalk.SpecFlow;

namespace BJSS.BddSteps
{
    [Binding]
    public class ReviewPurchasesSteps
    {
        [Given(@"I have bought items")]
        public void GivenIHaveBoughtItems()
        {
            var buySteps = new BuyItemsSteps();
            buySteps.GivenIAmLoggedIn();
            buySteps.WhenIQuickViewAnItem();
            buySteps.WhenIAddThatItemToMyBasket();
            buySteps.ThenIViewTheBasket();
            buySteps.ThenIProceedThroughCheckoutToPayment();
        }

        [When(@"I view previous orders")]
        public void WhenIViewPreviousOrders()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I select an item from my previous order")]
        public void WhenISelectAnItemFromMyPreviousOrder()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I add a comment")]
        public void WhenIAddAComment()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the comment appears under Messages")]
        public void ThenTheCommentAppearsUnderMessages()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"the test fails")]
        public void WhenTheTestFails()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I can successfully capture a screen-grab")]
        public void ThenICanSuccessfullyCaptureAScreen_Grab()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
