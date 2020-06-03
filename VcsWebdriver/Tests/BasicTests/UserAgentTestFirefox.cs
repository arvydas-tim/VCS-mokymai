using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace VcsWebdriver
{
    public class TestFirefox
    {
        private static IWebDriver testdriver;

        [OneTimeSetUp]
        public static void OpenBrowser()
        {
            testdriver = new FirefoxDriver();
            testdriver.Url = "https://developers.whatismybrowser.com/";
            testdriver.Manage().Window.Maximize();
            Thread.Sleep(1000);
        }
        [Test]
        public static void TestUserAgent()
        {
            testdriver.FindElement(By.CssSelector(".button-next-to-input")).Click();
            testdriver.FindElement(By.CssSelector(".simple-major")).Click();
            string userAgent = "Firefox 76";
            string userAgentOutput = testdriver.FindElement(By.ClassName("simple-major")).Text;
            //Assert.AreEqual(userAgent, userAgentOutput, "Neatpazino narsykles");
            Assert.True(userAgentOutput.Contains(userAgent), "Neatpazino narsykles");
            //Assert.That(testdriver.FindElement(By.CssSelector(".simple-major")).Text, Is.EqualTo("Firefox 76 on Windows 10"));
        }

        [OneTimeTearDown]
        public static void CloseBrowser()
        {
            testdriver.Quit();
        }




    }
}
