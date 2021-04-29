using System;
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
    public class NewProductCreation
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
            driver.Url = "http://localhost/litecart/admin/login.php";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            wait.Until(ExpectedConditions.UrlContains("http://localhost/litecart/admin/"));


            driver.FindElement(By.XPath("//ul[@id='box-apps-menu']//span[.='Catalog']")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("#content a.button[href$=product]")));
            driver.FindElement(By.CssSelector("#content a.button[href$=product]")).Click();

            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("td#content h1")));

//            driver.FindElement(By.Name("name[en]")).SendKeys("test duck");

            var generatedDuckName = $"testduck{Guid.NewGuid()}";
            driver.FindElement(By.Name("name[en]")).SendKeys(generatedDuckName);

            wait.Until(ExpectedConditions.ElementExists(By.Name("product_groups[]")));
            driver.FindElement(By.Name("product_groups[]")).Click();

            wait.Until(ExpectedConditions.ElementExists(By.Name("quantity")));
            driver.FindElement(By.Name("quantity")).Clear();
            driver.FindElement(By.Name("quantity")).SendKeys(Keys.Home + "2.22");

            var file = System.IO.Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "real_duck.jpg").First();
            driver.FindElement(By.CssSelector("#tab-general input[type=file]")).SendKeys(file);

            (driver as IJavaScriptExecutor).ExecuteScript("$('[name=date_valid_from]')[0].value = '2021-01-02'");
            (driver as IJavaScriptExecutor).ExecuteScript("$('[name=date_valid_to]')[0].value = '2021-03-04'");

            driver.FindElement(By.CssSelector("div.tabs [href$=information]")).Click();

            wait.Until(ExpectedConditions.ElementExists(By.Name("manufacturer_id")));
            driver.FindElement(By.Name("manufacturer_id")).Click();
            driver.FindElement(By.CssSelector("#tab-information [name=manufacturer_id] [value='1']")).Click();

            driver.FindElement(By.CssSelector("div.tabs [href$=prices]")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.Name("purchase_price")));
            driver.FindElement(By.Name("purchase_price")).Clear();
            driver.FindElement(By.Name("purchase_price")).SendKeys(Keys.Home + "220");

            driver.FindElement(By.Name("purchase_price_currency_code")).Click();
            driver.FindElement(By.CssSelector("#tab-prices [name=purchase_price_currency_code] [value='USD']")).Click();

            driver.FindElement(By.CssSelector("span.button-set [name=save]")).Click();

            wait.Until(ExpectedConditions.ElementExists(By.Name("catalog_form")));

            wait.Until(ExpectedConditions.ElementExists(By.XPath($"//table[@class='dataTable']//a[.='{generatedDuckName}']")));
//            driver.FindElement(By.XPath($"//table[@class='dataTable']//a[.='{generatedDuckName}']"));
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}