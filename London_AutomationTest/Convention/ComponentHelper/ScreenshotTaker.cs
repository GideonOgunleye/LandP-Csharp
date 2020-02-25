using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convention.ComponentHelper
{
    public class ScreenshotTaker
    {
        //private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(ReportHelper));
        private static readonly Logger TheLogger = LogManager.GetCurrentClassLogger();
        private readonly IWebDriver _driver;
        private readonly TestContext _testContext;

        public ScreenshotTaker(IWebDriver driver, TestContext testContext)
        {
            if (driver == null)
                return;
            _driver = driver;
            _testContext = testContext;
            ScreenshotFileName = _testContext.TestName;

        }

        public string ScreenshotFilePath { get; private set; }
        private string ScreenshotFileName { get; set; }

        public void CreateScreenshotIfTestFailed()
        {
            if (_testContext.CurrentTestOutcome == UnitTestOutcome.Failed ||
                _testContext.CurrentTestOutcome == UnitTestOutcome.Inconclusive)
                TakeScreenshotForFailure();
        }

        public string TakeScreenshot(string screenshotFileName)
        {
            var ss = GetScreenshot();
            var successfullySaved = TryToSaveScreenshot(screenshotFileName, ss);

            return successfullySaved ? ScreenshotFileName : "";

        }

        public bool TakeScreenshotForFailure()
        {
            ScreenshotFileName = $"FAIL_{ScreenshotFileName}";

            var ss = GetScreenshot();
            var successfullySaved = TryToSaveScreenshot(ScreenshotFileName, ss);
            if (successfullySaved)
                TheLogger.Error($"Screenshot of Error => {ScreenshotFileName}");
            return successfullySaved;


        }

        private Screenshot GetScreenshot()
        {
            return ((ITakesScreenshot)_driver)?.GetScreenshot();
        }

        private bool TryToSaveScreenshot(string screenshotFileName, Screenshot ss)
        {

            try
            {
                SaveScreenshot(screenshotFileName, ss);
                return true;
            }
            catch (Exception e)
            {
                TheLogger.Error(e.InnerException);
                TheLogger.Error(e.Message);
                TheLogger.Error(e.StackTrace);
                return false;
            }
        }

        private void SaveScreenshot(string screenshotName, Screenshot ss)
        {
            if (ss == null)
                return;
            ScreenshotFileName = $"{ReportHelper.LatestResultReportFolder}\\{screenshotName}.jpg";
            ScreenshotFileName = ScreenshotFilePath.Replace('/', ' ').Replace(' ', ' ');
            ss.SaveAsFile(ScreenshotFilePath, ScreenshotImageFormat.Png);
        }
    }
}
