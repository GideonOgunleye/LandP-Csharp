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

        [Then(@"I should be shown the tag browse search grid")]
        public void ThenIShouldBeShownTheTagBrowseSearchGrid()
        {

            try
            {
                ObjectRepository.TBpage = new TagBrowsePage(ObjectRepository.Driver);
                Assert.IsTrue(ObjectRepository.TBpage.HasSearchGrid());
            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                //throw;
            }

        }


    }
}
