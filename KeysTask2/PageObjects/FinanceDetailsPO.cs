using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using KeysTask2.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace KeysTask2.PageObjects
{
    class FinanceDetailsPO
    {
        //create constructor
        public FinanceDetailsPO()
        {
#pragma warning disable CS0618 // Type or member is obsolete
            PageFactory.InitElements(CommonMethods.driver, this);
#pragma warning restore CS0618 // Type or member is obsolete
        }

        [FindsBy(How = How.Name, Using = "purchasePrice")]
        public IWebElement txtPurchasePrice { get; set; }

        [FindsBy(How = How.Name, Using = "mortgagePrice")]
        public IWebElement txtMortgage { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='financeSection']/div[1]/div[3]/div[1]/input")]
        public IWebElement txtHomeValue { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='financeSection']/div[1]/div[4]/div")]                                           
        public IWebElement ddlHomeValueType { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='financeSection']/div[1]/div[4]/div/div[2]/div[1]")]
        public IWebElement HomeValueTypeCurrent { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//*[@id='financeSection']/div[1]/div[4]/div/div[2]/div[2]")]
        public IWebElement HomeValueTypeEstimated { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='financeSection']/div[1]/div[4]/div/div[2]/div[3]")]
        public IWebElement HomeValueTypeRegistered { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='financeSection']/div[8]/button[2]")]
        public IWebElement btnFinanceSave { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='ok']")]
        public IWebElement btnAddTenantsYes { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='no']")]
        public IWebElement btnAddTenantsNo { get; set; }


        public void EnterFinanceDetails(string sheetName, int datarow)
        {
            ExcelLib.PopulateInCollection(Base.ExcelDataPath, sheetName);//FinanceDetails
            String PurchasePrice = ExcelLib.ReadData(datarow, "PurchasePrice");
            String Mortgage = ExcelLib.ReadData(datarow, "Mortgage");
            String HomeValue = ExcelLib.ReadData(datarow, "HomeValue");
            String HomeValueType = ExcelLib.ReadData(datarow, "HomeValueType");

            txtPurchasePrice.SendKeys(PurchasePrice);
            txtMortgage.SendKeys(Mortgage);
            txtHomeValue.SendKeys(HomeValue);
            
            ddlHomeValueType.Click();
            CommonMethods.wait(2);
            if (HomeValueType == "Current")
                HomeValueTypeCurrent.Click();
            else if (HomeValueType == "Estimated")
                HomeValueTypeEstimated.Click();
            else if (HomeValueType == "Registered")
                HomeValueTypeRegistered.Click();

            //Click save
            btnFinanceSave.Click();
            CommonMethods.wait(8);

            if (btnAddTenantsNo.Displayed)
            {
                btnAddTenantsNo.Click();
                CommonMethods.wait(2);
                Base.test.Log(Status.Pass, "A new property created successfully.Pls check screenshot " + CommonMethods.SaveScreenshot());
            }
            else
            {
                Base.test.Log(Status.Fail, "Property is not created successfully.Pls check screenshot " + CommonMethods.SaveScreenshot());
            }           

        }
    }
    
}
