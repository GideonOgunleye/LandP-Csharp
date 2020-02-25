using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convention.ComponentHelper
{
    public static class ReportHelper
    {
        private static readonly Logger TheLogger = LogManager.GetCurrentClassLogger();
        //private static readonly ILog TheLogger = Log4NetHelper.GetXmlLogger(typeof(ReportHelper));

        private static ExtentReports ReportManager { get; set; }

        private static string ApplicationDebugFolder => "C://Users//TOM//source//repos//Automation Tests//London_AutomationTest//Visit//TestReport";

        private static string HtmlReportFullPath { get; set; }

        public static string LatestResultReportFolder { get; set; }

        private static TestContext MyTestContext { get; set; }

        private static ExtentTest CurrentTestCase { get; set; }

        public static void StartReporter()
        {
            TheLogger.Info("Sample.....");

            CreateReporterDirectory();
            var htmlReporter = new ExtentHtmlReporter(HtmlReportFullPath);
            htmlReporter.Configuration().Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            
            ReportManager = new ExtentReports();
            ReportManager.AttachReporter(htmlReporter);

        }

        public static void CreateReporterDirectory()
        {
            var filePath = Path.GetFullPath(ApplicationDebugFolder);
            LatestResultReportFolder = Path.Combine(filePath, DateTime.Now.ToString("MMdd_HHmm"));
            Directory.CreateDirectory(LatestResultReportFolder);
            HtmlReportFullPath = $"{LatestResultReportFolder}\\TestResults.html";
            TheLogger.Info("Test Logged" + HtmlReportFullPath);
        }

        public static void AddTestCaseMetaDataToHtmlReport(TestContext testContext)
        {
            MyTestContext = testContext;
            CurrentTestCase = ReportManager.CreateTest(MyTestContext.TestName);
            //CurrentTestCase = ReportManager.CreateTest<Feature>("Feature");
            //CurrentTestCase.CreateNode<Scenario>(MyTestContext.)
        }

        public static void PassingTestLogger(string message)
        {
            TheLogger.Info(message);
            CurrentTestCase.Log(Status.Pass, message);
        }

        public static void ReportTestOutCome(string ScreenShotPath)
        {
            var status = MyTestContext.CurrentTestOutcome;

            switch (status)
            {
                case UnitTestOutcome.Failed:
                    TheLogger.Error($"Failed Test =>{MyTestContext.FullyQualifiedTestClassName}");
                    CurrentTestCase.AddScreenCaptureFromPath(ScreenShotPath);
                    CurrentTestCase.Fail("Fail");
                    break;
                case UnitTestOutcome.Inconclusive:
                    CurrentTestCase.AddScreenCaptureFromPath(ScreenShotPath);
                    CurrentTestCase.Warning("Inconclusive");
                    break;
                case UnitTestOutcome.Unknown:
                    CurrentTestCase.Skip("Test Skipped");
                    break;
                default:
                    CurrentTestCase.Pass("Pass");
                    break;
            }

            ReportManager.Flush();
        }

        public static void TestStepLogger(Status status, string message)
        {
            TheLogger.Info(message);
            CurrentTestCase.Log(status, message);
        }
    }
}
