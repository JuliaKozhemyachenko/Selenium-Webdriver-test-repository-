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

            driver.FindElement(By.XPath("//ul[@id='box-apps-menu']//span[.='Appearence']")).Click();
            driver.FindElement(By.CssSelector("td#content h1"));
            driver.FindElement(By.CssSelector("ul.docs li#doc-logotype"));
            driver.FindElement(By.CssSelector("td#content h1"));

            driver.FindElement(By.XPath("//ul[@id='box-apps-menu']//span[.='Catalog']")).Click();
            driver.FindElement(By.CssSelector("td#content h1"));

            driver.FindElement(By.XPath("//ul[@id='box-apps-menu']//span[.='Product Groups']")).Click();
            driver.FindElement(By.CssSelector("td#content h1"));

            driver.FindElement(By.XPath("//ul[@id='box-apps-menu']//span[.='Option Groups']")).Click();
            driver.FindElement(By.CssSelector("td#content h1"));

            driver.FindElement(By.XPath("//ul[@id='box-apps-menu']//span[.='Manufacturers']")).Click();
            driver.FindElement(By.CssSelector("td#content h1"));

            driver.FindElement(By.XPath("//ul[@id='box-apps-menu']//span[.='Suppliers']")).Click();
            driver.FindElement(By.CssSelector("td#content h1"));

            driver.FindElement(By.XPath("//ul[@id='box-apps-menu']//span[.='Delivery Statuses']")).Click();
            driver.FindElement(By.CssSelector("td#content h1"));

            driver.FindElement(By.XPath("//ul[@id='box-apps-menu']//span[.='Sold Out Statuses']")).Click();
            driver.FindElement(By.CssSelector("td#content h1"));

            driver.FindElement(By.XPath("//ul[@id='box-apps-menu']//span[.='Quantity Units']")).Click();
            driver.FindElement(By.CssSelector("td#content h1"));

            driver.FindElement(By.XPath("//ul[@id='box-apps-menu']//span[.='CSV Import/Export']")).Click();
            driver.FindElement(By.CssSelector("td#content h1"));

            driver.FindElement(By.XPath("//ul[@id='box-apps-menu']//span[.='Countries']")).Click();
            driver.FindElement(By.CssSelector("td#content h1"));

            driver.FindElement(By.XPath("//ul[@id='box-apps-menu']//span[.='Currencies']")).Click();
            driver.FindElement(By.CssSelector("td#content h1"));

            driver.FindElement(By.XPath("//ul[@id='box-apps-menu']//span[.='Customers']")).Click();
            driver.FindElement(By.CssSelector("td#content h1"));

            driver.FindElement(By.CssSelector("ul.docs li#doc-csv"));
            driver.FindElement(By.CssSelector("td#content h1"));

            driver.FindElement(By.CssSelector("ul.docs li#doc-newsletter"));
            driver.FindElement(By.CssSelector("td#content h1"));

            driver.FindElement(By.XPath("//ul[@id='box-apps-menu']//span[.='Geo Zones']")).Click();
            driver.FindElement(By.CssSelector("td#content h1"));

            driver.FindElement(By.XPath("//ul[@id='box-apps-menu']//span[.='Languages']")).Click();
            driver.FindElement(By.CssSelector("td#content h1"));

            driver.FindElement(By.CssSelector("ul.docs li#doc-storage_encoding"));
            driver.FindElement(By.CssSelector("td#content h1"));

            driver.FindElement(By.XPath("//ul[@id='box-apps-menu']//span[.='Modules']")).Click();
            driver.FindElement(By.CssSelector("td#content h1"));

            driver.FindElement(By.CssSelector("ul.docs li#doc-customer"));
            driver.FindElement(By.CssSelector("td#content h1"));

            driver.FindElement(By.CssSelector("ul.docs li#doc-shipping"));
            driver.FindElement(By.CssSelector("td#content h1"));

            driver.FindElement(By.CssSelector("ul.docs li#doc-payment"));
            driver.FindElement(By.CssSelector("td#content h1"));

            driver.FindElement(By.CssSelector("ul.docs li#doc-order_total"));
            driver.FindElement(By.CssSelector("td#content h1"));

            driver.FindElement(By.CssSelector("ul.docs li#doc-order_success"));
            driver.FindElement(By.CssSelector("td#content h1"));

            driver.FindElement(By.CssSelector("ul.docs li#doc-order_action"));
            driver.FindElement(By.CssSelector("td#content h1"));

            driver.FindElement(By.XPath("//ul[@id='box-apps-menu']//span[.='Orders']")).Click();
            driver.FindElement(By.CssSelector("td#content h1"));

            driver.FindElement(By.CssSelector("ul.docs li#doc-order_statuses"));
            driver.FindElement(By.CssSelector("td#content h1"));

            driver.FindElement(By.XPath("//ul[@id='box-apps-menu']//span[.='Pages']")).Click();
            driver.FindElement(By.CssSelector("td#content h1"));

            driver.FindElement(By.XPath("//ul[@id='box-apps-menu']//span[.='Reports']")).Click();
            driver.FindElement(By.CssSelector("td#content h1"));

            driver.FindElement(By.CssSelector("ul.docs li#doc-most_sold_products"));
            driver.FindElement(By.CssSelector("td#content h1"));

            driver.FindElement(By.CssSelector("ul.docs li#doc-most_shopping_customers"));
            driver.FindElement(By.CssSelector("td#content h1"));

            driver.FindElement(By.XPath("//ul[@id='box-apps-menu']//span[.='Settings']")).Click();
            driver.FindElement(By.CssSelector("td#content h1"));

            driver.FindElement(By.CssSelector("ul.docs li#doc-defaults"));
            driver.FindElement(By.CssSelector("td#content h1"));

            driver.FindElement(By.CssSelector("ul.docs li#doc-general"));
            driver.FindElement(By.CssSelector("td#content h1"));

            driver.FindElement(By.CssSelector("ul.docs li#doc-listings"));
            driver.FindElement(By.CssSelector("td#content h1"));

            driver.FindElement(By.CssSelector("ul.docs li#doc-images"));
            driver.FindElement(By.CssSelector("td#content h1"));

            driver.FindElement(By.CssSelector("ul.docs li#doc-checkout"));
            driver.FindElement(By.CssSelector("td#content h1"));

            driver.FindElement(By.CssSelector("ul.docs li#doc-advanced"));
            driver.FindElement(By.CssSelector("td#content h1"));

            driver.FindElement(By.CssSelector("ul.docs li#doc-security"));
            driver.FindElement(By.CssSelector("td#content h1"));

            driver.FindElement(By.XPath("//ul[@id='box-apps-menu']//span[.='Slides']")).Click();
            driver.FindElement(By.CssSelector("td#content h1"));

            driver.FindElement(By.XPath("//ul[@id='box-apps-menu']//span[.='Tax']")).Click();
            driver.FindElement(By.CssSelector("td#content h1"));

            driver.FindElement(By.CssSelector("ul.docs li#doc-tax_rates"));
            driver.FindElement(By.CssSelector("td#content h1"));

            driver.FindElement(By.XPath("//ul[@id='box-apps-menu']//span[.='Translations']")).Click();
            driver.FindElement(By.CssSelector("td#content h1"));

            driver.FindElement(By.CssSelector("ul.docs li#doc-scan"));
            driver.FindElement(By.CssSelector("td#content h1"));

            driver.FindElement(By.XPath("//ul[@id='box-apps-menu']//span[.='Tax']")).Click();
            driver.FindElement(By.CssSelector("td#content h1"));

            driver.FindElement(By.CssSelector("ul.docs li#doc-tax_rates"));
            driver.FindElement(By.CssSelector("td#content h1"));

            driver.FindElement(By.XPath("//ul[@id='box-apps-menu']//span[.='Users']")).Click();
            driver.FindElement(By.CssSelector("td#content h1"));

            driver.FindElement(By.XPath("//ul[@id='box-apps-menu']//span[.='vQmods']")).Click();
            driver.FindElement(By.CssSelector("td#content h1"));

        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}