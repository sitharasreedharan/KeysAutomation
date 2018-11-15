using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using KeysTask2.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace KeysTask2.PageObjects
{
    class PropertyDetailsPO
    {
        //create constructor
        public PropertyDetailsPO()
        {
#pragma warning disable CS0618 // Type or member is obsolete
            PageFactory.InitElements(CommonMethods.driver, this);
#pragma warning restore CS0618 // Type or member is obsolete
        }
        [FindsBy(How = How.XPath, Using = "/ html / body / div[1] / div / div[2] / div[1]")]
        public IWebElement mnuOwner { get; set; }

        [FindsBy(How = How.LinkText, Using = "Properties")]
        public IWebElement mnuSubProperties { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(@href, '/PropertyOwners/Property/AddNewProperty?returnUrl=%2FPropertyOwners')]")]
        public IWebElement btnAddNewProperty { get; set; }


        [FindsBy(How = How.XPath, Using = "//input[@name='propertyName']")]
        public IWebElement txtPropertyName { get; set; }

        [FindsBy(How = How.Name, Using = "searchAddress")]
        public IWebElement ddlSearchAddress { get; set; }

        [FindsBy(How = How.Id, Using = "route")]
        public IWebElement txtStreet { get; set; }

        [FindsBy(How = How.Id, Using = "region")]
        public IWebElement txtRegion { get; set; }

        [FindsBy(How = How.ClassName, Using = "add-prop-desc")]
        public IWebElement txaDescription { get; set; }

        [FindsBy(How = How.Name, Using = "test")]
        public IWebElement chkOwnerOccupied { get; set; }

        [FindsBy(How = How.Name, Using = "next")]
        public IWebElement btnNext { get; set; }
        

        public void EnterPropertyDetails(string sheetName,int datarow)
        {
            ExcelLib.PopulateInCollection(Base.ExcelDataPath, sheetName);  //PropertyDetails
            //int datarow = 1;
            String PropertyName = ExcelLib.ReadData(datarow, "PropertyName");
            String PropertyType = ExcelLib.ReadData(datarow, "PropertyType");
            String SearchAddress = ExcelLib.ReadData(datarow, "SearchAddress");
            String Number = ExcelLib.ReadData(datarow, "Number");
            String Street = ExcelLib.ReadData(datarow, "Street");
            String Suburb = ExcelLib.ReadData(datarow, "Suburb");
            String City = ExcelLib.ReadData(datarow, "City");
            String PostCode = ExcelLib.ReadData(datarow, "PostCode");
            String Region = ExcelLib.ReadData(datarow, "Region");
            String Description = ExcelLib.ReadData(datarow, "Description");
            String TargetRent = ExcelLib.ReadData(datarow, "TargetRent");
            String RentType = ExcelLib.ReadData(datarow, "RentType");
            String LandArea = ExcelLib.ReadData(datarow, "LandArea");
            String FloorArea = ExcelLib.ReadData(datarow, "FloorArea");
            String Bedrooms = ExcelLib.ReadData(datarow, "Bedrooms");
            String Bathrooms = ExcelLib.ReadData(datarow, "Bathrooms");
            String Carparks = ExcelLib.ReadData(datarow, "Carparks");
            String YearBuilt = ExcelLib.ReadData(datarow, "YearBuilt");
            
            //navigate to Propery details page

            SelectMainMenus(mnuOwner, mnuSubProperties);
            btnAddNewProperty.Click();
            //Enter all property details           
            txtPropertyName.SendKeys(PropertyName);
            if (SearchAddress != null)
            {
                ddlSearchAddress.SendKeys(SearchAddress);
                Thread.Sleep(1000);
                ddlSearchAddress.SendKeys(Keys.Down + Keys.Enter);
            }
            else
            {
                var NoCityPostcode = CommonMethods.driver.FindElements(By.XPath("//*[@id='street_number']"));//Number,City,Postcode fields are having the same ID as locators
                IWebElement txtNumber = NoCityPostcode.ElementAt(0);
                txtNumber.SendKeys(Number);
                txtStreet.SendKeys(Street);
                CustomMethods.FindElementAndPerformAction("Suburb", Suburb);
                CustomMethods.FindElementAndPerformAction("City", City);
                CustomMethods.FindElementAndPerformAction("PostCode", PostCode);
                txtRegion.SendKeys(Region);

            }

            txaDescription.SendKeys(Description);
            CustomMethods.FindElementAndPerformAction("Rent Amount", TargetRent);
            CustomMethods.FindElementAndPerformAction("Bedrooms", Bedrooms);
            CustomMethods.FindElementAndPerformAction("Bathrooms", Bathrooms);
            CustomMethods.FindElementAndPerformAction("car parks", Carparks);
            CustomMethods.FindElementAndPerformAction("Year Built", YearBuilt);
            btnNext.Click();
        }


        public static void SelectMainMenus(IWebElement mainMenu, IWebElement subMenu)
        {
            mainMenu.Click();
            CommonMethods.wait(2);
            subMenu.Click();
            CommonMethods.wait(1);
        }


    }
}
