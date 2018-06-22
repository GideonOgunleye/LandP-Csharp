using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using Visit.BaseClasses;
using Visit.ComponentHelper;

namespace Visit.StepDefinition
{
    [Binding]
    public sealed class PageRedirectSteps
    {
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(BaseClass));

        [Given(@"User Enters Url '(.*)'")]
        public void GivenUserEntersUrl(string p0)
        {
            try
            {
                NavigationHelper.NavigateToUrl(p0);
                Thread.Sleep(5000);


            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                Assert.Fail("Exception" + e);
                throw;
            }
        }

        [Then(@"User should be navigated to the ""(.*)"" Page and See Text ""(.*)"" On Page")]
        public void ThenUserShouldBeNavigatedToThePageAndSeeTextOnPage(string p0, string p1)
        {
            try
            {

                string url = p0;

                switch (url)
                {
                    case "Whats On":

                        Assert.IsTrue(GenericHelper.GetElement(By.XPath(".//*[@class='cf']/h1")).Text.Contains(p1));
                        break;
                    case "About Us":

                        Assert.IsTrue(GenericHelper.GetElement(By.XPath(".//*[@class='cf']/h1")).Text.Contains(p1));
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
