using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace csharp_example
{
    [TestFixture]
    public class GeoZonesSorting
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
            driver.Url = "http://localhost/litecart/admin/?app=geo_zones&doc=geo_zones";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            wait.Until(ExpectedConditions.UrlContains("http://localhost/litecart/admin/"));

            var countryList = driver.FindElements(By.CssSelector("td#content tr.row"));
            var openLinks = new List<string>();

            foreach (var country in countryList)
            {
                var countryLink = country.FindElement(By.CssSelector("tr.row :nth-child(3) a")).GetAttribute("href");
                openLinks.Add(countryLink);
            }

            foreach (var link in openLinks)
            {
                driver.Url = link;
                var zonesList = driver.FindElements(By.CssSelector("#table-zones tr:not(.header) td:nth-child(3)"));
                int previousZoneIndex = 0;
                foreach (var zone in zonesList)
                {
                    var zoneIndex = int.Parse(zone.FindElement(By.CssSelector("select")).GetAttribute("selectedIndex"));
                    Assert.IsFalse(previousZoneIndex > zoneIndex);
                    previousZoneIndex = zoneIndex;
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