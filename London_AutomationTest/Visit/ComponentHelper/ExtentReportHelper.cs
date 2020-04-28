using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using LnP.Settings;

namespace LnP.ComponentHelper
{
    
    public class ExtentReportHelper
    {
        public static ExtentReports extentReport;
        public static ExtentTest extentTest;

        [SetUp]
        public static void StartReport()
        {
            extentTest = extentReport.CreateTest(TestContext.CurrentContext.Test.Name);

        }

        [OneTimeSetUp]
        protected void Setup()
        {
            {
                /*string path = Assembly.GetCallingAssembly().CodeBase;
                string actualpath = path.Substring(0, path.LastIndexOf("TestReport"));
                string projectpath = new Uri(actualpath).LocalPath;
                string reportpath = projectpath + "TestReport\\test.html";
                var extentHtml = new ExtentHtmlReporter(reportpath);

                extentReport = new ExtentReports();
                extentReport.AttachReporter(extentHtml);

                extentReport.AddSystemInfo("Host name", "ABCD");
                extentReport.AddSystemInfo("Environment", "Automation");
                extentReport.AddSystemInfo("Version", "ABCD");*/

                var dir = TestContext.CurrentContext.TestDirectory + "TestReport\\";
                var fileName = this.GetType().ToString() + ".html";
                var htmlReporter = new ExtentHtmlReporter(dir + fileName);

                extentReport = new ExtentReports();
                extentReport.AttachReporter(htmlReporter);

            }
        }

        [TearDown]
        public static void GetResult()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace) ? "" : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);

            Status logstatus;
            switch (status)
            {
                case TestStatus.Failed:
                    //logstatus = Status.Fail;
                    
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }
            //string screenshotPath = GenericHelper.TakeScreenShot();
            //extentTest.Log(logstatus, "Test ended with " + logstatus + stacktrace);
            //extentTest.Log(logstatus, "Snapshot below" + extentTest.AddScreenCaptureFromPath(screenshotPath));
            //extentReport.Flush();
        }

        [Test]
        public void Nav()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            extentTest.Pass("Passed");
            extentTest.Log(Status.Pass,"Test Passed");

        }


    }
}
