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
using LnP.BaseClasses;
using LnP.ComponentHelper;
using LnP.Settings;

namespace LnP.StepDefination_CVB
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
                Thread.Sleep(5000);
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

        [Then(@"I should See the Home Link in BreadCrumb")]
        public void ThenIShouldSeeTheHomeLinkInBreadCrumb()
        {
            try
            {

                Thread.Sleep(5000);
                Assert.IsTrue(GenericHelper.GetElement(By.XPath(".//*[@id='content']/div/div[1]/a")).Text.Contains("Home"));


            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                Assert.Fail("Exception" + e);
            }
        }

        [When(@"I Click on The Home Page Link")]
        public void WhenIClickOnTheHomePageLink()
        {
            try
            {

                
                ButtonHelper.ClickButton(By.XPath(".//*[@id='content']/div/div[1]/a"));
                Thread.Sleep(5000);


            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                Assert.Fail("Exception" + e);
            }
        }

        [Then(@"I Should Be Navigated To The Home Page")]
        public void ThenIShouldBeNavigatedToTheHomePage()
        {
            try
            {

                
                Assert.IsTrue(GenericHelper.GetElement(By.XPath(".//*[@id='content']/div[1]/div/div/h1")).Text.Contains("Welcome to London"));


            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                Assert.Fail("Exception" + e);
            }
        }

        [Then(@"I Should See The Full BreadCrumb Link")]
        public void ThenIShouldSeeTheFullBreadCrumbLink()
        {
            try
            {

                
                Assert.IsTrue(GenericHelper.GetElement(By.XPath(".//*[@id='content']/div/div[1]/span[1]")).Text.Contains("You are here"));


            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                Assert.Fail("Exception" + e);
            }

            try
            {

                
                Assert.IsTrue(GenericHelper.GetElement(By.XPath(".//*[@id='content']/div/div[1]/a")).Text.Contains("Home"));


            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                Assert.Fail("Exception" + e);
            }

            try
            {

                
                Assert.IsTrue(GenericHelper.GetElement(By.XPath(".//*[@id='content']/div/div[1]/mark")).Text.Contains("Search results"));


            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                Assert.Fail("Exception" + e);
            }
        }

        [When(@"I Enter '(.*)' in Min Field")]
        public void WhenIEnterInMinField(string p0)
        {
            try
            {
                TextBoxHelper.ClearTextBox(By.XPath(".//*[@id='total-space-min']"));
                TextBoxHelper.TypeInTextBox(By.XPath(".//*[@id='total-space-min']"), p0);
                Thread.Sleep(5000);
            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                Assert.Fail("Exception" + e);
                throw;
            }
        }


        [When(@"I Enter '(.*)' in Max Field")]
        public void WhenIEnterInMaxField(string p0)
        {
            try
            {
                TextBoxHelper.ClearTextBox(By.XPath(".//*[@id='total-space-max']"));
                TextBoxHelper.TypeInTextBox(By.XPath(".//*[@id='total-space-max']"), p0);
                Thread.Sleep(5000);
            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                Assert.Fail("Exception" + e);
                throw;
            }
        }

        [When(@"I Click Search Button")]
        public void WhenIClickSearchButton()
        {
            try
            {
                ButtonHelper.ClickButton(By.XPath(".//*[@class='course-search-submit']"));
                Thread.Sleep(5000);

            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                Assert.Fail("Exception" + e);
                throw;
            }
        }

        [Then(@"i Should See '(.*)' and '(.*)' in Search Reuslt")]
        public void ThenIShouldSeeAndInSearchReuslt(string p0, string p1)
        {
            try
            {
                Thread.Sleep(5000);
                JavaScriptExecutor.ScrollToView(By.XPath(".//*[@id='list']/ul/li[9]/div/h3/a"));
                Assert.IsTrue(GenericHelper.GetElement(By.XPath(".//*[@id='list']/ul/li[9]/div/h3/a")).Text.Contains(p0));
      
            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                Assert.Fail("Exception" + e);
                throw;
            }

            try
            {
                Thread.Sleep(5000);
                JavaScriptExecutor.ScrollToView(By.XPath(".//*[@id='list']/ul/li[18]/div/h3/a"));
                Assert.IsTrue(GenericHelper.GetElement(By.XPath(".//*[@id='list']/ul/li[18]/div/h3/a")).Text.Contains(p1));
            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                Assert.Fail("Exception" + e);
                throw;
            }
        }

        [When(@"I Click on Next Pagination Button")]
        public void WhenIClickOnNextPaginationButton()
        {
            try
            {
                Thread.Sleep(5000);
                JavaScriptExecutor.ScrollToView(By.XPath(".//*[@id='content']/div/div[2]/div/div[2]"));
                ButtonHelper.ClickButton(By.XPath(".//*[@class='course-search-submit']"));
                Thread.Sleep(5000);

            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                Assert.Fail("Exception" + e);
                throw;
            }
        }

        [Then(@"I Should See '(.*)' in Search Results")]
        public void ThenIShouldSeeInSearchResults(string p0)
        {
            try
            {
                Thread.Sleep(5000);
                JavaScriptExecutor.ScrollToView(By.XPath(".//*[@id='list']/ul/li[3]/div/h3/a"));
                Assert.IsTrue(GenericHelper.GetElement(By.XPath(".//*[@id='list']/ul/li[3]/div/h3/a")).Text.Contains(p0));
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
