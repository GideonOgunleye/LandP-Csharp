using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visit.BaseClasses;
using Visit.ComponentHelper;

namespace Visit.PageObject
{
    public class LondonTubePage : PageBase
    {
        private IWebDriver driver;

        public LondonTubePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        [FindsBy(How = How.ClassName, Using = "article-h1")]
        private IWebElement _title;

        public string title()
        {
            //new WebDriverExtensions(_webDriver).WaitForDisappear(_title);
            //new WebDriverExtensions(_driver).WaitForPresence(_title);
            GenericHelper.WaitForWebElementInPage(By.ClassName("article-h1"), TimeSpan.FromMilliseconds(500));

            return _title.Text;
        }
    }
}
