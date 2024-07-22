using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SpecFlowBasics.Extensions;
using SpecFlowBasics.Helpers;

namespace SpecFlowBasics.Common_Locators;

public class CommonLocators : BasePage
{
    public CommonLocators(IWebDriver driver) : base(driver)
    {
    }

    //Locators :
    public const string RegisterLinkLocator = "Register";
    public const string LoginLinkLocator = "a.ico-login";
    public const string MyAccountLinkLocator = "//a[@class='ico-account']";
    public const string ShoppingCartLinkLocator = "//span[@class='cart-label']";
    public const string AddProductWishListLocator = "add-to-wishlist-button-4";
    public const string PopSucessMsgLocator = "p.content";
    public const string CloseMsgLocator = "span.close";
    public const string CompareProductsLocator = "div.compare-products";
    public const string AddToCartLocator = "add-to-cart-button-4";
    public const string WishLisBtnLocator = "add-to-wishlist-button-18";
    public const string WishListLinkLocator = "a[href=\"/wishlist\"]";
    public const string ChangeCurancyLocator = "customerCurrency";
    public const string ResultMsgLocator = "div.result";
    public const string CurrencyLocator = "div.prices";
    public const string LogOutLocator = "a.ico-logout";
    public const string HoverMenuLocator = "//ul[@class='top-menu notmobile']//a[normalize-space()='Computers']";
    public const string HoverDropDownLocator = "//ul[@class='top-menu notmobile']//a[normalize-space()='Notebooks']";
    

    public void ClickRegisterLink()
    {
        driver.ClickElement(By.LinkText(RegisterLinkLocator), "Register Link");
    }

    public void ClickLoginPage()
    {
        driver.ClickElement(By.CssSelector(LoginLinkLocator), "Login Link");
    }

    public void ClickMyAccountPage()
    {
        driver.ClickElement(By.XPath(MyAccountLinkLocator), "My Account Link");
    }

    public void ClickShoppingCartPage()
    {
        driver.ClickElement(By.XPath(ShoppingCartLinkLocator), "Shopping Cart Link");
    }

    public void UsedAddProductWishList()
    {
        driver.ClickElement(By.Id(AddProductWishListLocator), "Add Product Wish List");
    }

    public void ClosePopUpMsg()
    {
        driver.ClickElement(By.CssSelector(CloseMsgLocator), "Close Msg");
    }
    public void UserAddProductToCompare()
    {
        driver.ClickElement(By.CssSelector(CompareProductsLocator), "Compare Product");
    }

    public void UserAddProductToCart()
    {
        driver.ClickElement(By.CssSelector(AddToCartLocator), "Add To Cart");
    }

    public void UserNavigateToWishListPage()
    {
        driver.ClickElement(By.Id(WishListLinkLocator), "Wish List Link");
    }

    public void ClickWishListBtn()
    {
        driver.ClickElement(By.Id(WishLisBtnLocator), "Wish List Btn");
    }

    public void UserChooserEuro()
    {
        Select.SelectByText("Euro");
    }

    public void ClickAddCart()
    {
        driver.ClickElement(By.Id(AddProductWishListLocator), "Add Product Wish List");
    }

    public void UserLogOut()
    {
        driver.ClickElement(By.CssSelector(AddProductWishListLocator), "Add Product Wish List");
    }

    public void HoverMenuAndSelectCategory()
    {
        driver.HoverElement(By.XPath(HoverMenuLocator), "Hover");
        driver.ClickElement(By.XPath(HoverDropDownLocator), " drop down");
    }

    public bool CheckMessageDisplayed(By locator, string expectedMessage, int timeout = 20)
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));

        try
        {
            // Wait for element to be displayed
            IWebElement messageElement = wait.Until(ExpectedConditions.ElementIsVisible(locator));

            // Check if the element text contains the expected message
            if (messageElement.Text.Contains(expectedMessage))
            {
                Console.WriteLine($"The message element is displayed and contains the expected text: {expectedMessage}");
                return true;
            }
            else
            {
                Console.WriteLine($"Error: The message element is displayed but does not contain the expected text: {expectedMessage}");
                return false;
            }
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Error: The message element was not found after {timeout} seconds: {ex.Message}");
            return false;
        }
        catch (WebDriverException ex)
        {
            Console.WriteLine($"Error: An error occurred while checking the message element: {ex.Message}");
            return false;
        }
    }
}