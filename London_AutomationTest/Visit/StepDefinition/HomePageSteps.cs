using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visit.ComponentHelper;
using TechTalk.SpecFlow;
using log4net;
using Visit.BaseClasses;
using Visit.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Visit.PageObject;
using NLog;

namespace Visit.StepDefinition
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
