using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using KeysTask2.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Chrome;
using KeysTask2.Config;

namespace KeysTask2.PageObjects
{
    class LoginPO
    {
        //create constructor
        public LoginPO()
        {
#pragma warning disable CS0618 // Type or member is obsolete
            PageFactory.InitElements(CommonMethods.driver, this);
            //CommonMethods.driver = new ChromeDriver();
#pragma warning restore CS0618 // Type or member is obsolete
        }

        [FindsBy(How = How.Id, Using = "UserName")]
        public IWebElement UserName { get; set; }
        
        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        public IWebElement loginButton { get; set; }

        [FindsBy(How = How.LinkText, Using = "Skip")]
        public IWebElement skipButton { get; set; }
      
        //Login function
        public void Login()
        {
            ExcelLib.PopulateInCollection(Base.ExcelDataPath, "Login");           
            Console.WriteLine("Opening the application");
            CommonMethods.driver.Navigate().GoToUrl(KeysResource.Url);
            CommonMethods.driver.Manage().Window.Maximize();
            Thread.Sleep(1000);

            UserName.SendKeys(ExcelLib.ReadData(1, "Username"));
            Password.SendKeys(ExcelLib.ReadData(1, "Password"));

            loginButton.Submit();
            Assert.AreEqual("Dashboard", CommonMethods.driver.Title);
            if (CommonMethods.driver.Title == "Dashboard")
                Base.test.Log(Status.Pass, "Logged in to application successfully");
            else
                Base.test.Log(Status.Fail, "Failed to login to application.Pls check screenshot "+ CommonMethods.SaveScreenshot());
            
            Console.WriteLine("Logged in to application");        

            //Clicking on Skip button
            if(CustomMethods.IsElementPresent(By.LinkText("Skip")))
            {
                CommonMethods.driver.FindElement(By.LinkText("Skip")).Click();
                CommonMethods.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(80);
                Thread.Sleep(1000);
                Base.test.Log(Status.Info, "Clicked on Skip button");
            }
           
        }

    }
}
