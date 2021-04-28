using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace csharp_example
{
    [TestFixture]
    public class DuckPriceCheckChrome
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

            var mainPageProduct = driver.FindElement(By.CssSelector("#box-campaigns a.link"));
            var mainPageDuckName = mainPageProduct.FindElement(By.CssSelector("div.name")).GetAttribute("innerText");
            var mainPageRegularPrice = mainPageProduct.FindElement(By.CssSelector("s.regular-price")).GetAttribute("innerText");
            var mainPageCampaignPrice = mainPageProduct.FindElement(By.CssSelector("strong.campaign-price")).GetAttribute("innerText");

            Assert.IsTrue(Double.Parse(mainPageProduct.FindElement(By.CssSelector("s.regular-price")).GetCssValue("font-size").TrimEnd('x').TrimEnd('p')) <
                            Double.Parse(mainPageProduct.FindElement(By.CssSelector("strong.campaign-price")).GetCssValue("font-size").TrimEnd('x').TrimEnd('p')));

            Assert.IsTrue(mainPageProduct.FindElement(By.CssSelector("s.regular-price")).GetCssValue("text-decoration-line") == "line-through");
            Assert.IsTrue(Int32.Parse(mainPageProduct.FindElement(By.CssSelector("strong.campaign-price")).GetCssValue("font-weight")) >= 600);

            var mainPageRegularPriceColor = mainPageProduct.FindElement(By.CssSelector("s.regular-price")).GetCssValue("text-decoration-color");
            var mainPageRegularPriceColorRGB = mainPageRegularPriceColor.Substring(4, mainPageRegularPriceColor.Length - 5).Split(',');
            Assert.IsTrue(Int32.Parse(mainPageRegularPriceColorRGB[0]) == Int32.Parse(mainPageRegularPriceColorRGB[1]) &&
                          Int32.Parse(mainPageRegularPriceColorRGB[0]) == Int32.Parse(mainPageRegularPriceColorRGB[2]));

            var mainPageCampaignPriceColor = mainPageProduct.FindElement(By.CssSelector("strong.campaign-price")).GetCssValue("text-decoration-color");
            var mainPageCampaignPriceColorRGB = mainPageCampaignPriceColor.Substring(4, mainPageCampaignPriceColor.Length - 5).Split(',');
            Assert.IsTrue(Int32.Parse(mainPageCampaignPriceColorRGB[1]) == Int32.Parse(mainPageCampaignPriceColorRGB[2]));

            mainPageProduct.Click();

            Assert.IsTrue(mainPageDuckName == driver.FindElement(By.CssSelector("#box-product h1.title")).GetAttribute("innerText"));
            Assert.IsTrue(mainPageRegularPrice == driver.FindElement(By.CssSelector("#box-product s.regular-price")).GetAttribute("innerText"));
            Assert.IsTrue(mainPageCampaignPrice == driver.FindElement(By.CssSelector("#box-product strong.campaign-price")).GetAttribute("innerText"));


            Assert.IsTrue(Double.Parse(driver.FindElement(By.CssSelector("#box-product s.regular-price")).GetCssValue("font-size").TrimEnd('x').TrimEnd('p')) <
                Double.Parse(driver.FindElement(By.CssSelector("#box-product strong.campaign-price")).GetCssValue("font-size").TrimEnd('x').TrimEnd('p')));

            Assert.IsTrue(driver.FindElement(By.CssSelector("#box-product s.regular-price")).GetCssValue("text-decoration-line") == "line-through");
            Assert.IsTrue(Int32.Parse(driver.FindElement(By.CssSelector("#box-product strong.campaign-price")).GetCssValue("font-weight")) >= 600);
            var productPageRegularPriceColor = driver.FindElement(By.CssSelector("#box-product s.regular-price")).GetCssValue("text-decoration-color");
            var productPageRegularPriceColorRGB = productPageRegularPriceColor.Substring(4, productPageRegularPriceColor.Length - 5).Split(',');
            Assert.IsTrue(Int32.Parse(productPageRegularPriceColorRGB[0]) == Int32.Parse(productPageRegularPriceColorRGB[1]) &&
                          Int32.Parse(productPageRegularPriceColorRGB[0]) == Int32.Parse(productPageRegularPriceColorRGB[2]));

            var productPageCampaignPriceColor = driver.FindElement(By.CssSelector("#box-product strong.campaign-price")).GetCssValue("text-decoration-color");
            var productPageCampaignPriceColorRGB = productPageCampaignPriceColor.Substring(4, productPageCampaignPriceColor.Length - 5).Split(',');
            Assert.IsTrue(Int32.Parse(productPageCampaignPriceColorRGB[1]) == Int32.Parse(productPageCampaignPriceColorRGB[2]));
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}