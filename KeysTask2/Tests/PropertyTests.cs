using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using KeysTask2.Config;
using KeysTask2.Global;
using KeysTask2.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using AventStack.ExtentReports;

namespace KeysTask2.Tests
{
    class PropertyTests:Base
    {
        [Test]
        public void TestSuite1()
        {
            //Create a property
            Base.test.Log(Status.Info, "Test to create a new property");
            FinanceDetailsPO fd = new FinanceDetailsPO();
            PropertyDetailsPO po = new PropertyDetailsPO();
            po.EnterPropertyDetails("PropertyDetails",1);
            fd.EnterFinanceDetails("FinanceDetails", 1);

            //Create second property
            Base.test.Log(Status.Info, "Test to create a new property");
            FinanceDetailsPO fd2 = new FinanceDetailsPO();
            PropertyDetailsPO po2 = new PropertyDetailsPO();
            po2.EnterPropertyDetails("PropertyDetails", 2);
            fd2.EnterFinanceDetails("FinanceDetails", 2);

            //Searchproperty  
            Base.test.Log(Status.Info, "Test to search for property");
            SearchPO se = new SearchPO();
            se.SearchForProperty("SearchProperty", 1);
        }

        //To execute as individual tests
        [Test]
        public void Testcase1()
        {
            //Create a property
            FinanceDetailsPO fd = new FinanceDetailsPO();
            PropertyDetailsPO po = new PropertyDetailsPO();
            po.EnterPropertyDetails("PropertyDetails", 1);
            fd.EnterFinanceDetails("FinanceDetails", 1);
        }
        [Test]
        public void Testcase2()
        {
            //Create second property
            FinanceDetailsPO fd2 = new FinanceDetailsPO();
            PropertyDetailsPO po2 = new PropertyDetailsPO();
            po2.EnterPropertyDetails("PropertyDetails", 2);
            fd2.EnterFinanceDetails("FinanceDetails", 2);
        }
        [Test]
        public void Testcase3()
        {
            SearchPO se = new SearchPO();
            se.SearchForProperty("SearchProperty", 1);
        }
    }
}
