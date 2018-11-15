using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
//using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace KeysTask2.Global
{
    class CommonMethods
    {
        //Initialise the browser    
        public static IWebDriver driver { get; set; }

        public static void LaunchBrowser(string browserName)
        {
            switch (browserName)
            {
                case "FIREFOX":
                    CommonMethods.driver = new FirefoxDriver();
                    break;
                case "CHROME":
                    CommonMethods.driver = new ChromeDriver();
                    break;
                case "IE":
                    CommonMethods.driver = new InternetExplorerDriver();
                    break;
            }            
            CommonMethods.driver.Manage().Window.Maximize();           
        }

        public static void wait(int time)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(time);
        }

        public static IWebElement WaitForElement(IWebDriver driver, By by, int timeOutinSeconds)
        {
            OpenQA.Selenium.Support.UI.WebDriverWait wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
            return(wait.Until(ExpectedConditions.ElementIsVisible(by)));            
        }

        public static string SaveScreenshot() 
            {
                var folderLocation = (Base.ScreenshotPath);   
                if (!System.IO.Directory.Exists(folderLocation))
                {
                    System.IO.Directory.CreateDirectory(folderLocation);
                }

                var screenShot = ((ITakesScreenshot)CommonMethods.driver).GetScreenshot();
                var fileName = new StringBuilder(folderLocation);
                fileName.Append("Screenshot");
                fileName.Append(DateTime.Now.ToString("_dd-mm-yyyy_mss"));                
                fileName.Append(".jpeg");
                screenShot.SaveAsFile(fileName.ToString(), ScreenshotImageFormat.Jpeg);
                return fileName.ToString();
            }

        }

}


