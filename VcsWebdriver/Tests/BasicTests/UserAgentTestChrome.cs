using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace VcsWebdriver
{
    public class TestChrome
    {
        private static IWebDriver testdriver;

        [OneTimeSetUp]
        public static void OpenBrowser()
        {
            testdriver = new ChromeDriver();
            testdriver.Url = "https://developers.whatismybrowser.com/";
            testdriver.Manage().Window.Maximize();
            Thread.Sleep(1000);
        }

        [Test]
        public static void TestUserAgent()
        {
            testdriver.FindElement(By.CssSelector(".button-next-to-input")).Click();
            testdriver.FindElement(By.CssSelector(".simple-major")).Click();
            Assert.That(testdriver.FindElement(By.CssSelector(".simple-major")).Text, Is.EqualTo("Chrome 83 on Windows 10"));
        }


        [OneTimeTearDown]
        public static void CloseBrowser()
        {
            testdriver.Quit();
        }




    }
}