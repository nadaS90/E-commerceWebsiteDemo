using System.Transactions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SpecFlowBasics.Common_Locators;
using SpecFlowBasics.Extensions;
using SpecFlowBasics.Helpers;
using SpecFlowBasics.HooksInitialization;
namespace SpecFlowBasics.Pages; 
public class P03_NotebooksPage : BasePage
{
    public P03_NotebooksPage(IWebDriver driver) : base(driver)
    {
    }

    //Locators :
    public const string AddToCartLocator = "//div[@data-productid='6']//button[@class='button-2 product-box-add-to-cart-button']";
    public const string TargetedSamsungDeviceLocator = "//h2[@class='product-title']//a[normalize-space()='Samsung Series 9 NP900X4C Premium Ultrabook']";
    public const string SortByDropdownLocator = "//select[@id='products-orderby']";
    public const string SortByNameAToZLocator = "//select[@id='products-orderby']/option[@value='5']";
    public const string FilterByCpuTypeIntelCoreI5Locator = "//input[@id='attribute-option-6']";





    public void ClickOnAddToCartButton()
    {            
        driver.ClickElement(By.XPath(AddToCartLocator), "Add To Cart Button");
    }

    public void SelectTargetedSamsungDeviceToPurchase()
    {
        driver.HoverElement(By.XPath(TargetedSamsungDeviceLocator), "Samsung Laptop");
    }


    public void SortByNameAToZ()
    {
        // Locate the element
        IWebElement AddTargetedDevice = driver.FindElement(By.XPath(TargetedSamsungDeviceLocator));
        driver.ScrollIntoView(AddTargetedDevice);

        // Click on the sort by dropdown
        driver.ClickElement(By.XPath(SortByDropdownLocator), "Sort By");
        driver.ClickElement(By.XPath(SortByNameAToZLocator), "Sort By List value");
    }

    public void FilterByCpuTypeIntelCoreI5()
    {
        // Click on the Intel Core i5 checkbox
        driver.ClickElement(By.XPath(FilterByCpuTypeIntelCoreI5Locator), "Filter By Core I5");
    }

}