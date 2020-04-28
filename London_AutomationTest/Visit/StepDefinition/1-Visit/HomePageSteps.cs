using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LnP.ComponentHelper;
using TechTalk.SpecFlow;
using log4net;
using LnP.BaseClasses;
using LnP.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LnP.PageObject;
using NLog;

namespace LnP.StepDefinition
{
    [Binding]
    public class HomePageSteps
    {
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(BaseClass));
        //private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        [Given(@"I visit the Homepage")]
        public void GivenIVisitTheHomepage()
        {
            try
            {
                NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                //throw;
            }

        }

        [Given(@"I Navigate To PreviewHomePage")]
        public void INavigateToPreviewHomePage()
        {
            try
            {
                NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetPreviewWebsite());
            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                //throw;
            }

        }

        [Then(@"I should be shown the main title '(.*)'")]
        public void ThenIShouldBeShownTheMainTitle(string p0)
        {
            

            try
            {
                ObjectRepository.Hpage = new HomePage(ObjectRepository.Driver);
                Assert.IsTrue(ObjectRepository.Hpage.HTitle().Contains(p0));
                //GenericHelper.TakeScreenShot();
                //GenericHelper.TakeScreenShot2("Screen");
                GetScreenShot.Capture(ObjectRepository.Driver, "Screen");
            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                //throw;
            }
        }

    }
}
