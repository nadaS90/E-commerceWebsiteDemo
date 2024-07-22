using OpenQA.Selenium;
using SpecFlowBasics.HooksInitialization;
using SpecFlowBasics.Pages;
using System;
using SpecFlowBasics.Common_Locators;
using SpecFlowBasics.TestData.DataClasses.Account;
using TechTalk.SpecFlow;
using Constants = SpecFlowBasics.data.Constants;
using static SpecFlowBasics.HooksInitialization.Hooks;
using SpecFlowBasics.Helpers;
using TechTalk.SpecFlow.CommonModels;

namespace SpecFlowBasics.StepDefinitions
{
    [Binding]

    public class S01_RegisterStepDef
    {
        P01_RegisterPage _registerObject;
        CommonLocators _commonObject;
        private List<UsersTestData> _userssDataList;
        private readonly JsonFileManager _converter;
        private string UsersJson = FilePaths.UsersJson;

        public S01_RegisterStepDef(IWebDriver driver)
        {
            this._converter = new JsonFileManager();
            this._registerObject = new P01_RegisterPage(Hooks.driver);
            this._commonObject = new CommonLocators(Hooks.driver);
            this._userssDataList = ConvertJsonToUserssDataList();
        }

        private List<UsersTestData> ConvertJsonToUserssDataList()
        {
            return _converter.ConvertJsonToObject<List<UsersTestData>>(UsersJson);
        }

        [Given(@"user navigates to register page")]
        public void GivenUserNavigatesToRegisterPage()
        {
            _commonObject.ClickRegisterLink();
        }

        [Given(@"the data loaded from candidate saved file")]
        public void WhenTheDataLoadedFromCandidateSavedFile()
        {
            _userssDataList = ConvertJsonToUserssDataList();
        }

        [Given(@"the user fills the form fields with data of (.*)")]
        public void WhenTheUserFillsTheFormFieldsWithData(string accountType)
        {
            _registerObject.FillNewUserFormWithMandatoryFields(_userssDataList,accountType);
        }

        [When(@"the user clicks the Register button")]
        public void WhenTheUserClicksTheRegisterButton()
        {
            _registerObject.UserClicksOnRegisterButton();
        }

        [Then(@"a message (.*) displayed")]
        public void ThenAMessageDisplayed(string message)
        {
            _commonObject.CheckMessageDisplayed(P01_RegisterPage.SuccessMessageLocator, message);
        }
    }
}
