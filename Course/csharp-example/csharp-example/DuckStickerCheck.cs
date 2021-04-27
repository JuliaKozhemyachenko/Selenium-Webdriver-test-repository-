using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace csharp_example
{
    [TestFixture]
    public class DuckStickerCheck
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void start()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void FirstTest()
        {
            driver.Url = "http://localhost/litecart/en/";
            wait.Until(ExpectedConditions.UrlContains("http://localhost/litecart/en/"));
            var products = driver.FindElements(By.CssSelector("li.product")).Count;
            var lasttstickers = driver.FindElements(By.CssSelector("li.product div.sticker:last-child")).Count;
            Assert.IsTrue(products == lasttstickers);

        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}