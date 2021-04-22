using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using TechTalk.SpecFlow;
using LnP.BaseClasses;
using LnP.ComponentHelper;
using LnP.PageObject;
using LnP.Settings;
using OpenQA.Selenium;

namespace LnP.StepDefinition
{
    [Binding]
    public class TagBrowsePageSteps
    {
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(BaseClass));
        //private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        [Given(@"I navigate to the Tag Browser page '(.*)'")]
        public void GivenINavigateToTheTagBrowserPage(string p0)
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

        [Given(@"I navigate to the Preview Tag Browser page '(.*)'")]
        public void GivenINavigateToThePreviewTagBrowserPage(string p0)
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

        [Then(@"I should be shown the tag browse search grid")]
        public void ThenIShouldBeShownTheTagBrowseSearchGrid()
        {

            try
            {
                //ObjectRepository.TBpage = new TagBrowsePage(ObjectRepository.Driver);
                //Assert.IsTrue(ObjectRepository.TBpage.HasSearchGrid());
                Assert.IsTrue(GenericHelper.WaitForWebElement(By.ClassName("search-grid-results"), TimeSpan.FromMilliseconds(500)));
                ButtonHelper.ClickButton(By.XPath(".//*[@class='search-grid-results']/li[1]/a"));
            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                //throw;
            }

        }


    }
}
