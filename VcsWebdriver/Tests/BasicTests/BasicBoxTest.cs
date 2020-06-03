using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using VcsWebdriver.Pages;

namespace VcsWebdriver
{
    class Pirmas_testas
    {

        private static IWebDriver testdriver;

        [OneTimeSetUp]
        public static void SetuUpFirefox()
        {
            testdriver = new FirefoxDriver();
            testdriver.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            Thread.Sleep(500);
            testdriver.Manage().Window.Maximize();
            Thread.Sleep(500);
            //testdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            testdriver.FindElement(By.Id("at-cv-lightbox-close")).Click();
        }



        [Test]
        public static void EnterMessageTestas()
        {
            string testMessage = "mano pranesimas";

            var page = new BasicFirstFromDemoPage(testdriver);
            page.EnterMessage(testMessage);
            page.PushShowMessageButton();
            page.AssertShownMessage(testMessage);
        }


        [Test]
        public static void TextTest()
        {
            IWebElement userTextInput = testdriver.FindElement(By.Id("user-message"));
            string testText = "test text";
            userTextInput.SendKeys(testText);
            testdriver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[1]/div[2]/form/button")).Click();
            IWebElement userTextOutput = testdriver.FindElement(By.Id("display"));
            Assert.AreEqual(testText, userTextOutput.Text, "output laukelis nepalyginamas/neveikia");

        }

        [Test]
        public static void TwoFieldsTest1()
        {
            int a = 2;
            int b = 2;
            string aPlusb = Convert.ToString(a + b); // konvertuojam matematinio veiksmo rezultata i string
            IWebElement field1 = testdriver.FindElement(By.Id("sum1"));
            field1.SendKeys($"{a}");
            IWebElement field2 = testdriver.FindElement(By.Id("sum2"));
            field2.SendKeys($"{b}");
            testdriver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/div[2]/form/button")).Click();
            IWebElement testOutput = testdriver.FindElement(By.Id("displayvalue"));
            Assert.AreEqual(aPlusb, testOutput.Text, "output laukelis nepalyginamas/neveikia"); //.text vercia elemento reiksme i string

        }
        [Test]
        public static void TwoFieldsTest2()
        {
            int a = -5;
            int b = 3;
            string aPlusb = Convert.ToString(a + b); // konvertuojam matematinio veiksmo rezultata i teksta
            IWebElement field1 = testdriver.FindElement(By.Id("sum1"));
            field1.SendKeys($"{a}");
            IWebElement field2 = testdriver.FindElement(By.Id("sum2"));
            field2.SendKeys($"{b}");
            testdriver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/div[2]/form/button")).Click();
            IWebElement testOutput = testdriver.FindElement(By.Id("displayvalue"));
            Assert.AreEqual(aPlusb, testOutput.Text, "output laukelis nepalyginamas/neveikia"); //.text vercia elemento reiksme i string

        }
        [Test]
        public static void TwoFieldsTest3()
        {
            IWebElement field1 = testdriver.FindElement(By.Id("sum1"));
            field1.SendKeys("a");
            IWebElement field2 = testdriver.FindElement(By.Id("sum2"));
            field2.SendKeys("b");
            testdriver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/div[2]/form/button")).Click();
            IWebElement testOutput = testdriver.FindElement(By.Id("displayvalue"));
            Assert.AreEqual("NaN", testOutput.Text, "output laukelis nepalyginamas/neveikia");

        }
        //Tie patys test case naudojant metodus
        [TestCase(2, 2, TestName = "Dvieju teigiamu skaiciu suma")]
        [TestCase(-3, 5, TestName = "Vieno teigiamo ir vieno neigiamo skaiciaus suma")]
        public static void TestSumWithPageObject(int a, int b)
        {
            var page = new BasicFirstFromDemoPage(testdriver);
            page.EnterNumbers(a,b);
            page.ClickSumosMygtuka();
            page.PatikrintiRezultata((a + b).ToString());
        }

        // Kaip atrodytu namu darbu 3 testai tvarkingai su testcase'ais

        //[TestCase(10, 15)]
        //[TestCase(2, 2, TestName = "Dvieju teigiamu skaiciu suma")]
        //[TestCase(-3, 5, TestName = "Vieno teigiamo ir vieno neigiamo skaiciaus suma")]
        //public static void TwoFieldsTest(int a, int b)
        //{ 
        //    var field1 = testdriver.FindElement(By.Id("sum1"));
        //    var field2 = testdriver.FindElement(By.Id("sum2"));

        //    field1.Clear();
        //    field2.Clear();

        //    field1.SendKeys($"{a}");
        //    field2.SendKeys(b.ToString());// sita ir virs eilute vienodos, skiriasi sintakse

        //    testdriver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/div[2]/form/button")).Click();
        //    IWebElement testOutput = testdriver.FindElement(By.Id("displayvalue"));

        //    Assert.AreEqual((a + b).ToString(), testOutput.Text, "output laukelis nepalyginamas/neveikia");
        //}

        [OneTimeTearDown]
        public static void CloseBrowser()
        {
            testdriver.Quit();
        }

    }
}
