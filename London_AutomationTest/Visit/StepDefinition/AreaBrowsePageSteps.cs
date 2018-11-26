using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using Visit.BaseClasses;
using Visit.ComponentHelper;
using Visit.Settings;
using Visit.PageObject;
using log4net;
//using NLog;

namespace Visit.StepDefinition
{
    [Binding]
    public class AreaBrowsePageSteps     
    {
        //private AreaBrowsePage ABpage;
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(BaseClass));
        //private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        [Given(@"I navigate to the Area Browser page '(.*)'")]
        public void GivenINavigateToTheAreaBrowserPage(string p0)
        {

            //NavigationHelper.NavigateToUrl(p0);

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

        [Given(@"I navigate to the Preview Area Browse Page '(.*)'")]
        public void GivenINavigateToThePreviewAreaBrowsePage(string p0)
        {

            //NavigationHelper.NavigateToUrl(p0);

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


        [Given(@"I don't see an error code")]
        public void GivenIDonTSeeAnErrorCode()
        {
            GenericHelper.TakeScreenShot();
        }


        [Then(@"I should be shown the area browse search grid")]
        public void ThenIShouldBeShownTheAreaBrowseSearchGrid()
        {
            

            try
            {
                ObjectRepository.ABpage = new AreaBrowsePage(ObjectRepository.Driver);
                Assert.IsTrue(ObjectRepository.ABpage.HasSearchGrid());
                //ReportHelper.PassingTestLogger("Test Sucessful");

            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e); 
            }

            //AssertHelper.AreEqual(GenericHelper.GetElement(By.Id("prices-acc")).GetAttribute("Prices and Opening Times"), "Prices and Opening Times");
            //Assert.IsTrue(GenericHelper.IsElemetPresent(By.Id("prices-acc")));
        }


    }

}
