using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Visit.Settings;

namespace Visit.ComponentHelper
{
    public class GetScreenShot
    {
        private IWebDriver driver;
        private static string ApplicationDebugFolder => @"TestReport\";
        public static string LatestResultReportFolder { get; set; }

        public GetScreenShot(IWebDriver driver)
        {
            this.driver = driver;
        }

        public static string Capture(IWebDriver driver,string screenShotName)
        {
            string fileName = screenShotName + DateTime.UtcNow.ToString("yyyy-MM-dd-mm-ss") +".Png";
            string path = Environment.CurrentDirectory;

            var filePath = Path.GetFullPath(ApplicationDebugFolder);
            LatestResultReportFolder = Path.Combine(path, filePath, fileName);

            ITakesScreenshot ts = (ITakesScreenshot) driver;
            Screenshot screenshot = ts.GetScreenshot();
            //string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            //var dir = TestContext.CurrentContext.TestDirectory + "TestReport\\";
           // string finalpath = path.Substring(0, path.LastIndexOf("bin")) + "\\ErrorScreenshots\\" + screenShotName + DateTime.UtcNow.ToString("yyyy-MM-dd-mm-ss") +
                               //".Png";


            string localpath = new Uri(LatestResultReportFolder).LocalPath;


            screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Png);
            //var mediaModel = MediaEntityBuilder.
            return localpath;
        }

       /* public static string Capture2(IWebDriver driver, string screenShotName)
        {
            var screen = ObjectRepository.Driver.TakeScreenshot();
            filename = filename + DateTime.UtcNow.ToString("yyyy-MM-dd-mm-ss") + ".jpeg";
            screen.SaveAsFile(filename, ScreenshotImageFormat.Jpeg);
            Logger.Info(" ScreenShot Taken : " + filename);
            return;
        }*/
    }
}
