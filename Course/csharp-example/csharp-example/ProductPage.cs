using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_example
{
    public class ProductPage : BasePage
    {
        public ProductPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
        }

        public void AddProductToBusket()
        {
            Wait.Until(ExpectedConditions.ElementExists(By.Name("add_cart_product")));
            if (Driver.FindElements(By.CssSelector("div.buy_now select")).Count != 0)
            {
                Driver.FindElement(By.CssSelector("div.buy_now select")).Click();
                Driver.FindElement(By.CssSelector("div.buy_now select option[value=Small]")).Click();
            }
            Driver.FindElement(By.Name("add_cart_product")).Click();

            var now = DateTime.Now;
            Wait.Until(wd => (DateTime.Now - now).TotalSeconds > 1);
        }

        public void GoToMainPage()
        {
            Driver.FindElement(By.CssSelector("#site-menu li.general-0 a")).Click();
        }
    }
}
