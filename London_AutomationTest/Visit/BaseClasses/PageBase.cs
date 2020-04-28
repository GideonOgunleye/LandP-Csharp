using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LnP.ComponentHelper;

namespace LnP.BaseClasses
{
    public class PageBase
    {
        private IWebDriver driver;

        public PageBase(IWebDriver _driver)
        {
            PageFactory.InitElements(_driver, this);
            this.driver = _driver;
        }

        public void Logout()
        {
            

        }

        protected void NaviGateToHomePage()
        {
            //HomeLink.Click();
        }

        public string Title
        {
            get { return driver.Title; }
        }
    }
}
