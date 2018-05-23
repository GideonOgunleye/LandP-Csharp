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
    public class HomePage : PageBase
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        [FindsBy(How = How.ClassName, Using = "tagline")]
        private IWebElement _title;

        public string HTitle()
        {
            //new WebDriverExtensions(_driver).WaitForPresence(_title);
            GenericHelper.WaitForWebElement(By.ClassName("tagline"), TimeSpan.FromMilliseconds(500));
            return _title.Text;
        }
    }
}
