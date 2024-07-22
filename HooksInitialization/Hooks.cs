using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Gherkin.Model;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using System.Xml.Linq;
using System.Diagnostics;

namespace SpecFlowBasics.HooksInitialization
{
    [Binding]
    public sealed class Hooks
    {
        private IObjectContainer container;
        public static IWebDriver driver;
        private static ExtentTest featureName;
        private static ExtentTest scenarioName;
        private static ExtentReports extent;

        public Hooks(IObjectContainer container)
        {
            this.container = container;
        }



        [BeforeTestRun]
        public static void InitializeReportSteps()
        {
            var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var basePath = currentDirectory.Split(new string[] { "\\bin" }, StringSplitOptions.None)[0];
            var reporter = basePath + "\\Reports\\ExtentReport.html";

            var htmlReporter = new ExtentHtmlReporter(reporter);


            extent = new ExtentReports();

            extent.AttachReporter(htmlReporter);
        }


        [BeforeFeature]
        public static void CreateExtentTest()
        {
            featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }



        [BeforeScenario(@"smoke")]
        public void BeforeScenarioWithTag()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demo.nopcommerce.com/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            container.RegisterInstanceAs(driver);
            scenarioName = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);

        }
        public MediaEntityModelProvider TakeScreenShotAsBase64String(String Name)
        {
            var MediaEntity = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(MediaEntity, Name).Build();
        }




        [AfterStep]
        public void InitializeStepReports()
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            var stepError = ScenarioContext.Current.TestError;
            var skippedStep = ScenarioContext.Current.ScenarioExecutionStatus.ToString();
            var screenshot = TakeScreenShotAsBase64String(ScenarioContext.Current.ScenarioInfo.Title.Trim());


            //3shan y3ml check from feature file for each step w check enha Passed
            if (stepError == null)
            {
                switch (stepType)
                {
                    case "Given":
                        scenarioName.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                        break;
                    case "When":
                        scenarioName.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                        break;
                    case "Then":
                        scenarioName.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                        break;
                    case "And":
                        scenarioName.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
                        break;
                }
            }

            //shan y3ml check from feature file for each step w check enha Failed
            else
            {
                switch (stepType)
                {
                    case "Given":
                        scenarioName.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message, screenshot);
                        break;
                    case "When":
                        scenarioName.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message, screenshot);
                        break;
                    case "Then":
                        scenarioName.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message, screenshot);
                        break;
                    case "And":
                        scenarioName.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message, screenshot);
                        break;
                }
            }


            //shan y3ml check from feature file for each step w check enha Skipped
            if (skippedStep == "StepDefinitionPending")
            {
                switch (stepType)
                {
                    case "Given":
                        scenarioName.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending / Skipped");
                        break;
                    case "When":
                        scenarioName.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending / Skipped");
                        break;
                    case "Then":
                        scenarioName.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending / Skipped");
                        break;
                    case "And":
                        scenarioName.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending / Skipped");
                        break;
                }
            }

        }


        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine("selenium WebDriver quit"); 
            driver.Quit();
            var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var basePath = currentDirectory.Split(new string[] { "\\bin" }, StringSplitOptions.None)[0];
        }



        [AfterTestRun]
        public static void FlushExtentReport()
        {
            extent.Flush();
        }

    }
}