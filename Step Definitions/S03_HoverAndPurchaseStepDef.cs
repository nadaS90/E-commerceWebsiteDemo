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
    public class S03_HoverAndPurchaseStepDef
    {
        CommonLocators _commonObject;
        P03_NotebooksPage _noteBookObject;
        P06_ShoppingCart _shoppingCartObject;
        P07_CheckOutPage _checkOutPageObject;
        private List<UsersTestData> _userssDataList;
        private readonly JsonFileManager _converter;
        private string UsersJson = FilePaths.UsersJson;



        public S03_HoverAndPurchaseStepDef(IWebDriver driver)
        {
            this._converter = new JsonFileManager();
            this._noteBookObject = new P03_NotebooksPage(Hooks.driver);
            this._shoppingCartObject = new P06_ShoppingCart(Hooks.driver);
            this._commonObject = new CommonLocators(Hooks.driver);
            this._checkOutPageObject = new P07_CheckOutPage(Hooks.driver);
            this._userssDataList = ConvertJsonToUserssDataList();
        }

        private List<UsersTestData> ConvertJsonToUserssDataList()
        {
            return _converter.ConvertJsonToObject<List<UsersTestData>>(UsersJson);
        }

        [Given(@"user hover categories")]
        public void GivenUserHoverCategories()
        {
            _commonObject.HoverMenuAndSelectCategory();
        }

        [Given(@"user filter the products")]
        public void GivenUserFilterTheProducts()
        {
            _noteBookObject.SortByNameAToZ();
            _noteBookObject.FilterByCpuTypeIntelCoreI5();
        }


        [Then(@"user select a product to purchse")]
        public void ThenUserSelectAProductToPurchse()
        {
            _noteBookObject.SelectTargetedSamsungDeviceToPurchase();
        }

        [When(@"user add product to the cart")]
        public void WhenUserAddProductToTheCart()
        {
            _noteBookObject.ClickOnAddToCartButton();
        }

        [When(@"User navigates to cart and find product")]
        public void WhenUserNavigatesToCartAndFindProduct()
        {
            _commonObject.ClosePopUpMsg();
            _commonObject.ClickShoppingCartPage();
        }


        [When(@"the user click on the Check Box")]
        public void WhenTheUserClickOnTheCheckBox()
        {
            _shoppingCartObject.ClickOnCheckBox();
        }

        [When(@"the user Click on checkout button")]
        public void WhenTheUserClickOnCheckoutButton()
        {
            _shoppingCartObject.ClickOnCheckOutButton();
        }

        [When(@"User fill All required data")]
        public void WhenUserFillAllRequiredData()
        {
            _checkOutPageObject.FillBillingAddress(_userssDataList);
            _checkOutPageObject.ClickOnContinueButton();
            _checkOutPageObject.ClickOnContinueToNextStepButton();
            _checkOutPageObject.ClickOnContinuePaymentButton();
            _checkOutPageObject.ClickOnContinueToConfirmOrderButton();
            _checkOutPageObject.ClickOnConfirmOrderButton();
        }

    }
}
