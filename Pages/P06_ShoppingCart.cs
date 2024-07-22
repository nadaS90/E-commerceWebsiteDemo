using OpenQA.Selenium;
using SpecFlowBasics.Extensions;
using SpecFlowBasics.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowBasics.Pages
{
    public class P06_ShoppingCart : BasePage
    {
        public P06_ShoppingCart(IWebDriver driver) : base(driver)
        {
        }

        //Locators :
        public const string CheckBoxLocator = "//input[@id='termsofservice']";
        public const string CheckOutButtonLocator = "//button[@id='checkout']";



        public void ClickOnCheckBox()
        {
            driver.ClickElement(By.XPath(CheckBoxLocator), "CheckBox");
        }

        public void ClickOnCheckOutButton()
        {
            driver.ClickElement(By.XPath(CheckOutButtonLocator), "CheckOut Button");
        }
    }
}
