using OpenQA.Selenium;
using SpecFlowBasics.Extensions;
using SpecFlowBasics.Helpers;


public class P04_AddProductToCartPage : BasePage
{
    public P04_AddProductToCartPage(IWebDriver driver) : base(driver)
    {
    }


    //Locators :
    
    public const string CheckBoxLocator = "//input[@id='termsofservice']";
    public const string CheckOutButtonLocator = "//button[@id='checkout']";

    public void CliickOnCheckBox()
    {
        driver.ClickElement(By.XPath(CheckBoxLocator), "Check box Button");
    }

    public void CliickOnCheckOutButton()
    {
        driver.ClickElement(By.XPath(CheckOutButtonLocator), "Check out Button");
    }

}
