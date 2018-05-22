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
    public class ErrorPage : PageBase
    {
        private IWebDriver driver;

        public ErrorPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        [FindsBy(How = How.ClassName, Using = "error-code")]
        private IWebElement _errorCode;

        [FindsBy(How = How.ClassName, Using = "sc-applicationHeader-title")]
        private IWebElement _sitecoreDefaultError;

        public bool HasErrorCode()
        {
            //return new WebDriverExtensions(_driver).ElementIsPresent(_errorCode);
            GenericHelper.IsElemetPresent(By.ClassName("error-code"));

            return _errorCode.Displayed;
        }

        public string ErrorCode()
        {
            //new WebDriverExtensions(_driver).ElementIsPresent(_errorCode);
            GenericHelper.IsElemetPresent(By.ClassName("error-code"));

            try
            {
                return _errorCode.Text;
            }
            catch (NoSuchElementException e)
            {
                return String.Empty;
            }
        }

        public bool HasDefaultSitecoreError()
        {
            //new WebDriverExtensions(_driver).ElementIsPresent(_sitecoreDefaultError);
            GenericHelper.IsElemetPresent(By.ClassName("sc-applicationHeader-title"));

            try
            {
                return _sitecoreDefaultError.Text.Equals("The requested document was not found", StringComparison.InvariantCultureIgnoreCase);
            }
            catch (NoSuchElementException e)
            {
                return false;
            }

        }

    }
}
