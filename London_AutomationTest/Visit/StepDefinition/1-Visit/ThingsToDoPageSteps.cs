using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using TechTalk.SpecFlow;
using Visit.BaseClasses;
using Visit.ComponentHelper;
using Visit.PageObject;
using Visit.Settings;

namespace Visit.StepDefinition
{
    [Binding]
    public class ThingsToDoPageSteps
    {
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(BaseClass));
        //private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        [Given(@"I navigate to the thing to do hub page '(.*)'")]
        public void GivenINavigateToTheThingToDoHubPage(string p0)
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

        [Given(@"I navigate to the Preview thing to do hub page '(.*)'")]
        public void GivenINavigateToThePreviewThingToDoHubPage(string p0)
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

        [Then(@"I should be shown the title")]
        public void ThenIShouldBeShownTheTitle()
        {
            try
            {
                ObjectRepository.TTDpage = new ThingsToDoPage(ObjectRepository.Driver);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ObjectRepository.TTDpage.title()));
            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                //throw;
            }
        }

        [Then(@"I should be shown the intro copy")]
        public void ThenIShouldBeShownTheIntroCopy()
        {
            try
            {
                
                Assert.IsFalse(string.IsNullOrEmpty(ObjectRepository.TTDpage.Copy()));
            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                //throw;
            }
        }


    }
}
