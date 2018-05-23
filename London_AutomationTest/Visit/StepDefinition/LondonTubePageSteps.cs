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
using Visit.Settings;

namespace Visit.StepDefinition
{
    [Binding]
    public class LondonTubePageSteps
    {
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(BaseClass));

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
