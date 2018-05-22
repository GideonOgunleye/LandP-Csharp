using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
//using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;
using Visit.BaseClasses;
using Visit.ComponentHelper;

namespace Visit.PageObject
{
    public class AreaBrowsePage : PageBase
    {
        private IWebDriver driver;

        [FindsBy(How = How.ClassName, Using = "search-grid-results")]
        private IWebElement _searchGrid;

    

        public AreaBrowsePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public bool HasSearchGrid()
        {
            //new WebDriverExtensions(driver).WaitForPresence(_searchGrid);
            

            GenericHelper.WaitForWebElementInPage(By.ClassName("search-grid-results"), TimeSpan.FromSeconds(50));
            return _searchGrid.Displayed;
        }


    }
}
