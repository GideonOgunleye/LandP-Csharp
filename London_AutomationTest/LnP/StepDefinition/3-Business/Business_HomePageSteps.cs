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

namespace SeleniumWebdriver.StepDefinition._3_Business
{
    [Binding]
    public class Business_HomePageSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext context;
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(BaseClass));

        public Business_HomePageSteps(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }

        [Given(@"I Am On Business Landing Page")]
        public void GivenIAmOnBusinessLandingPage()
        {
            try
            {
                NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetBusinessWebsite());
                Thread.Sleep(10000);
            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                Assert.Fail("Exception" + e);
                throw;
            }
        }


        [Then(@"the Should See '(.*)' Page Title")]
        public void ThenTheShouldSeePageTitle(string p0)
        {
            try
            {
                Thread.Sleep(5000);
                JavaScriptExecutor.ScrollToView(By.XPath(".//*[@id='content']/div[1]/div/div/h1"));
                Assert.IsTrue(GenericHelper.GetElement(By.XPath(".//*[@id='content']/div[1]/div/div/h1")).Text.Contains(p0));
            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                Assert.Fail("Exception" + e);
                throw;
            }
        }

        [Then(@"I Should See Feature Call Out Component")]
        public void ThenIShouldSeeFeatureCallOutComponent()
        {
            
            try
               // Boolean ImagePresent = (Boolean)((JavaScriptExecutor)driver).executeScript();
            {
                Thread.Sleep(5000);
                JavaScriptExecutor.ScrollToView(By.XPath(".//*[@id='content']/div[2]/div[1]/div[2]/div/div[1]"));
                Assert.IsTrue(GenericHelper.GetElement(By.XPath(".//*[@id='content']/div[2]/div[1]/div[2]/div/div[1]/div[1]")).Displayed);

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
