using OpenQA.Selenium;
using SpecFlowBasics.Common;
using SpecFlowBasics.Extensions;
using SpecFlowBasics.Helpers;
using SpecFlowBasics.TestData.DataClasses.Account;

namespace SpecFlowBasics.Pages;

public class P05_MyAccountPage : BasePage

{
    public P05_MyAccountPage(IWebDriver driver) : base(driver)
    {
    }

    //Locators :
    public const string GenderFemaleLocator = "gender-female";
    public const string SaveButtonLocator = "save-info-button";

    public void UserClicksOnSaveButton()
    {
        driver.ClickElement(By.Id(SaveButtonLocator), "Save Button");
    }

    public void UserClicksOnFemaleGenderButton()
    {
        driver.ClickElement(By.Id(GenderFemaleLocator), "Female Gender Button");
    }

}