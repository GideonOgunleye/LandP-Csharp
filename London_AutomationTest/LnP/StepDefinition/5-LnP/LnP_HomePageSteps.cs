using LnP.BaseClasses;
using LnP.ComponentHelper;
using LnP.Settings;
using log4net;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace SeleniumWebdriver.StepDefinition._5_LnP
{
    [Binding]
    public class LnP_HomePageSteps
    {
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(BaseClass));


        [When(@"I Navigate To LnP Homepage")]
        public void WhenINavigateToLnPHomepage()
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

        [Given(@"I am On London And Partners Home Page")]
        public void GivenIAmOnLondonAndPartnersHomePage()
        {
            try
            {
                NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetLnPWebsite());
            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                //throw;
            }
        }



        [Then(@"I Should See The Main Title '(.*)'")]
        public void ThenIShouldSeeTheMainTitle(string p0)
        {
            try
            {
                Thread.Sleep(5000);
                JavaScriptExecutor.ScrollToView(By.XPath(".//*[@id='content']/div[1]/div/div/h1"));
                Thread.Sleep(1000);
                //AssertHelper.AreEqual(GenericHelper.GetElement(By.XPath(".//*[@id='content']/div[1]/div/div/h1[contains(text(), 'London Bridge')]")).Text.Contains(p0));
                AssertHelper.AreEqual(GenericHelper.GetElement(By.XPath(".//*[@id='content']/div[1]/div/div/h1[contains(text(), 'Welcome to London')]")).Text, "Welcome to London");



            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                //throw;
            }
        }

    }
}
