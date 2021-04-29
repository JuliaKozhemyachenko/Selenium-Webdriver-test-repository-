using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Firefox;

namespace csharp_example
{
    [TestFixture]
    public class UserRegistration
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
            driver.Url = "http://localhost/litecart/en/";
            wait.Until(ExpectedConditions.UrlContains("http://localhost/litecart/en/"));

            driver.FindElement(By.CssSelector("form[name = login_form] a")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("#create-account h1")));

            wait.Until(ExpectedConditions.ElementExists(By.Name("firstname")));
            driver.FindElement(By.Name("firstname")).SendKeys("testname");
            wait.Until(ExpectedConditions.ElementExists(By.Name("lastname")));
            driver.FindElement(By.Name("lastname")).SendKeys("testlastname");
            wait.Until(ExpectedConditions.ElementExists(By.Name("address1")));
            driver.FindElement(By.Name("address1")).SendKeys("testaddress1");
            wait.Until(ExpectedConditions.ElementExists(By.Name("postcode")));
            driver.FindElement(By.Name("postcode")).SendKeys("12345");
            wait.Until(ExpectedConditions.ElementExists(By.Name("city")));
            driver.FindElement(By.Name("city")).SendKeys("testcity");

            var selectCountry = driver.FindElement(By.CssSelector("select[name=country_code]"));
            new Actions(driver)
                .MoveToElement(selectCountry)
                .MoveByOffset(5, 5)
                .Click()
                .Perform();
            driver.FindElement(By.CssSelector(".select2-search__field")).SendKeys("United States");
            driver.FindElement(By.CssSelector(".select2-search__field")).SendKeys(Keys.Enter);

            var generatedEmail = $"testemail{Guid.NewGuid()}@test.ru";

            driver.FindElement(By.Name("email")).SendKeys(generatedEmail);


            driver.FindElement(By.Name("phone")).SendKeys("+18888888");
            driver.FindElement(By.Name("password")).SendKeys("testpass");
            driver.FindElement(By.Name("confirmed_password")).SendKeys("testpass");
            driver.FindElement(By.Name("create_account")).Click();

            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("div.content #box-account")));
            driver.FindElement(By.CssSelector("#box-account ul.list-vertical li:last-child a")).Click();

            wait.Until(ExpectedConditions.ElementExists(By.Name("login")));
            driver.FindElement(By.Name("email")).SendKeys(generatedEmail);
            driver.FindElement(By.Name("password")).SendKeys("testpass");
            driver.FindElement(By.Name("login")).Click();

            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("div.content #box-account")));
            driver.FindElement(By.CssSelector("#box-account ul.list-vertical li:last-child a")).Click();
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}