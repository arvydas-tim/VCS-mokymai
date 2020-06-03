using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace VcsWebdriver.Drivers
{
    public static class CustomDrivers
    {
        public static IWebDriver GetFirefoxDriver()
        {
            var Driver = new FirefoxDriver();
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            return Driver;
        }
        public static IWebDriver GetChromeDriver()
        {
            var Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            return Driver;
        }



    }
}
