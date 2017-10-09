using System;
using System.Net.Http;
using System.Net.Http.Headers;
using BJSS.Api;
using TechTalk.SpecFlow;

namespace BJSS.Steps
{
    public class ApiSteps
    {
        private string baseUri = "https://regres.in/api/";

        [Given(@"something or other")]
        public void GivenSomethingOrOther()
        {
            // ScenarioContext.Current.Pending();
        }

        [When(@"I make a create call")]
        public void WhenIMakeACreateCall()
        {
            var user =  Reqres.GetUserAsync(2).Result;
        }

        [Then(@"I have successfully created something")]
        public void ThenIHaveSuccessfullyCreatedSomething()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I make a read call")]
        public void WhenIMakeAReadCall()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I can successfully read stuff")]
        public void ThenICanSuccessfullyReadStuff()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I make an update call")]
        public void WhenIMakeAnUpdateCall()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I have successfully updated something")]
        public void ThenIHaveSuccessfullyUpdatedSomething()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I make a delete call")]
        public void WhenIMakeADeleteCall()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I have successfully deleted something")]
        public void ThenIHaveSuccessfullyDeletedSomething()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
