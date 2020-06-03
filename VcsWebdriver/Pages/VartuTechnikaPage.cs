using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace VcsWebdriver.Pages
{
    class VartuTechnikaPage
    {
        private static IWebDriver _driver;

        private IWebElement _plocioLaukas => _driver.FindElement(By.Id("doors_width"));
        private IWebElement _aukscioLaukas => _driver.FindElement(By.Id("doors_height"));
        private IWebElement _automatika => _driver.FindElement(By.Id("automatika"));
        private IWebElement _montavimas => _driver.FindElement(By.Id("darbai"));
        private IWebElement _skaiciuotiKainaMygt => _driver.FindElement(By.Id("calc_submit"));
        private IWebElement _rezultatas => _driver.FindElement(By.Id("calc_result"));
        private IWebElement _uzdarytiAcceptCookies => _driver.FindElement(By.Id("cookiescript_reject"));

        public VartuTechnikaPage(IWebDriver inputDriver)
        {
            _driver = inputDriver;
            _driver.Url = "http://vartutechnika.lt/";
        }
        public VartuTechnikaPage IrasytiMatmenis(int plotis, int aukstis)
        {
            _plocioLaukas.Clear();
            _aukscioLaukas.Clear();
            _plocioLaukas.SendKeys(plotis.ToString());
            _aukscioLaukas.SendKeys(aukstis.ToString());
                return this;
        }

        public VartuTechnikaPage PazymetiAutomatika(bool uzsakytaAut)
        {
            if (_automatika.Selected != uzsakytaAut)
                _automatika.Click();

            return this;
        }
        public VartuTechnikaPage PazymetiMontavima(bool uzsakytaMon)
        {
            if (_montavimas.Selected != uzsakytaMon)
                _montavimas.Click();

            return this;
        }

        public VartuTechnikaPage SkaiciuotiKaina()
        {
            _skaiciuotiKainaMygt.Click();
            Thread.Sleep(1000);

            return this;
        }

        public VartuTechnikaPage UzdarytiCookies()
        {
            _uzdarytiAcceptCookies.Click();

            return this;
        }
        public VartuTechnikaPage TikrintiRezultata(string expectedResult)
        {
            Assert.IsTrue(_rezultatas.Text.Contains(expectedResult), $"Rezultatas nesutampa, tikejomes {expectedResult}, o gavome {_rezultatas.Text}");

            return this;
        }



    }
}
