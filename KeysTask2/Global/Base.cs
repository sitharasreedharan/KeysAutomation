using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using KeysTask2.Config;
using KeysTask2.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace KeysTask2.Global
{
    public class Base
    {
        public static string BrowserName = KeysResource.BrowserName.ToUpper();
        public static string ExcelDataPath = KeysResource.ExcelDataPath;
        public static string ScreenshotPath = KeysResource.ScreenshotPath;
        public static string ReportPath = KeysResource.ReportPath;
        public static ExtentTest test;
        public static ExtentReports extent;
        public static ExtentHtmlReporter htmlReports;

        [SetUp]
        public void StartTest()
        {   //Initialising extent report
            htmlReports = new ExtentHtmlReporter(ReportPath+ "ExecutionReport"+DateTime.Now.ToString("_dd-mm-yyyy_mss")+ ".html");
            extent = new ExtentReports();
            htmlReports.Configuration().Theme = Theme.Standard;
            htmlReports.LoadConfig(KeysResource.ExtentReportConfig);
            extent.AttachReporter(htmlReports);
            test = extent.CreateTest("Keys-Property Tests");
            //Login
            CommonMethods.LaunchBrowser(BrowserName);
            LoginPO LO = new LoginPO();
            LO.Login();

        }
        [TearDown]
        public void EndTest()
        {
            test.Log(Status.Info, "End of the Test execution: " + CommonMethods.SaveScreenshot());
            extent.Flush();   //calling Flush writes everything to the log file (Reports)
            CommonMethods.driver.Close();           
        }

    }
    
}
