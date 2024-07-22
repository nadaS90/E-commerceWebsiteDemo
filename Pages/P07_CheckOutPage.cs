using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowBasics.Extensions;
using SpecFlowBasics.Helpers;
using SpecFlowBasics.TestData.DataClasses.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowBasics.Pages
{
    public class P07_CheckOutPage : BasePage
    {
        public P07_CheckOutPage(IWebDriver driver) : base(driver)
        {
        }

        //Locators :
        public const string CountryLocator = "//select[@id='BillingNewAddress_CountryId']";
        public const string CityLocator = "//input[@id='BillingNewAddress_City']";
        public const string Address1Locator = "//input[@id='BillingNewAddress_Address1']";
        public const string ZipPostalCodeLocator = "//input[@id='BillingNewAddress_ZipPostalCode']";
        public const string PhoneNumberLocator = "//input[@id='BillingNewAddress_PhoneNumber']";
        public const string ContinueButtonLocator = "(//div[@id='billing-buttons-container']//button)[2]";
        
        public const string ContinueToNextStepButtonLocator = "//button[@class='button-1 shipping-method-next-step-button']";
        public const string ContinuePaymentButtonLocator = "//button[@class='button-1 payment-method-next-step-button']";
        public const string ContinueToConfirmOrderButtonLocator = "//button[@class='button-1 payment-info-next-step-button']";
        public const string ConfirmOrderButtonLocator = "//button[normalize-space()='Confirm']";




        public void FillBillingAddress(List<UsersTestData> userssDataList)
        {
            foreach (var usersTestData in userssDataList)
            {
                // Select Country
                driver.ClickElement(By.XPath(CountryLocator), "Country");
                driver.ClickElement(By.XPath($"//option[text()='{usersTestData.Country}']"), "country List value");


                driver.SendText(By.XPath(CityLocator), usersTestData.City, "City textbox");
                driver.SendText(By.XPath(Address1Locator), usersTestData.Address, "Address 1 textbox");
                driver.SendText(By.XPath(ZipPostalCodeLocator), usersTestData.PostalCode, "Zip/Postal Code textbox");
                driver.SendText(By.XPath(PhoneNumberLocator), usersTestData.MobileNumber, "Phone Number textbox");
            }
        }



        public void ClickOnContinueButton()
        {
            driver.ClickElement(By.XPath(ContinueButtonLocator), "Continue Next Step Button");
        }
        
        public void ClickOnContinueToNextStepButton()
        {
            driver.ClickElement(By.XPath(ContinueToNextStepButtonLocator), "Continue Next Step Button");
        }
        
        public void ClickOnContinuePaymentButton()
        {
            driver.ClickElement(By.XPath(ContinuePaymentButtonLocator), "Continue Payment Button");
        }
        
        public void ClickOnContinueToConfirmOrderButton()
        {
            driver.ClickElement(By.XPath(ContinueToConfirmOrderButtonLocator), "Continue To Confirm Button");
        }

        public void ClickOnConfirmOrderButton()
        {
            driver.ClickElement(By.XPath(ConfirmOrderButtonLocator), "Confirm Button");
        }


    }
}
