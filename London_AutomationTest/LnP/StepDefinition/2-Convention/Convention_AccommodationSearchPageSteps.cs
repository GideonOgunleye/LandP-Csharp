using LnP.BaseClasses;
using LnP.ComponentHelper;
using LnP.Settings;
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

namespace SeleniumWebdriver.StepDefinition._2_Convention
{
    [Binding]
    public class Convention_AccommodationSearchPageSteps
    {
        private readonly ScenarioContext context;
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(BaseClass));

        public Convention_AccommodationSearchPageSteps(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }

        [Given(@"I Navigate to Accommodation Search Page '(.*)'")]
        public void GivenINavigateToAccommodationSearchPage(string p0)
        {
            try
            {
                NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetConventionWebsite() + p0);
                Thread.Sleep(5000);
            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                //throw;
            }
        }

        [Given(@"I Navigate to Preview Accommodation Search Page '(.*)'")]
        public void GivenINavigateToPreviewAccommodationSearchPage(string p0)
        {
            try
            {
                NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetConventionPreviewWebsite() + p0);
                Thread.Sleep(5000);
            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                //throw;
            }
        }


        [Then(@"I Should See Search Results")]
        public void ThenIShouldSeeSearchResults()
        {
            try
            {

                Thread.Sleep(5000);
                JavaScriptExecutor.ScrollToView(By.XPath(".//*[@id='list']/ul/li[3]/div/h3/a"));
                Thread.Sleep(5000);
                Assert.IsTrue(GenericHelper.GetElement(By.XPath(".//*[@id='list']/ul/li[3]/div/h3/a")).Text.Contains("AMBA Hotel Charing Cross"));

            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                Assert.Fail("Exception" + e);
            }
        }

        [Then(@"I Should See '(.*)' Search Results")]
        public void ThenIShouldSeeSearchResults(string p0)
        {
            try
            {

                string keyword = p0;

                switch (keyword)
                {
                    case "Qa":

                        Thread.Sleep(5000);
                        JavaScriptExecutor.ScrollToView(By.XPath(".//*[@id='list']/ul/li[2]/div/h3/a"));
                        Thread.Sleep(5000);
                        Assert.IsTrue(GenericHelper.GetElement(By.XPath(".//*[@id='list']/ul/li[2]/div/h3/a")).Text.Contains("Aloft London Excel"));
                        break;
                    case "Preview":
                        Thread.Sleep(5000);
                        JavaScriptExecutor.ScrollToView(By.XPath(".//*[@id='list']/ul/li[1]/div/h3/a"));
                        Thread.Sleep(5000);
                        Assert.IsTrue(GenericHelper.GetElement(By.XPath(".//*[@id='list']/ul/li[1]/div/h3/a")).Text.Contains("100 Queen's Gate Hotel"));
                        break;
                
                    default:
                        Console.WriteLine("No Matching Text Found");
                        break;
                }

            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                Assert.Fail("Exception" + e);
                throw;
            }
        }






    }
}
