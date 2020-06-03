using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace VcsWebdriver
{
    class TestDemo2
    {
        private static IWebDriver testdriver;

        [Test]
        public static void TryFirefox()
        {
            IWebDriver testdriver = new FirefoxDriver();
            testdriver.Url = "https://login.yahoo.com/";
            //Thread.Sleep(2000);
            IWebElement prisijungimoVardas = testdriver.FindElement(By.Name("username"));
            IWebElement prisijungimoVardasPagalId = testdriver.FindElement(By.Id("login-username"));
            IWebElement prisijungimoVardasPagalClassname = testdriver.FindElement(By.ClassName("phone-no"));
            prisijungimoVardas.SendKeys("test");
            Thread.Sleep(2000);
        }

        [Test]
        public static void TryChrome()
        {
            IWebDriver testdriver = new ChromeDriver();
            testdriver.Url = "https://login.yahoo.com/";
            Thread.Sleep(2000);
           
        }

        [TearDown]
        public static void CloseBrowser()
        {
            testdriver.Quit();
        }
    }
}
