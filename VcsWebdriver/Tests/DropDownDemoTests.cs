using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using VcsWebdriver.Pages;
using System;
using VcsWebdriver.Drivers;

namespace VcsWebdriver.Tests
{
    class DropDownDemoTests
    {
        private static IWebDriver _driver;
        private static DropDownDemoPage _dropDownDemoPage;

        [OneTimeSetUp]
        public static void OpenBrowser()
        {
            _driver = CustomDrivers.GetChromeDriver();
            _dropDownDemoPage = new DropDownDemoPage(_driver);
        }


        [Test]
        public static void DropDownTest()
        {

            _dropDownDemoPage.DropDownSelect(DayOfWeek.Saturday).AssertDropDownMessage();


        }
        public static void CloserBrowser()
        {
            _driver.Quit();
        }

    }
}
