using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace BJSS.Steps
{
    public class BuyItemsSteps
    {
        // remember to put in ability to use different browsers

        [Given(@"I have bought items")]
        public void GivenIHaveBoughtItems()
        {
            ScenarioContext.Current.Pending();
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

        [Given(@"I buy items")]
        public void GivenIBuyItems()
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
