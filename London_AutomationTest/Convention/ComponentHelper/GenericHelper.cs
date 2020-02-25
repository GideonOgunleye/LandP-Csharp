using Convention.Settings;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Convention.ComponentHelper
{
    public class GenericHelper
    {
        private IWebDriver driver;

        public GenericHelper(IWebDriver driver)
        {
            this.driver = driver;
        }


        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(GenericHelper));
        private static Func<IWebDriver, bool> WaitForWebElementFunc(By locator)

        {
            return ((x) =>
            {
                if (x.FindElements(locator).Count == 1)
                    return true;
                Logger.Info(" Waiting for Element : " + locator);
                return false;
            });
        }

        private static Func<IWebDriver, IList<IWebElement>> GetAllElements(By locator)
        {
            return ((x) =>
            {
                return x.FindElements(locator);
            });
        }

        private static Func<IWebDriver, IWebElement> WaitForWebElementInPageFunc(By locator)
        {
            return ((x) =>
            {
                if (x.FindElements(locator).Count == 1)
                    return x.FindElement(locator);
                return null;
            });
        }

        public static void SelecFromAutoSuggest(By autoSuggesLocator, string initialStr, string strToSelect,
            By autoSuggestistLocator)
        {
            var autoSuggest = ObjectRepository.Driver.FindElement(autoSuggesLocator);
            autoSuggest.SendKeys(initialStr);
            Thread.Sleep(1000);

            var wait = GenericHelper.GetWebdriverWait(TimeSpan.FromSeconds(40));
            var elements = wait.Until(GetAllElements(autoSuggestistLocator));
            var select = elements.First((x => x.Text.Equals(strToSelect, StringComparison.OrdinalIgnoreCase)));
            select.Click();
            Thread.Sleep(1000);
        }

        public static WebDriverWait GetWebdriverWait(TimeSpan timeout)
        {
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(1));
            WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, timeout)
            {
                PollingInterval = TimeSpan.FromMilliseconds(500),
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            Logger.Info(" Wait Object Created ");
            return wait;
        }
        public static bool IsElemetPresent(By locator)
        {
            try
            {
                Logger.Info(" Checking for the element " + locator);
                return ObjectRepository.Driver.FindElements(locator).Count == 1;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public static IWebElement GetElement(By locator)
        {
            if (IsElemetPresent(locator))
                return ObjectRepository.Driver.FindElement(locator);
            else
                throw new NoSuchElementException("Element Not Found : " + locator.ToString());
        }

        public static string TakeScreenShot(string filename = "Screen")
        {
            var screen = ObjectRepository.Driver.TakeScreenshot();
            if (filename.Equals("Screen"))
            {
                filename = filename + DateTime.UtcNow.ToString("yyyy-MM-dd-mm-ss") + ".jpeg";
                screen.SaveAsFile(filename, ScreenshotImageFormat.Jpeg);
                Logger.Info(" ScreenShot Taken : " + filename);
                //return;
            }
            screen.SaveAsFile(filename, ScreenshotImageFormat.Jpeg);
            Logger.Info(" ScreenShot Taken : " + filename);
            return filename;
        }

        public static string TakeScreenShot2(string ImageName)
        {
            var screenshot = ObjectRepository.Driver.TakeScreenshot();
            string Filename = ImageName + DateTime.UtcNow.ToString("yyyy-MM-dd-mm-ss") + ".jpeg";
            string localpath = "C:\\Users\\TOM\\source\\repos\\Automation Tests\\London_AutomationTest\\Visit\\bin\\Debug\\TestReport\\" + Filename + ".png";
            screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Png);
            return localpath;
        }

        public static bool WaitForWebElement(By locator, TimeSpan timeout)
        {
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(1));
            Logger.Info(" Setting the Explicit wait to 1 sec ");
            var wait = GetWebdriverWait(timeout);
            var flag = wait.Until(WaitForWebElementFunc(locator));
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeOut()));
            Logger.Info(" Setting the Explicit wait Configured value ");
            return flag;
        }

        public static IWebElement WaitForWebElementInPage(By locator, TimeSpan timeout)
        {
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(1));
            Logger.Info(" Setting the Explicit wait to 1 sec ");
            var wait = GetWebdriverWait(timeout);
            var flag = wait.Until(WaitForWebElementInPageFunc(locator));
            Logger.Info(" Setting the Explicit wait Configured value ");
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeOut()));
            return flag;
        }
        public static string Capture(IWebDriver driver, string screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
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
