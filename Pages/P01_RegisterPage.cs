using OpenQA.Selenium;
using SpecFlowBasics.Common;
using SpecFlowBasics.Extensions;
using SpecFlowBasics.Helpers;
using SpecFlowBasics.TestData.DataClasses.Account;

namespace SpecFlowBasics.Pages;

public class P01_RegisterPage : BasePage

{
    public P01_RegisterPage(IWebDriver driver) : base(driver)
    {
    }

    //Locators :
    public const string GenderFemaleLocator = "gender-female";
    public const string FirstNameTextLocator = "FirstName";
    public const string LastNameTextLocator = "LastName";
    public const string EmailAddressTextLocator = "Email";
    public const string PasswordTextLocator = "Password";
    public const string ConfirmPasswordTextLocator = "ConfirmPassword";
    public const string RegisterButtonLocator = "register-button";
  
    public static By SuccessMessageLocator { get; } = By.XPath("//div[@class='result']");
    public static By ErrorMessageLocator { get; } = By.XPath("//span[@class=\"field-validation-error\"]");




    // Fill form fields based on account type
    public void FillNewUserFormWithMandatoryFields(List<UsersTestData> userssDataList, string accountType)
    {
        var userTestData = userssDataList.First();

        string email;
        string password;
        string confirmPassword;

        switch (accountType)
        {
            case "valid":
                email = CommonMethods.GenerateRandomEmail();
                password = userTestData.Password;
                confirmPassword = userTestData.Password;
                JsonFileManager.UpdateJsonValue(FilePaths.UsersJson, "ValidEmailAddress", email);
                break;
            case "invalidEmail":
                email = CommonMethods.GenerateRandomInvalidEmail();
                password = userTestData.Password;
                confirmPassword = userTestData.Password;
                JsonFileManager.UpdateJsonValue(FilePaths.UsersJson, "InValidEmailAddress", email);
                break;
            case "password issue":
                email = CommonMethods.GenerateRandomEmail();
                password = userTestData.Password;
                confirmPassword = userTestData.InvalidPassword;
                break;
            default:
                email = CommonMethods.GenerateRandomEmail();
                password = userTestData.Password;
                confirmPassword = userTestData.Password;
                break;
        }

        driver.SendText(By.Id(FirstNameTextLocator), userTestData.FirstName, "First Name textbox");
        driver.SendText(By.Id(LastNameTextLocator), userTestData.LastName, "Last Name textbox");
        driver.SendText(By.Id(EmailAddressTextLocator), email, "Email textbox");
        driver.SendText(By.Id(PasswordTextLocator), password, "Password textbox");
        driver.SendText(By.Id(ConfirmPasswordTextLocator), confirmPassword, "Confirm Password textbox");
    }



    public void UserClicksOnRegisterButton()
    {
        driver.ClickElement(By.Id(RegisterButtonLocator), "REGISTER Button");
    }

}