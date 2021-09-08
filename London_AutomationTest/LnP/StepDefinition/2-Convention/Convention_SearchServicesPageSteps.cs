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
    public class Convention_SearchServicesPageSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext context;
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(BaseClass));

        public Convention_SearchServicesPageSteps(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }

        [Given(@"I Navigate To Search Services Page'(.*)'")]
        public void GivenINavigateToSearchServicesPage(string p0)
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

        [Given(@"I Navigate To Preview Search Services Page '(.*)'")]
        public void GivenINavigateToPreviewSearchServicesPage(string p0)
        {
            try
            {
                NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetConventionPreviewWebsite() + p0);
                Thread.Sleep(5000);
            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                Assert.Fail("Exception" + e);
                throw;
            }
        }


        [Then(@"I Should See Search Services Page Results")]
        public void ThenIShouldSeeSearchServicesPageResults()
        {
            
        }

        [Then(@"I Should See '(.*)' Search Services Page Results")]
        public void ThenIShouldSeeSearchServicesPageResults(string p0)
        {
            try
            {

                string keyword = p0;

                switch (keyword)
                {
                    case "Qa":

                        Thread.Sleep(5000);
                        JavaScriptExecutor.ScrollToView(By.XPath(".//*[@id='list']/ul/li[5]/div/h3/a"));
                        Thread.Sleep(5000);
                        Assert.IsTrue(GenericHelper.GetElement(By.XPath(".//*[@id='list']/ul/li[5]/div/h3/a")).Text.Contains("Alicia DMR Service 1"));
                        break;
                    case "Preview":
                        Thread.Sleep(5000);
                        JavaScriptExecutor.ScrollToView(By.XPath(".//*[@id='list']/ul/li[7]/div/h3/a"));
                        Thread.Sleep(5000);
                        //Assert.IsTrue(GenericHelper.GetElement(By.XPath(".///*[@id='list']/ul/li[7]/div/h3/a")).Text.Contains("100 Queen's Gate Hotel"));

                        if (GenericHelper.GetElement(By.XPath(".//*[@id='list']/ul/li[7]/div/h3/a")).Text.Contains("100 Queen's Gate Hotel"))
                        {
                            Assert.IsTrue(GenericHelper.GetElement(By.XPath(".//*[@id='list']/ul/li[7]/div/h3/a")).Text.Contains("100 Queen's Gate Hotel"));

                        }else if (GenericHelper.GetElement(By.XPath(".//*[@id='list']/ul/li[7]/div/h3/a")).Text.Contains("Ben Thompson Events Ltd"))
                        {
                            Assert.IsTrue(GenericHelper.GetElement(By.XPath(".//*[@id='list']/ul/li[7]/div/h3/a")).Text.Contains("Ben Thompson Events Ltd"));
                        }
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
