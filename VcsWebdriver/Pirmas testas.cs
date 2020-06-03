using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace VcsWebdriver
{
    class Pirmas_testas
    {
        private static IWebDriver testdriver;

        [Test]
        public static void TextTest()
        {
            IWebDriver testdriver = new FirefoxDriver();
            testdriver.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            Thread.Sleep(1000);
            testdriver.FindElement(By.Id("at-cv-lightbox-close")).Click();
            IWebElement userTextInput = testdriver.FindElement(By.Id("user-message"));
            userTextInput.SendKeys("test text");
            testdriver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[1]/div[2]/form/button")).Click();
            IWebElement userTextOutput = testdriver.FindElement(By.Id("display"));
            Assert.AreEqual("test text", userTextOutput.Text, "laukelis neveikia");
            Thread.Sleep(2000);
            testdriver.Quit();
        }

        [Test]
        public static void TwoFieldsTest()
        {
            IWebDriver testdriver = new FirefoxDriver();
            testdriver.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            Thread.Sleep(1000);
            testdriver.FindElement(By.Id("at-cv-lightbox-close")).Click();
            int a = 10;
            int b = 15;
            IWebElement field1 = testdriver.FindElement(By.Id("sum1"));
            field1.SendKeys($"{a}");
            IWebElement field2 = testdriver.FindElement(By.Id("sum2"));
            field2.SendKeys($"{b}");
            testdriver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/div[2]/form/button")).Click();
            IWebElement testOutput = testdriver.FindElement(By.Id("displayvalue"));
            Assert.AreEqual(a+b, testOutput, "laukelis neveikia");
            Thread.Sleep(2000);
            testdriver.Quit();

        }

        //[TearDown]
        //public static void CloseBrowser()
        //{
        //    testdriver.Quit();
        //}
    }
}
