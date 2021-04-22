using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LnP.Settings;

namespace LnP.ComponentHelper
{
    public class JavaScriptExecutor
    {

        public static void ScrollTo(int xPosition = 0, int yPosition = 0)
        {
            var js = String.Format("window.scrollTo({0}, {1})", xPosition, yPosition);
            ExecuteScript(js);
        }
        

        public static object ExecuteScript(string script)
        {
            IJavaScriptExecutor executor = ((IJavaScriptExecutor)ObjectRepository.Driver);
            return executor.ExecuteScript(script);
        }

        public static void ScrollToElement(IWebElement element)
        {
            //IWebElement element = GenericHelper.GetElement(locator);
            ExecuteScript("window.scrollTo(0," + element.Location.Y + ")");
            Thread.Sleep(300);
            //element.Click();
            
        }
        public static void ScrollToAndClick(IWebElement element)
        {
            ExecuteScript("window.scrollTo(0," + element.Location.Y + ")");
            Thread.Sleep(300);
            element.Click();
        }

        public static void ScrollToAndClick(By locator)
        {
            IWebElement element = GenericHelper.GetElement(locator);
            ExecuteScript("window.scrollTo(0," + element.Location.Y + ")");
            Thread.Sleep(300);
            element.Click();
        }

        public static void ScrollToWebElement(By locator)
        {
            IWebElement element = GenericHelper.GetElement(locator);
            ExecuteScript("window.scrollTo(0," + element.Location.Y + ")");
            Thread.Sleep(300);
            //element.Click();
        }

        public static void ScrollToView(By locator)
        {
            IWebElement element = GenericHelper.GetElement(locator);

            if (element.Location.Y > 200)
            {
                ScrollTo(0, element.Location.Y - 100);
            }
        }
    }
}
