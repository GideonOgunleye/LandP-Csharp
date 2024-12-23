﻿using LnP.BaseClasses;
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
    public sealed class Convention_HeroLinkSteps
    {
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(BaseClass));

        [Given(@"I Navigate To Convention Home Page")]
        public void GivenINavigateToConventionHomePage()
        {
            try
            {
                NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetConventionWebsite());
                Thread.Sleep(20000);
            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                Assert.Fail("Exception" + e);
                throw;
            }
        }

        [Then(@"I Should See Hero Links Displayed On Convention Bureau Home Page")]
        public void ThenIShouldSeeHeroLinksDisplayedOnConventionBureauHomePage()
        {
            Thread.Sleep(5000);
            JavaScriptExecutor.ScrollToView(By.XPath(".//*[@id='content']/div[1]/div/div/ul"));
            Thread.Sleep(2000);
            Assert.IsTrue(GenericHelper.GetElement(By.XPath(".//*[@id='content']/div[1]/div/div/ul")).Displayed);
        }


    }
}
