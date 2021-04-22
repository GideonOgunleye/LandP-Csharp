using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LnP.BaseClasses;
using LnP.ComponentHelper;

namespace LnP.PageObject
{
    public class EventCalenderPage : PageBase
    {

        private IWebDriver driver;

        public EventCalenderPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        [FindsBy(How = How.XPath, Using = ".//*[@id='content']/div/div[2]/div/div/div[2]/section[1]/div[1]/p")]
        private IWebElement _eventsContainer;

        public bool HasEvents()
        {
            //new WebDriverExtensions(_driver).WaitForPresence(_eventsContainer);
            //GenericHelper.WaitForWebElementInPage(By.ClassName("callout h112 cf"), TimeSpan.FromMilliseconds(500));
            JavaScriptExecutor.ScrollToElement(_eventsContainer);

            return !String.IsNullOrEmpty(_eventsContainer.Text);
        }
    }
}
