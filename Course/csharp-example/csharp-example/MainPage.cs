using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_example
{
    public class MainPage : BasePage
    {
        public MainPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
        }

        public void ClickOnFirstProduct()
        {
            Wait.Until(ExpectedConditions.ElementExists(By.CssSelector("div.content a.link")));
            Driver.FindElement(By.CssSelector("div.content a.link")).Click();
        }

        public void GoToBusket()
        {
            Driver.FindElement(By.CssSelector("#cart a.link")).Click();
        }
    }
}
