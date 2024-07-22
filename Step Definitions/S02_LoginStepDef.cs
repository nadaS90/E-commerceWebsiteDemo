using OpenQA.Selenium;
using SpecFlowBasics.Common_Locators;
using SpecFlowBasics.Helpers;
using SpecFlowBasics.HooksInitialization;
using SpecFlowBasics.Pages;
using SpecFlowBasics.TestData.DataClasses.Account;
using System;
using TechTalk.SpecFlow;
using static SpecFlowBasics.HooksInitialization.Hooks;
using Constants = SpecFlowBasics.data.Constants;



namespace SpecFlowBasics.StepDefinitions
{
    [Binding]
    public class S02_LoginStepDef
    {
        P03_NotebooksPage _homeObject;
        P02_LoginPage _loginObject;
        CommonLocators _commonObject;
        private List<UsersTestData> _userssDataList;
        private readonly JsonFileManager _converter;
        private string UsersJson = FilePaths.UsersJson;



        public S02_LoginStepDef(IWebDriver driver)
        {
            this._homeObject = new P03_NotebooksPage(Hooks.driver);
            this._loginObject = new P02_LoginPage(Hooks.driver);
            this._commonObject = new CommonLocators(Hooks.driver);

            this._converter = new JsonFileManager();
            this._userssDataList = ConvertJsonToUserssDataList();

        }

        private List<UsersTestData> ConvertJsonToUserssDataList()
        {
            return _converter.ConvertJsonToObject<List<UsersTestData>>(UsersJson);
        }


        [Given(@"user navigates to login page")]
        public void GivenUserNavigatesToLoginPage()
        {
            _commonObject.ClickLoginPage();
        }

        [Given(@"user login with email and password (.*)")]
        public void GivenUserLoginWithEmailAndPassword(string accountType)
        {
            _loginObject.EnterValidEmailAndPassword(_userssDataList, accountType);
        }

        [When(@"the user clicks the login button")]
        public void WhenTheUserClicksTheLoginButton()
        {
            _loginObject.UserLogIn();
        }

        [Then(@"user login to the system successfully")]
        public void ThenUserLoginToTheSystemSuccessfully()
        {
          //  Assert.IsTrue(_commonObject.LogOutLink.Displayed);

        }

       
    }
}
