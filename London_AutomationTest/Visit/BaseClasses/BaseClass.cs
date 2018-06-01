//using ExcelDataReader.Log;
//using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Visit.ComponentHelper;
using Visit.Configuration;
using Visit.CustomException;
using Visit.Settings;

namespace Visit.BaseClasses
{
    [TestClass]
    public class BaseClass
    {
        //private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(BaseClass));
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public TestContext TestContext { get; set; }

        private ScreenshotTaker ScreenshotTaker { get; set; }
        

        private static FirefoxProfile GetFirefoxptions()
        {
            FirefoxProfile profile = new FirefoxProfile();
            
            FirefoxProfileManager manager = new FirefoxProfileManager();
            //profile = manager.GetProfile("default");
            Logger.Info(" Using Firefox Profile ");
            return profile;
        }
        private static ChromeOptions GetChromeOptions()
        {
            ChromeOptions option = new ChromeOptions();

            try
            {

                //option.BinaryLocation = @"C:\\Workspace\\London_AutomationTest\\packages\\Selenium.WebDriver.ChromeDriver.2.38.0.1\\driver\\win32\\chromedriver.exe";
                option.AddArgument("no-sandbox");
                option.AddArgument("--log-level=3");
                option.AddArgument("start-maximized");

                //option.AddExtension(@"C:\Users\rahul.rathore\Desktop\Cucumber\extension_3_0_12.crx");
                Logger.Info(" Using Chrome Options ");
                
            }
            catch (Exception e)
            {
                Logger.Info(e);
                //throw;
            }

            return option;
        }

        private static InternetExplorerOptions GetIEOptions()
        {
            InternetExplorerOptions options = new InternetExplorerOptions();
            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            options.EnsureCleanSession = true;
            options.ElementScrollBehavior = InternetExplorerElementScrollBehavior.Bottom;
            Logger.Info(" Using Internet Explorer Options ");
            return options;
        }


        private static FirefoxDriver GetFirefoxDriver()
        {
            FirefoxDriver driver = new FirefoxDriver(GetFirefoxptions());
            return driver;
        }

        private static ChromeDriver GetChromeDriver()
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.SuppressInitialDiagnosticInformation = true;
            //string chromeDriverDirectory = "C:\\Workspace\\London_AutomationTest\\packages\\Selenium.WebDriver.ChromeDriver.2.38.0.1\\driver\\win32\\chromedriver.exe";
            ChromeDriver driver = new ChromeDriver(service , GetChromeOptions(), TimeSpan.FromMinutes(3));

            //ChromeDriver driver = new ChromeDriver(GetChromeOptions());

            return driver;
        }

        private static InternetExplorerDriver GetIEDriver()
        {
            InternetExplorerDriver driver = new InternetExplorerDriver(GetIEOptions());
            return driver;
        }

        private static PhantomJSDriver GetPhantomJsDriver()
        {
            PhantomJSDriver driver = new PhantomJSDriver(GetPhantomJsDrvierService());

            return driver;
        }

        private static PhantomJSOptions GetPhantomJsptions()
        {
            PhantomJSOptions option = new PhantomJSOptions();
            option.AddAdditionalCapability("handlesAlerts", true);
            Logger.Info(" Using PhantomJS Options  ");
            return option;
        }

        private static PhantomJSDriverService GetPhantomJsDrvierService()
        {
            PhantomJSDriverService service = PhantomJSDriverService.CreateDefaultService();
            service.LogFile = "TestPhantomJS.log";
            service.HideCommandPromptWindow = false;
            service.LoadImages = true;
            Logger.Info(" Using PhantomJS Driver Service  ");
            return service;
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


        [AssemblyInitialize]
        //[BeforeFeature()]
        

        public static void InitWebdriver(TestContext tc)
        {
            //Thread.Sleep(5000);
            //ReportHelper.StartReporter();

            ObjectRepository.Config = new AppConfigReader();

            switch (ObjectRepository.Config.GetBrowser())
            {
                case BrowserType.Firefox:
                    ObjectRepository.Driver = GetFirefoxDriver();
                    Logger.Info(" Using Firefox Driver  ");

                    break;

                case BrowserType.Chrome:
                    ObjectRepository.Driver = GetChromeDriver();
                    Logger.Info(" Using Chrome Driver  ");
                    break;

                case BrowserType.IExplorer:
                    ObjectRepository.Driver = GetIEDriver();
                    Logger.Info(" Using Internet Explorer Driver  ");
                    break;

                case BrowserType.PhantomJs:
                    ObjectRepository.Driver = GetPhantomJsDriver();
                    Logger.Info(" Using PhantomJs Driver  ");
                    break;

                default:
                    throw new NoSuitableDriverFound("Driver Not Found : " + ObjectRepository.Config.GetBrowser().ToString());
            }
            ObjectRepository.Driver.Manage()
                .Timeouts().PageLoad = TimeSpan.FromSeconds(ObjectRepository.Config.GetPageLoadTimeOut());
            //.SetPageLoadTimeout(TimeSpan.FromSeconds(ObjectRepository.Config.GetPageLoadTimeOut()));
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeOut()));
            BrowserHelper.BrowserMaximize();


        }



        [AssemblyCleanup]
        //[AfterScenario()]
        public static void TearDown()
        {

            if (ObjectRepository.Driver != null)
            {
                ObjectRepository.Driver.Close();
                ObjectRepository.Driver.Quit();
            }
            Logger.Info(" Stopping the Driver  ");
        }
    }
}
