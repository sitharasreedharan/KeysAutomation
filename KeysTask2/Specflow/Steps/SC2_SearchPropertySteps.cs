using System;
using KeysTask2.PageObjects;
using TechTalk.SpecFlow;

namespace KeysTask2
{
    [Binding]
    public class SC2_SearchPropertySteps
    {
        [When(@"I have entered search item")]
        public void WhenIHaveEnteredSearchItem()
        {
            SearchPO se = new SearchPO();
            se.SearchForProperty("SearchProperty", 1);
        }
        
        [Then(@"the search result should be shown")]
        public void ThenTheSearchResultShouldBeShown()
        {
            //ScenarioContext.Current.Pending();
        }
    }
}
