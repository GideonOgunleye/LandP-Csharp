using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
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

        public GetScreenShot(IWebDriver driver)
        {
            this.driver = driver;
        }

        public static string Capture(IWebDriver driver,string screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot) driver;
            Screenshot screenshot = ts.GetScreenshot();
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string finalpath = path.Substring(0, path.LastIndexOf("bin")) + "ErrorScreenshots\\" + screenShotName + DateTime.UtcNow.ToString("yyyy-MM-dd-mm-ss") +
                               ".Jpeg";
            string localpath = new Uri(finalpath).LocalPath;
            screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Jpeg);
            return localpath;
        }
    }
}
