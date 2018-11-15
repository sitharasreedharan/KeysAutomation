using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using KeysTask2.Config;
using KeysTask2.Global;
using TechTalk.SpecFlow;

namespace KeysTask2.Specflow
{
    [Binding]
    public sealed class Hooks1
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        //Global Variable for Extend report
        //public static ExtentTest test;
        //public static ExtentReports extent;
        //public static ExtentHtmlReporter htmlReports;    


        [BeforeTestRun]
        public static void InitializeReport()

        {
            //Initialize Extent report before test starts
            Base.htmlReports = new ExtentHtmlReporter(Base.ReportPath + "ExecutionReport" + DateTime.Now.ToString("_dd-mm-yyyy_mss") + ".html");
            Base.extent = new ExtentReports();
            Base.htmlReports.Configuration().Theme = Theme.Standard;
            Base.extent.AttachReporter(Base.htmlReports);
            Base.test = Base.extent.CreateTest("Specflow-Keys-Property Tests");
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            Base.extent.Flush();
            CommonMethods.driver.Close();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            //TODO: implement logic that has to run before executing each scenario
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
        }
    }
}
