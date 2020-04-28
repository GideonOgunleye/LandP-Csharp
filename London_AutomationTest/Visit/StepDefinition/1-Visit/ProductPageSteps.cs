using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using LnP.BaseClasses;
using LnP.ComponentHelper;
using LnP.PageObject;
using LnP.Settings;

namespace LnP.StepDefinition
{
    [Binding]
    public class ProductPageSteps
    {
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(BaseClass));
        //private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

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

        [Given(@"I navigate to the Preview product page '(.*)'")]
        public void GivenINavigateToThePreviewProductPage(string p0)
        {
            try
            {
                NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetPreviewWebsite() + p0);
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
