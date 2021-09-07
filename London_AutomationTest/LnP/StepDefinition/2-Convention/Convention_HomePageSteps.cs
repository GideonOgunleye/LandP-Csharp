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
using TechTalk.SpecFlow;

namespace SeleniumWebdriver.StepDefinition._2_Convention
{
    [Binding]
    public class Convention_HomePageSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext context;
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(BaseClass));

        public Convention_HomePageSteps(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }

        [Given(@"I Navigate To The Home Page '(.*)'")]
        public void GivenINavigateToTheHomePage(string p0)
        {
            try
            {
                NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetConventionWebsite() + p0);
                Thread.Sleep(5000);
            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                Assert.Fail("Exception" + e);
                throw;
            }
        }

        [Then(@"I Should Be Shown The Main Title '(.*)'")]
        public void ThenIShouldBeShownTheMainTitle(string p0)
        {
            try
            {
                Thread.Sleep(5000);
                JavaScriptExecutor.ScrollToView(By.XPath(".//*[@id='content']/div[1]/div/div/h1"));
                Thread.Sleep(1000);
                //AssertHelper.AreEqual(GenericHelper.GetElement(By.XPath(".//*[@id='content']/div[1]/div/div/h1[contains(text(), 'London Bridge')]")).Text.Contains(p0));
                AssertHelper.AreEqual(GenericHelper.GetElement(By.XPath(".//*[@id='content']/div[1]/div/div/h1[contains(text(), 'Welcome to London')]")).Text, "Welcome to London");
                //AssertHelper.AreEqual(GenericHelper.GetElement(By.XPath(".//*[@id='content']/div/h1[contains(text(), 'London Bridge')]")).Text, "Tower Bridge");
                //Assert.IsTrue(GenericHelper.GetElement(By.XPath(".//*[@id='content']/div[1]/div/div/h1")).Text.Contains(p0));
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
