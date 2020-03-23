using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using BoDi;
using Convention.ComponentHelper;
using Convention.Settings;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Convention.Configuration
{
    [Binding]
    public class Hooks
    {
        //Global Variable for Extend report
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;
        private static KlovReporter klov;
        private static string ApplicationDebugFolder => @"TestReport\";

        private static string HtmlReportFullPath { get; set; }

        public static string LatestResultReportFolder { get; set; }

        private readonly IObjectContainer objectContainer;

        private RemoteWebDriver _driver;

        //private readonly FeatureContext featureContext;

       public Hooks(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        } 

        /*public static void StepsWithScenarioContext(FeatureContext featureContext)
        {
            if (featureContext == null) throw new ArgumentNullException("featureContext");
            this.featureContext = featureContext;
        }*/

        [BeforeTestRun]
        public static void InitializeReport()
        {
            //Initialize Extent report before test starts
            string fileName = "ExtentReport.html";
            //string htmlpath = Path.Combine(".\\TestReport", fileName);
            /*var htmlReporter = new ExtentHtmlReporter(@"London_AutomationTest\Visit\TestReport\ExtentReport.html");
            htmlReporter.Configuration().Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;*/

            string path = Environment.CurrentDirectory;
            var filePath = Path.GetFullPath(ApplicationDebugFolder);


            /*   string workingDirectory = Environment.CurrentDirectory;
               string path = Directory.GetParent(workingDirectory).Parent.Parent.FullName; */

            //string Parent = Directory.GetParent(path).FullName;

            //LatestResultReportFolder = Path.Combine(path,filePath, DateTime.Now.ToString("MMdd_HHmm"));
            //Directory.CreateDirectory(LatestResultReportFolder);
            //HtmlReportFullPath = $"{LatestResultReportFolder}\\ExtentReport.html";
            //TheLogger.Info("Test Logged" + HtmlReportFullPath);

            /* LatestResultReportFolder = Path.Combine(path, fileName); */

            LatestResultReportFolder = Path.Combine(path, filePath, fileName);

            var htmlReporter = new ExtentHtmlReporter(LatestResultReportFolder);
            htmlReporter.Configuration().Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;


            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            extent.Flush();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            if (featureContext == null)
                throw new ArgumentNullException("featureContext");

            featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);

        }

        /*[BeforeFeature ("cms")]
        public static void BeforeCmsFeature(FeatureContext featureContext)
        {
            //featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
            if (featureContext == null)
                throw new ArgumentNullException("featureContext");


            featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);

        }*/

        [AfterStep]
        public void InsertReportingSteps()
        {
            //scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);

            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            //PropertyInfo pInfo = typeof(ScenarioContext).GetProperty("TestStatus", BindingFlags.Instance | BindingFlags.NonPublic);
            //MethodInfo getter = pInfo.GetGetMethod(nonPublic: true);
            //object TestResult = getter.Invoke(ScenarioContext.Current, null);



            if (ScenarioContext.Current.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
            }
            else if (ScenarioContext.Current.TestError != null)
            {
                string screenShotPath = GetScreenShot.Capture(ObjectRepository.Driver, "ScreenshotName");

                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text)
                        .Fail(ScenarioContext.Current.TestError.Message)
                        .AddScreenCaptureFromPath(screenShotPath, "Test.Png");

                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text)
                        .Fail(ScenarioContext.Current.TestError.Message)
                        .AddScreenCaptureFromPath(screenShotPath, "Test.Png");

                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text)
                        .Fail(ScenarioContext.Current.TestError.Message)
                        .AddScreenCaptureFromPath(screenShotPath, "Test.Png");

                else if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text)
                        .Fail(ScenarioContext.Current.TestError.Message)
                        .AddScreenCaptureFromPath(screenShotPath, "Test.Png");
            }

            //Pending Status
            /*if (TestResult.ToString() == "StepDefinitionPending")
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
            }*/

        }


        /*[AfterFeature]
        public static void AfterFeature()
        {
            Console.WriteLine("AfterFeature Hook");
        }*/

        [BeforeScenario]
        public static void BeforeScenario()
        {
            scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            Console.WriteLine("AfterScenario Hook");
            if (ScenarioContext.Current.TestError != null)
            {
                string name = ScenarioContext.Current.ScenarioInfo.Title + ".jpeg";
                GenericHelper.TakeScreenShot(name);
                Console.WriteLine(ScenarioContext.Current.TestError.Message);
                Console.WriteLine(ScenarioContext.Current.TestError.StackTrace);
            }
        }
    }
}
