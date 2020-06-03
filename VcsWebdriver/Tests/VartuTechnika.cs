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
    class VartuTechnika
    {
        private static IWebDriver testdriver;


        [OneTimeSetUp]
        public static void OpenBrowser()
        {
            testdriver = new FirefoxDriver();
            testdriver.Url = "http://vartutechnika.lt/";
            testdriver.Manage().Window.Maximize();
            Thread.Sleep(2000);
        }
       

      

        [TestCase(2000, 2000, true ,false, "665.98", TestName ="2000x2000 su aut" )]
        [TestCase(4000, 2000, true, true, "1006.43", TestName = "4000x2000 su mont su aut")]
        [TestCase(4000, 2000, false, false, "692.35", TestName = "4000x2000")]
        [TestCase(5000, 2000, false, true, "989.21", TestName = "5000x2000 su mont")]
        public static void KainosSkaiciavimas(int height, int width, bool automatika, bool montavimas, string expectedkaina)
        {
            IWebElement field1 = testdriver.FindElement(By.Id("doors_width"));
            IWebElement field2 = testdriver.FindElement(By.Id("doors_height"));
            field1.Clear();
            field2.Clear();
            testdriver.FindElement(By.Id("doors_width")).SendKeys(height.ToString());
            testdriver.FindElement(By.Id("doors_height")).SendKeys(width.ToString());

            IWebElement automatikaBox = testdriver.FindElement(By.Id("automatika"));
            IWebElement montavimasBox = testdriver.FindElement(By.Id("darbai"));
            if (montavimasBox.Selected != montavimas)            
                montavimasBox.Click();            
            if (automatikaBox.Selected != automatika)            
                automatikaBox.Click();         

            testdriver.FindElement(By.Id("calc_submit")).Click();

            IWebElement rezultatas = testdriver.FindElement(By.Id("calc_result"));
            Assert.IsTrue(rezultatas.Text.Contains(expectedkaina), $"Rezultatas nesutampa, tikejomes {expectedkaina}, o gavome {rezultatas.Text}");
            //Assert.That(testdriver.FindElement(By.CssSelector(".col-md-12 > strong")).Text, Is.EqualTo(expectedkaina));


        }
        [OneTimeTearDown]
        public static void CloserBrowser()
        {
            testdriver.Quit();
        }



    }
}
