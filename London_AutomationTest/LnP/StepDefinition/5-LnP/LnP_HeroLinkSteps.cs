using LnP.BaseClasses;
using LnP.ComponentHelper;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public sealed class LnP_Hero_Link_Steps
    {
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(BaseClass));

        [Then(@"I Should See Hero Links Displayed On LnP Home Page")]
        public void ThenIShouldSeeHeroLinksDisplayedOnLnPHomePage()
        {
            Thread.Sleep(5000);
            JavaScriptExecutor.ScrollToView(By.XPath(".//*[@id='content']/div[1]/div/div/ul"));
            Thread.Sleep(2000);
            Assert.IsTrue(GenericHelper.GetElement(By.XPath(".//*[@id='content']/div[1]/div/div/ul")).Displayed);
        }


    }
}
