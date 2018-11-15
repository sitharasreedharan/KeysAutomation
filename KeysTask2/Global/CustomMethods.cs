using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using AventStack.ExtentReports;

namespace KeysTask2.Global
{
    class CustomMethods
    {
        //Method to find the webelements using placeholder values and to enter text
        public static void FindElementAndPerformAction(String PlaceholderValue, String strInputText)
        {
            var allTextBoxes = CommonMethods.driver.FindElements(By.XPath("//input[@type='text']"));
            foreach (var textBox in allTextBoxes)
            {
                var str = textBox.GetAttribute("placeholder");
                if (str.Contains(PlaceholderValue))
                {
                    Console.WriteLine("found the obj for " + PlaceholderValue);
                    textBox.SendKeys(strInputText);
                    textBox.SendKeys(Keys.Tab);
                    break;
                }

            }

        }

        //Method to find whether an element is present in a page
        public static bool IsElementPresent(By by)
        {
            bool IsElement = true;
            try
            {
                CommonMethods.driver.FindElement(by);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Element is not found" + ex.ToString());
                Base.test.Log(Status.Info, "Element is not found" + ex.ToString());
                IsElement = false;
            }
            return IsElement;
        }

        //Method to find whether an Alert is present 
        public static bool isAlertPresent()
        {
            bool isAlert = true;
            try
            {
                IAlert alert = CommonMethods.driver.SwitchTo().Alert();
            }
            catch (NoAlertPresentException Ex)
            {
                Console.WriteLine(Ex.ToString());
                Base.test.Log(Status.Info, "Alert is not found" + Ex.ToString());
                isAlert = false;
            }
            return isAlert;
        }
    }
}

