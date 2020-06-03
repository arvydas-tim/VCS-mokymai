using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using VcsWebdriver.Pages;

namespace VcsWebdriver.Tests
{
    class CheckboxDemoTests
    {
        private static IWebDriver _driver;
        private static CheckboxDemoPage _checkboxDemoPage;

        [OneTimeSetUp]
        public static void OpenBrowser()
        {
            _driver = new FirefoxDriver();
            _driver.Manage().Window.Maximize();
            _driver.Url = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";
            //Thread.Sleep(5000);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _checkboxDemoPage = new CheckboxDemoPage(_driver);      
        }
        [Order (1)]
        [Test]
        public void SingleBoxTest()
        {
            _checkboxDemoPage
                .CheckSingleBox()
                .AssertSingleBoxStatusMessage();
        }
        [Order(2)]
        [Test]
        public void MultipleBoxTest()
        {
            _checkboxDemoPage
                .ClickCheckBoxA()
                .ClickCheckBoxB()
                .ClickCheckBoxC()
                .ClickCheckBoxD()
                .AssertUncheckAllButtonStatus();
        }
        [Order(3)]
        [Test]
        public void MultipleBoxTest2()
        {
            _checkboxDemoPage
                .ClickCheckBoxA()
                .ClickCheckBoxB()
                .ClickCheckBoxC()
                .ClickCheckBoxD()
                .ClickCheckAllButton()
                .AssertAllCheckboxStatusUnchecked();
        }
        [TearDown]
        public static void UncheckBoxes()
        {
            _checkboxDemoPage.UncheckAllBoxes();
        }
        [OneTimeTearDown]
        public static void CloserBrowser()
        {
            _driver.Quit();
        }


    }
}
