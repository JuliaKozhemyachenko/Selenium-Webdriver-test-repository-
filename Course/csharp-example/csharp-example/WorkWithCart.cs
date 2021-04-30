using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace csharp_example
{
    [TestFixture]
    public class WorkWithCart : TestBase
    {
        private MainPage mainPage;
        private ProductPage productPage;
        private BusketPage busketPage;

        internal override void InitDrivers(IWebDriver driver, WebDriverWait wait)
        {
            base.InitDrivers(driver, wait);
            mainPage = new MainPage(driver, wait);
            productPage = new ProductPage(driver, wait);
            busketPage = new BusketPage(driver, wait);
        }

        [Test]
        public void FirstTest()
        {
            OpenLiteCart();

            for (int count = 0; count < 3; count++)
            {
                mainPage.ClickOnFirstProduct();
                productPage.AddProductToBusket();
                productPage.GoToMainPage();
            }

            mainPage.GoToBusket();

            busketPage.RemoveAll();
        }
    }
}