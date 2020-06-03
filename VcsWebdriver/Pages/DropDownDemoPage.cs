using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace VcsWebdriver.Pages
{
    class DropDownDemoPage : PageBase
    {

        private SelectElement _dropDownSelect => new SelectElement(Driver.FindElement(By.Id("select-demo")));
        private IWebElement _dropDownSelectMessage => Driver.FindElement(By.ClassName("selected-value"));

        private IWebElement _multipleSelect => Driver.FindElement(By.Id("select - demo"));

        private IWebElement _multipleSelectPrintFirst => Driver.FindElement(By.Id("printMe"));
        private IWebElement _multipleSelectPrintAll => Driver.FindElement(By.Id("printAll")); 
        private SelectElement _multipleSelectMessage => new SelectElement(Driver.FindElement(By.ClassName("getall-selected")));

        // kai paveldimos klases, konstruktorius privalo tureti inputus kaip ir tevines klases konstruktorius
        public DropDownDemoPage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = "https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html";
        }

        public DropDownDemoPage DropDownSelect(DayOfWeek selectOption)
        {            
            _dropDownSelect.SelectByValue(selectOption.ToString());
            return this;
        }
        public DropDownDemoPage AssertDropDownMessage()
        {
            GetWait().Until(ExpectedConditions.TextToBePresentInElement(_dropDownSelectMessage, _dropDownSelectMessage.Text));

            Assert.AreEqual($"Day selected :- {_dropDownSelect.SelectedOption.Text}", _dropDownSelectMessage.Text);

            return this;
        }


    }
}
