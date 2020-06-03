using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using VcsWebdriver.Pages;

namespace VcsWebdriver
{
    class VartuTechnikaPageObject
    {
        private static IWebDriver _driver;
        private static VartuTechnikaPage _vartuTechnikaPuslapis;

        [OneTimeSetUp]
        public static void OpenBrowser()
        {
            _driver = new FirefoxDriver();


            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            _vartuTechnikaPuslapis = new VartuTechnikaPage(_driver);
            _vartuTechnikaPuslapis.UzdarytiCookies();

        }




        [TestCase(2000, 2000, true, false, "665.98", TestName = "2000x2000 su aut")]
        [TestCase(4000, 2000, true, true, "1006.43", TestName = "4000x2000 su mont su aut")]
        [TestCase(4000, 2000, false, false, "692.35", TestName = "4000x2000")]
        [TestCase(5000, 2000, false, true, "989.21", TestName = "5000x2000 su mont")]
        public static void KainosSkaiciavimas(int height, int width, bool automatika, bool montavimas, string expectedkaina)
        {
            _vartuTechnikaPuslapis.IrasytiMatmenis(height, width);
            _vartuTechnikaPuslapis.PazymetiAutomatika(automatika);
            _vartuTechnikaPuslapis.PazymetiMontavima(montavimas);
            _vartuTechnikaPuslapis.SkaiciuotiKaina();
            _vartuTechnikaPuslapis.TikrintiRezultata(expectedkaina);
            //jeigu apsirasome metodus kad grazintu ta pacia klase (vietoj void klases vardas)
            //galima rasyti taip
            //_vartuTechnikaPuslapis
            //    .IrasytiMatmenis(height, width)
            //    .PazymetiAutomatika(automatika)
            //    .PazymetiMontavima(montavimas)
            //    .SkaiciuotiKaina()
            //    .TikrintiRezultata(expectedkaina);

        }
        [OneTimeTearDown]
        public static void CloserBrowser()
        {
            _driver.Quit();
        }



    }
}
