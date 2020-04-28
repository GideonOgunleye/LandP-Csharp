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
using LnP.Settings;

namespace LnP.StepDefinition
{
    [Binding]
    public class LondonTubePageSteps
    {
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(BaseClass));
        //private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        [Given(@"I navigate to the London tube page  '(.*)'")]
        public void GivenINavigateToTheLondonTubePage(string p0)
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

        [Given(@"I navigate to the Preview London tube page  '(.*)'")]
        public void GivenINavigateToThePreviewLondonTubePage(string p0)
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


        [Then(@"I should be shown the  '(.*)' Title")]
        public void ThenIShouldBeShownTheTitle(string p0)
        {
            try
            {
                ObjectRepository.LTpage = new PageObject.LondonTubePage(ObjectRepository.Driver);
                Assert.IsTrue(p0.Equals(ObjectRepository.LTpage.title()));
            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                //throw;
            }
        }



    }
}
