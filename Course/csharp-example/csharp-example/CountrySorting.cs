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
    public class CountrySorting
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

            var countriesList = driver.FindElements(By.CssSelector("td#content tr.row"));
            var openLinks = new List<string>();
            string previousCountryName = null;
            foreach (var country in countriesList)
            {
                var countryLink = country.FindElement(By.CssSelector("td:nth-child(5) a"));
                var countryName = countryLink.GetAttribute("text");
                if (previousCountryName != null)
                {
                    Assert.IsFalse(StringComparer.CurrentCulture.Compare(previousCountryName, countryName) > 0);
                }
                previousCountryName = countryName;

                var countryZone = country.FindElement(By.CssSelector("td:nth-child(6)")).GetAttribute("textContent");
                if (countryZone != "0")
                {
                    openLinks.Add(countryLink.GetAttribute("href"));
                }
            }

            foreach (var link in openLinks)
            {
                driver.Url = link;
                var zonesList = driver.FindElements(By.CssSelector("#table-zones tr:not(.header)"));
                string previousZoneName = null;
                foreach (var zone in zonesList)
                {
                    var zoneName = zone.FindElement(By.CssSelector("td:nth-child(3)")).GetAttribute("textContent");
                    if (previousZoneName != null)
                    {
                        if (zoneName != "")
                        {
                            Assert.IsFalse(StringComparer.CurrentCulture.Compare(previousZoneName, zoneName) > 0);
                        }
                    }
                    previousZoneName = zoneName;
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