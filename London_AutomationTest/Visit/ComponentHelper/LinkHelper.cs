using log4net;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LnP.ComponentHelper
{
    public class LinkHelper
    {
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(LinkHelper));
        private static IWebElement element;

        public static void ClickLink(By Locator)
        {
            element = GenericHelper.GetElement(Locator);
            element.Click();
            Logger.Info(" Clicking on link : " + Locator);
        }
    }
}
