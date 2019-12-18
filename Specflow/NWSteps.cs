using System;
using TechTalk.SpecFlow;

namespace SpecflowTests
{
    [Binding]
    public class NWSteps
    {
        [When(@"I click All product link")]
        public void WhenIClickAllProductLink()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"open All product page")]
        public void ThenOpenAllProductPage()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
