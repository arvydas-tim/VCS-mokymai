using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace VcsWebdriver.Pages
{
    class CheckboxDemoPage
    {
        private static IWebDriver _driver;
        // properties apsiraso taip => reiskia kad paima reiksme tik tada kai reikia
        //vietoj to kad bandytu iskart prisiskirti kintamuosius (nors galbut dar nera sukurti jie ir mestu error)
        private IWebElement _singleCheckbox => _driver.FindElement(By.Id("isAgeSelected"));
        private IWebElement _singleBoxMessage => _driver.FindElement(By.Id("txtAge")); 

        private IWebElement _boxA => _driver.FindElement(By.CssSelector(".checkbox:nth-child(3) .cb1-element"));
        private IWebElement _boxB => _driver.FindElement(By.CssSelector(".checkbox:nth-child(4) .cb1-element"));
        private IWebElement _boxC => _driver.FindElement(By.CssSelector(".checkbox:nth-child(5) .cb1-element"));
        private IWebElement _boxD => _driver.FindElement(By.CssSelector(".checkbox:nth-child(6) .cb1-element"));

        private ReadOnlyCollection<IWebElement> _multipleCheckboxes => _driver.FindElements(By.ClassName("cb1-element"));
        private IWebElement _checkAllButton => _driver.FindElement(By.Id("check1"));


        public CheckboxDemoPage(IWebDriver inputDriver)
        {
            _driver = inputDriver;
        }

        public CheckboxDemoPage UncheckAllBoxes()
        {
            foreach (var checkbox in _multipleCheckboxes)
            {
                if (checkbox.Selected == true)
                {
                    checkbox.Click();
                }
            }
            //^^ sitas ciklas su readonlycollection sutaupo daug kodo, nes abcd boxai turi ta pacia klase
            //if (_boxA.Selected == true)
            //{
            //    _boxA.Click();
            //}
            //if (_boxB.Selected == true)
            //{
            //    _boxB.Click();
            //}
            //if (_boxC.Selected == true)
            //{
            //    _boxC.Click();
            //}
            //if (_boxD.Selected == true)
            //{
            //    _boxD.Click();
            //}
            if (_singleCheckbox.Selected == true)
            {
                _singleCheckbox.Click();
            }
            return this;
        }

        public CheckboxDemoPage CheckSingleBox()
        {
            _singleCheckbox.Click();
            return this;
        }

        public CheckboxDemoPage AssertSingleBoxStatusMessage()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.TextToBePresentInElement(_singleBoxMessage, "Success - Check box is checked"));
            //^^sitas elementas lauks kol parodys norima teksta
            Assert.That(_singleBoxMessage.Text, Is.EqualTo("Success - Check box is checked"), "Negautas pazymeto checkbox pranesimas");
            return this;
        }

        public CheckboxDemoPage ClickCheckBoxA()
        {
            _boxA.Click();
            return this;
        }
        public CheckboxDemoPage ClickCheckBoxB()
        {
            _boxB.Click();
            return this;
        }

        public CheckboxDemoPage ClickCheckBoxC()
        {
            _boxC.Click();
            return this;
        }

        public CheckboxDemoPage ClickCheckBoxD()
        {
            _boxD.Click();
            return this;
        }
        public CheckboxDemoPage ClickCheckAllButton()
        {
            _checkAllButton.Click();
            return this;
        }


        public CheckboxDemoPage AssertUncheckAllButtonStatus()
        {
            Assert.That(_checkAllButton.GetAttribute("value"), Is.EqualTo("Uncheck All"), "Mygtukas nerodo uncheck all");
            return this;
        }
        public CheckboxDemoPage AssertCheckAllButtonStatus()
        {
            Assert.That(_checkAllButton.GetAttribute("value"), Is.EqualTo("Uncheck All"), "Mygtukas nerodo check all");
            return this;
        }

        public CheckboxDemoPage AssertAllCheckboxStatusUnchecked()
        {
            Assert.False(_boxA.Selected, "Ne visi langeliai atzymeti");
            Assert.False(_boxB.Selected, "Ne visi langeliai atzymeti");
            Assert.False(_boxC.Selected, "Ne visi langeliai atzymeti");
            Assert.False(_boxD.Selected, "Ne visi langeliai atzymeti");
            return this;
        }


    }
}
