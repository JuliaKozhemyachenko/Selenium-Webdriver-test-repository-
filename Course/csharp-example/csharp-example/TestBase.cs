using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;

namespace csharp_example
{
    public abstract class TestBase
    {
        internal IWebDriver driver;
        internal WebDriverWait wait;

        [SetUp]
        public void start()
        {
            driver = new FirefoxDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            InitDrivers(driver, wait);
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }

        public void OpenLiteCart()
        {
            driver.Url = "http://localhost/litecart/en/";
            wait.Until(ExpectedConditions.UrlContains("http://localhost/litecart/en/"));
        }

        internal virtual void InitDrivers(IWebDriver driver, WebDriverWait wait)
        {
        }
    }
}
