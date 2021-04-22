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
    public class ThingsToDoPage : PageBase
    {
        private IWebDriver driver;

        public ThingsToDoPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        [FindsBy(How = How.CssSelector, Using = "h1")]
        private IWebElement _title;

        [FindsBy(How = How.ClassName, Using = "intro")]
        private IWebElement _copy;

        public string title()
        {
            //new WebDriverExtensions(_driver).WaitForPresence(_title);
            GenericHelper.WaitForWebElement(By.CssSelector("h1"), TimeSpan.FromMilliseconds(500));
            return _title.Text;
        }

        public string Copy()
        {
            //new WebDriverExtensions(_driver).WaitForPresence(_copy);
            GenericHelper.WaitForWebElement(By.ClassName("intro"), TimeSpan.FromMilliseconds(500));
            return _copy.Text;
        }
    }
}
