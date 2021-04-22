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
    public class ProductPage : PageBase
    {
        private IWebDriver driver;

        public ProductPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        [FindsBy(How = How.XPath, Using = "//*[contains(@class, 'product-info')]/div/figure/img")]
        private IWebElement _mainImage;

        public string MainImage()
        {
            //new WebDriverExtensions(_driver).WaitForPresence(_mainImage);
            GenericHelper.WaitForWebElement(By.XPath("//*[contains(@class, 'product-info')]/div/figure/img"), TimeSpan.FromMilliseconds(500));
            return _mainImage.GetAttribute("src");
        }
    }
}
