using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using log4net;

namespace SpecFlowBasics.Extensions
{
    public static class WebDriverExtensions
    {
        private static readonly double WaitTime = 30000;
        private static readonly ILog Logger = LogManager.GetLogger(typeof(WebDriverExtensions));
        private static IJavaScriptExecutor Executor;
        private static WebDriverWait Wait;



        /// <summary>
        /// Sends text to the specified element.
        /// </summary>
        public static void SendText(this IWebDriver driver, By element, string textValue, string elementName)
        {
            try
            {
                PerformAction(driver, element, elementName, () =>
                {
                    var webElement = driver.FindElement(element);
                    driver.HighlightElement(webElement); // Highlight the element before sending text
                    webElement.Clear();
                    webElement.SendKeys(textValue);
                });
            }
            catch (Exception ex)
            {
                Logger.Error($"Failed to type text in the {elementName} field: {ex.Message}");
            }
        }


        /// <summary>
        /// Give some implicit wait for elements or actions.
        /// </summary>
        public static void ImplicitWait(this IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }


        public static void ClickElement(this IWebDriver driver, By element, string elementName)
        {
            PerformAction(driver, element, elementName, () =>
            {
                var webElement = driver.FindElement(element);
                driver.HighlightElement(webElement); // Highlight the element before clicking
                driver.ImplicitWait();
                webElement.Click();
            });
        }

        private static void PerformAction(IWebDriver driver, By element, string elementName, Action action)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(WaitTime));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(element));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));

                action.Invoke();
            }
            catch (Exception ex)
            {
                string errorMessage;

                if (ex is WebDriverTimeoutException)
                {
                    errorMessage = $"Timed out waiting for the {elementName} element to be visible.";
                }
                else if (ex is ElementNotVisibleException)
                {
                    errorMessage = $"The {elementName} elghement is not visible.";
                }
                else if (ex is ElementNotInteractableException)
                {
                    errorMessage = $"The {elementName} element is not clickable.";
                }
                else
                {
                    errorMessage = $"Couldn't perform the action on the {elementName} element: {ex.Message}";
                }

                Logger.Error(errorMessage);
                Assert.Fail(errorMessage);
            }
        }

        public static void ScrollIntoView(this IWebDriver driver, IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public static void HighlightElement(this IWebDriver driver, IWebElement element)
        {
            try
            {
                var jsExecutor = (IJavaScriptExecutor)driver;
                string script = "arguments[0].style.border='3px solid yellow';";
                jsExecutor.ExecuteScript(script, element);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to highlight element: {ex.Message}");
            }
        }

        /// <summary>
        /// Refreshes the current page.
        /// </summary>
        public static void RefreshPage(this IWebDriver driver)
        {
            driver.Navigate().Refresh();
        }


        /// <summary>
        /// Get URL of the current page.
        /// </summary>
        public static string GetCurrentUrl(this IWebDriver driver)
        {
            return driver.Url;
        }


        /// <summary>
        /// Hover on current tab.
        /// </summary>
        public static void HoverElement(this IWebDriver driver, By element, string elementName, bool hoverBeforeClick = false)
        {
            PerformAction(driver, element, elementName, () =>
            {
                var webElement = driver.FindElement(element);

                driver.HighlightElement(webElement); // Highlight the element before clicking
                driver.ImplicitWait();

                Actions action = new Actions(driver);
                driver.ImplicitWait();
                action.MoveToElement(webElement).Perform();
            }
            );
        }


        public static bool IsElementPresentAndDisplayed(this IWebDriver driver, By element)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(WaitTime));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
                return driver.FindElement(element).Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
