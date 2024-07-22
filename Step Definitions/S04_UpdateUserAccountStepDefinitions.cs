using OpenQA.Selenium;
using SpecFlowBasics.Common_Locators;
using SpecFlowBasics.Helpers;
using SpecFlowBasics.HooksInitialization;
using SpecFlowBasics.Pages;
using SpecFlowBasics.TestData.DataClasses.Account;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowBasics
{
    [Binding]

   
    public class S04_UpdateUserAccountStepDefinitions
    {

        P05_MyAccountPage _myAccountObject;
        CommonLocators _commonObject;
        private List<UsersTestData> _userssDataList;
        private readonly JsonFileManager _converter;
        private string UsersJson = FilePaths.UsersJson;


        public S04_UpdateUserAccountStepDefinitions(IWebDriver driver)
        {
            this._converter = new JsonFileManager();
            this._myAccountObject = new P05_MyAccountPage(Hooks.driver);
            this._commonObject = new CommonLocators(Hooks.driver);
            this._userssDataList = ConvertJsonToUserssDataList();
        }

        private List<UsersTestData> ConvertJsonToUserssDataList()
        {
            return _converter.ConvertJsonToObject<List<UsersTestData>>(UsersJson);
        }


        [When(@"user navigates to my account page")]
        public void WhenUserNavigatesToMyAccountPage()
        {
            _commonObject.ClickMyAccountPage();
        }

        [When(@"user update gender option")]
        public void WhenUserUpdateGenderOption()
        {
            _myAccountObject.UserClicksOnFemaleGenderButton();
        }

        [When(@"user clicks on save button")]
        public void WhenUserClicksOnSaveButton()
        {
            _myAccountObject.UserClicksOnSaveButton();
        }

        [Then(@"success pop up displayed")]
        public void ThenSuccessPopUpDisplayed()
        {
          _commonObject.ClosePopUpMsg();
        }
    }
}
