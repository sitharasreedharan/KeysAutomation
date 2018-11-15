using System;
using System.Collections.Generic;
using System.Linq;
//using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using KeysTask2.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace KeysTask2.PageObjects
{
    class SearchPO
    {
        //create constructor
        public SearchPO()
        {
#pragma warning disable CS0618 // Type or member is obsolete
            PageFactory.InitElements(CommonMethods.driver, this);
#pragma warning restore CS0618 // Type or member is obsolete
        }
        
        [FindsBy(How = How.XPath, Using = "/ html / body / div[1] / div / div[2] / div[1]")]
        private IWebElement mnuOwner { get; set; }

        [FindsBy(How = How.LinkText, Using = "Properties")]
        private IWebElement mnuSubProperties { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='SearchBox']")]
        private IWebElement barSearch { set; get; }

        [FindsBy(How = How.XPath, Using = "//form[@method='get']/div/input")]
        private IWebElement iconSearch { set; get; }

        public void SearchForProperty(string sheetName, int datarow)
        {
            ExcelLib.PopulateInCollection(Base.ExcelDataPath, sheetName);
            String SearchItem = ExcelLib.ReadData(datarow, "SearchItem");

            PropertyDetailsPO.SelectMainMenus(mnuOwner,mnuSubProperties);
            barSearch.SendKeys(SearchItem+Keys.Enter);
            //iconSearch.Click();
            CommonMethods.wait(5);
            string ExpectedValue = SearchItem;
            if (CustomMethods.IsElementPresent(By.XPath("//*[@id='main-content']/div/div[1]/div/div[1]/fieldset/div[3]/div[1]/div[1]/div/div/div[2]/div[1]/div[1]/a/h3")))
            {
                string ActualValue = CommonMethods.driver.FindElement(By.XPath("//*[@id='main-content']/div/div[1]/div/div[1]/fieldset/div[3]/div[1]/div[1]/div/div/div[2]/div[1]/div[1]/a/h3")).Text;

                if (ExpectedValue == ActualValue)
                    Base.test.Log(Status.Pass, "Test Passed, Search successfull");
                else
                    Base.test.Log(Status.Fail, "Test Failed, Search Unsuccessfull.Pls check "+CommonMethods.SaveScreenshot());
            }
            else
            {
                Base.test.Log(Status.Fail, "Can not find the seacrched item, Search Unsuccessfull.Pls check "+ CommonMethods.SaveScreenshot());
            }
        }
    }
    
}
