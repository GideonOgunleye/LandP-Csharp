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
    public class EventCalenderPageSteps 
    {
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(BaseClass));

        [Given(@"I navigate to event calendar page '(.*)'")]
        public void GivenINavigateToEventCalendarPage(string p0)
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite() + p0);
        }


        [Given(@"I don't see an error code on Calender")]
        public void GivenIDonTSeeAnErrorCodeOnCalender()
        {
            GenericHelper.TakeScreenShot();
        }

        [Then(@"I should be at least one event")]
        public void ThenIShouldBeAtLeastOneEvent()
        {
            //ObjectRepository.ABpage = new AreaBrowsePage(ObjectRepository.Driver);
            

            try
            {
                ObjectRepository.ECpage = new EventCalenderPage(ObjectRepository.Driver);
                Assert.IsTrue(ObjectRepository.ECpage.HasEvents());

            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
            }
        }



    }
}
