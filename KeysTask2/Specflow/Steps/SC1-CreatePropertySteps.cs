using System;
using KeysTask2.Global;
using KeysTask2.PageObjects;
using TechTalk.SpecFlow;

namespace KeysTask2.Specflow.Steps
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        [Given(@"I have logged in to application")]
        public void GivenIHaveLoggedInToApplication()
        {
            CommonMethods.LaunchBrowser(Base.BrowserName);
            LoginPO loObj = new LoginPO();
            loObj.Login();
        }
        
        [Given(@"I have entered Property Details")]
        public void GivenIHaveEnteredPropertyDetails()
        {
            PropertyDetailsPO po = new PropertyDetailsPO();
            po.EnterPropertyDetails("PropertyDetails", 1);
        }
        
        [Given(@"I have entered Financial Details")]
        public void GivenIHaveEnteredFinancialDetails()
        {
            FinanceDetailsPO fd = new FinanceDetailsPO();
            fd.EnterFinanceDetails("FinanceDetails", 1);
        }
        
        [Then(@"New Property should be created")]
        public void ThenNewPropertyShouldBeCreated()
        {
           // ScenarioContext.Current.Pending();
        }
    }
}
