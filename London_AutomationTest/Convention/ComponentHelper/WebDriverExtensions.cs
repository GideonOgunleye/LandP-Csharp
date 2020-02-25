using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Convention.ComponentHelper
{
    public class WebDriverExtensions
    {
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(WebDriverExtensions));
        private IWebDriver driver;
        public const int PollingIntervalMilliseconds = 100;
        public const int ExplicitWaitSeconds = 10;


        public WebDriverExtensions(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void WaitForPresence(IWebElement element, int timeoutSeconds = 50)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds))
            {
                PollingInterval = TimeSpan.FromMilliseconds(PollingIntervalMilliseconds)
            };
            wait.IgnoreExceptionTypes(typeof(Exception));
            wait.Until(webDriver => element.Displayed);
        }

        public void WaitForDisappear(IWebElement element)
        {
            if (element == null) return;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            {
                Timeout = TimeSpan.FromSeconds(ExplicitWaitSeconds),
                PollingInterval = TimeSpan.FromMilliseconds(PollingIntervalMilliseconds)
            };
            wait.IgnoreExceptionTypes(typeof(OpenQA.Selenium.NoSuchElementException));
            wait.Until(webDriver => !element.Displayed);
        }

        public void WaitForElementToNotExist(string ID)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until<bool>((d) =>
            {
                try
                {
                    // If the find succeeds, the element exists, and
                    // we want the element to *not* exist, so we want
                    // to return true when the find throws an exception.
                    IWebElement element = d.FindElement(By.Id(ID));
                    return !element.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return true;
                }
            });
        }

        public void Sleep(int sleep = 5000)
        {
            Thread.Sleep(sleep);
        }

        public void ScrollToView(IWebElement element)
        {
            if (element.Location.Y > 200)
            {
                ScrollTo(0, element.Location.Y - 100); // Make sure element is in the view but below the top navigation pane
            }

        }
        public void ScrollTo(int xPosition = 0, int yPosition = 0)
        {
            var js = String.Format("window.scrollTo({0}, {1})", xPosition, yPosition);
            ((IJavaScriptExecutor)driver).ExecuteScript(js);
        }

        public bool ElementIsPresent(IWebElement element)
        {
            try
            {
                return element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
