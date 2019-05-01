using Business.ComponentHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BaseClasses
{
    [TestClass]
    public class ReportingBase
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

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
        }
    }
}
