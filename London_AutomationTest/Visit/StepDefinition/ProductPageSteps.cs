using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Visit.BaseClasses;
using Visit.ComponentHelper;
using Visit.PageObject;
using Visit.Settings;

namespace Visit.StepDefinition
{
    [Binding]
    public class ProductPageSteps
    {
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(BaseClass));

        [Given(@"I navigate to the product page '(.*)'")]
        public void GivenINavigateToTheProductPage(string p0)
        {
            try
            {
                NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite() + p0);
            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                //throw;
            }
        }

        [Then(@"I should be shown the Main Image")]
        public void ThenIShouldBeShownTheMainImage()
        {
            try
            {
                ObjectRepository.Ppage = new ProductPage(ObjectRepository.Driver);
                Assert.IsTrue(!String.IsNullOrEmpty(ObjectRepository.Ppage.MainImage()));
            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                //throw;
            }
        }


    }
}
