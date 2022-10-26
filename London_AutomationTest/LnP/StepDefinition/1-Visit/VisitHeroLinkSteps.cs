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

namespace SeleniumWebdriver.StepDefinition._1_Visit
{
    [Binding]
    public sealed class VisitHeroLinkSteps
    {
        //private AreaBrowsePage ABpage;
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(BaseClass));
        //private static readonly Logger Logger = LogManager.GetCurrentClassLogger();


        [Given(@"I Navigate To Visit Home Page")]
        public void GivenINavigateToVisitHomePage()
        {
            try
            {
                NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
                Thread.Sleep(20000);
            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                //throw;
            };
        }

        [Then(@"I Should See Hero Links Displayed On Page")]
        public void ThenIShouldSeeHeroLinksDisplayedOnPage()
        {
            Thread.Sleep(5000);
            JavaScriptExecutor.ScrollToView(By.XPath(".//*[@id='content']/div[1]/div/div/ul"));
            Thread.Sleep(2000);
            Assert.IsTrue(GenericHelper.GetElement(By.XPath(".//*[@id='content']/div[1]/div/div/ul")).Displayed);
        }


    }
}
