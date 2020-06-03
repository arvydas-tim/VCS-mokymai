using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

namespace VcsWebdriver.Pages
{
    class BasicFirstFromDemoPage
    {
        private static IWebDriver _driver;
        // properties apsiraso taip => reiskia kad paima reiksme tik tada kai reikia
        //vietoj to kad bandytu iskart prisiskirti kintamuosius (nors galbut dar nera sukurti jie ir mestu error)
        private IWebElement _messageInput => _driver.FindElement(By.Id("user-message"));
        private IWebElement _showMessageButton => _driver.FindElement(By.XPath("//*[@id='get-input']/button"));
        private IWebElement _yourMessageLabel => _driver.FindElement(By.Id("display"));

        private IWebElement _laukasA => _driver.FindElement(By.Id("sum1"));
        private IWebElement _laukasB => _driver.FindElement(By.Id("sum2"));
        private IWebElement _sumosMygtukas => _driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/div[2]/form/button"));
        private IWebElement _rezultatas => _driver.FindElement(By.Id("displayvalue"));


        public BasicFirstFromDemoPage(IWebDriver inputDriver)
        {
            _driver = inputDriver;
        }

        public void EnterMessage(string myMessage)
        {
            _messageInput.Clear();
            _messageInput.SendKeys(myMessage);
        }

        public void PushShowMessageButton()
        {
            _showMessageButton.Click();
        }

        public void AssertShownMessage(string expectedMessage)
        {
            string actualMessage = _yourMessageLabel.Text;
            Assert.AreEqual(expectedMessage, actualMessage, "Pranesimas nesutampa"); 
        }

        public void EnterNumbers(int a, int b)
        {
            _laukasA.Clear();
            _laukasA.SendKeys(a.ToString());

            _laukasB.Clear();
            _laukasB.SendKeys(b.ToString());
        }

        public void ClickSumosMygtuka()
        {
            _sumosMygtukas.Click();
        }
        public void PatikrintiRezultata(string expectedResult)
        {  
            Assert.AreEqual(expectedResult, _rezultatas.Text, "Suma nesutampa");
        }


    }
}
