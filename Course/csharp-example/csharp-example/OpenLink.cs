using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace csharp_example
{
    [TestFixture]
    public class OpenLink
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void start()
        {
            driver = new FirefoxDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void FirstTest()
        {
            driver.Url = "http://localhost/litecart/admin/?app=countries&doc=countries";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            wait.Until(ExpectedConditions.UrlContains("http://localhost/litecart/admin/"));


            driver.FindElement(By.CssSelector("#content a.button")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("td#content h1")));


            var outerLinksList = driver.FindElements(By.CssSelector("#content td a[href^=http]"));
            
            foreach (var windowlink in outerLinksList)
            {
                string startWindow = driver.CurrentWindowHandle;
                IReadOnlyCollection<string> oldWindows = driver.WindowHandles;

                windowlink.Click();

                string newWindow = wait.Until(ThereIsWindowOtherThan(oldWindows));

                driver.SwitchTo().Window(newWindow);
                driver.Close();
                driver.SwitchTo().Window(startWindow);
            }
        }

        public Func<IWebDriver, String> ThereIsWindowOtherThan(IReadOnlyCollection<String> oldWindows)
        {
            return (wd) =>
            {
                var currentWindows = wd.WindowHandles;
                return currentWindows.Except(oldWindows).FirstOrDefault();
            };
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}