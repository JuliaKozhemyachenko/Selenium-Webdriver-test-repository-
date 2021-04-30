using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_example
{
    public class BusketPage : BasePage
    {
        public BusketPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
        }

        public void RemoveFromBusket()
        {
            var rowsCount = GetProductsCountInBusket();
            Driver.FindElement(By.Name("remove_cart_item")).Click();
            Wait.Until(wd => GetProductsCountInBusket() != rowsCount);
        }

        public void RemoveAll()
        {
            WaitBusketLoad();

            while (GetProductsCountInBusket() > 0)
            {
                RemoveFromBusket();
            }
        }

        public int GetProductsCountInBusket()
        {
            return Driver.FindElements(By.CssSelector("#order_confirmation-wrapper tr")).Count;
        }

        public void WaitBusketLoad()
        {
            Wait.Until(ExpectedConditions.ElementExists(By.CssSelector("#order_confirmation-wrapper")));
        }
    }
}
