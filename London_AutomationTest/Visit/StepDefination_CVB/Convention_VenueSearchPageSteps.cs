using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Visit.BaseClasses;
using Visit.ComponentHelper;
using Visit.Settings;

namespace Visit.StepDefination_CVB
{
    [Binding]
    public class VenueSearchPageSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext context;
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(BaseClass));

        public VenueSearchPageSteps(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }

        [Given(@"I Navigate To The Search Venue Page '(.*)'")]
        public void GivenINavigateToTheSearchVenuePage(string p0)
        {
            try
            {
                NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetConventionWebsite() + p0);
            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                //throw;
            }
        }

        [Then(@"I Should See Venue Search Results")]
        public void ThenIShouldSeeVenueSearchResults()
        {
            try
            {

                Thread.Sleep(5000);
                Assert.IsTrue(GenericHelper.GetElement(By.XPath(".//*[@id='venueSearch']/div/div[1]/div[1]")).Text.Contains("Delegates"));


            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                Assert.Fail("Exception" + e);
            }
        }




    }
}
