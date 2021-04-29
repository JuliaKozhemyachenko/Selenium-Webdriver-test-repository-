using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;

namespace csharp_example
{
    [TestFixture]
    public class AdminMenu
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void start()
        {
            driver = new FirefoxDriver();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void FirstTest()
        {
            driver.Url = "http://localhost/litecart/admin/login.php";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            wait.Until(ExpectedConditions.UrlContains("http://localhost/litecart/admin/"));

            for (var menuIndex = 0; menuIndex < driver.FindElements(By.CssSelector("#box-apps-menu #app-")).Count; menuIndex++)
            {
                driver.FindElements(By.CssSelector("#box-apps-menu #app- > a"))[menuIndex].Click();
                wait.Until(ExpectedConditions.ElementExists(By.CssSelector("td#content h1")));
                driver.FindElement(By.CssSelector("td#content h1"));
                if (driver.FindElements(By.CssSelector("ul.docs")).Count > 0)
                {
                    for (var subMenuIndex = 0; subMenuIndex < driver.FindElements(By.CssSelector("ul.docs > li")).Count; subMenuIndex++)
                    {
                        driver.FindElements(By.CssSelector("ul.docs li > a"))[subMenuIndex].Click();
                        wait.Until(ExpectedConditions.ElementExists(By.CssSelector("td#content h1")));
                        driver.FindElement(By.CssSelector("td#content h1"));
                    }
                }
            }
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}