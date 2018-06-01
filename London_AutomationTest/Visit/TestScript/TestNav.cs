using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using Visit.ComponentHelper;
using Visit.Settings;
using NLog;
using Visit.BaseClasses;

namespace Visit.TestScript
{
    [TestClass]
    public class TestNav : ReportingBase
    {
/*        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public TestContext TestContext { get; set; }

        private ScreenshotTaker ScreenshotTaker { get; set; }

        [TestInitialize]
        public void TestMethodSetup()
        {
            Logger.Debug("**********************************  TEST STARTED");
            ReportHelper.AddTestCaseMetaDataToHtmlReport(TestContext);

        }

        [TestCleanup]

        public void TestMethodTearDown()
        {
            Logger.Debug(GetType().FullName + " Started Method Teardown");

            try
            {
                Console.WriteLine("TAKE SCREENSHOT!!!");
                TakeScreenshotForTestFailure();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Logger.Error(e.Source);
                Logger.Error(e.StackTrace);
                Logger.Error(e.InnerException);
                Logger.Error(e.Message);
            }
            finally
            {
                Logger.Debug(TestContext.TestName);
                Logger.Debug("********************* TEST STOPPED");
            }
        }

        private void TakeScreenshotForTestFailure()
        {
            if (ScreenshotTaker != null)
            {
                ScreenshotTaker.CreateScreenshotIfTestFailed();
                ReportHelper.ReportTestOutCome(ScreenshotTaker.ScreenshotFilePath);
            }
            else
            {
                ReportHelper.ReportTestOutCome("");
            }
        }*/

        [TestMethod]
        public void GetNav()
        {
            //ExtentReportHelper.extentTest = ExtentReportHelper.extentReport.CreateTest("GetNav Test");

            //ExtentReport extent = new ExtentReports();
            //ExtentReportHelper.extentTest = extent.CreateTest("GetNav", "Testing");

            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            ReportHelper.PassingTestLogger("TestReport Sucessful");

            //ExtentReportHelper.extentTest.Log(Status.Pass, "Pass");
            //ExtentReportHelper.extentTest.Pass("Test Passed");
            Thread.Sleep(5000);
            //ExtentReportHelper.extentTest.Pass("Test Passed");

            
        }
    }
}
