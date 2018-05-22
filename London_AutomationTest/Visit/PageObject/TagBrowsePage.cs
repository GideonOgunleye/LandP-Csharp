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
    public class TagBrowsePage : PageBase
    {
        private IWebDriver driver;

        public TagBrowsePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        [FindsBy(How = How.ClassName, Using = "search-grid-tab-content")]
        private IWebElement _searchGrid;

        public bool HasSearchGrid()
        {
            //new WebDriverExtensions(_driver).WaitForPresence(_searchGrid);
            GenericHelper.WaitForWebElement(By.ClassName("search-grid-tab-content"), TimeSpan.FromMilliseconds(500));
            return _searchGrid.Displayed;
        }
    }
}
