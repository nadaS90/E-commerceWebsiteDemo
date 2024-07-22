using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;

namespace SpecFlowBasics.Helpers;

public class BasePage


{
    public  IWebDriver driver;

    public SelectElement Select;
    //  public IJavaScriptExecutor jse;

    // Must create Constractor
    public BasePage(IWebDriver driver)
    {
        this.driver = driver;
    }
   

}