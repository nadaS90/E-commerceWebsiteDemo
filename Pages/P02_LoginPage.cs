using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SpecFlowBasics.Extensions;
using SpecFlowBasics.Helpers;
using SpecFlowBasics.TestData.DataClasses.Account;

namespace SpecFlowBasics.Pages;

public class P02_LoginPage : BasePage
{
    public P02_LoginPage(IWebDriver driver) : base(driver)
    {
    }

    //Locators :
    public const String EmailAddressTextLocator = "Email";
    public const String PasswordTextLocator = "Password"; 
    public const String LoginButtonLocator = "//button[normalize-space()='Log in']";
    public const String ErrorMsgID = "//div[@class='message-error validation-summary-errors']";

 

    public void EnterValidEmailAndPassword(List<UsersTestData> userssDataList, string examType)
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

        string emailKey = GetEmailKeyByExamType(examType);
        string emailAddress = JsonFileManager.GetEmailAddressFromJson(FilePaths.UsersJson, emailKey);

        // Wait for the first element 
        wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(EmailAddressTextLocator)));

        // Locate the element
        IWebElement EmailTextBox = driver.FindElement(By.Id(EmailAddressTextLocator));
        driver.ScrollIntoView(EmailTextBox);

        foreach (var credential in userssDataList)
        {
            driver.SendText(By.Id(EmailAddressTextLocator), emailAddress, "Email");
            driver.SendText(By.Id(PasswordTextLocator), credential.Password, "Password");
        }
    }

    private string GetEmailKeyByExamType(string examType)
    {
        Dictionary<string, string> examTypeEmailKeys = new Dictionary<string, string>
            {
                 { "valid", "ValidEmailAddress" }
            };

        if (examTypeEmailKeys.ContainsKey(examType))
        {
            return examTypeEmailKeys[examType];
        }
        else
        {
            throw new ArgumentException($"Invalid examType: {examType}");
        }
    }

    public void UserLogIn()
    {
        driver.ClickElement(By.XPath(LoginButtonLocator), "Login Button");
    }

}