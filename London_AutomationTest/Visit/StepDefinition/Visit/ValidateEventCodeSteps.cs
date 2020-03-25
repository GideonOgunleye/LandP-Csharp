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
using Visit.Settings;

namespace Visit.StepDefinition
{
    [Binding]
    public sealed class ValidateEventCodeSteps
    {
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(BaseClass));

        [Given(@"I Navigate To Url of Expired Event '(.*)'")]
        public void GivenINavigateToUrlOfExpiredEvent(string p0)
        {

            try
            {
                NavigationHelper.NavigateToUrl(p0);
                Thread.Sleep(1000);

                
            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                Assert.Fail("Exception" + e);
                throw;
            }
        }

        /*[Then(@"Event Should Return Status Code '(.*)'")]
        public void ThenEventShouldReturnStatusCode(int p0)
        {
            ScenarioContext.Current.Pending();
        }*/


        [Then(@"Event Page '(.*)' Should Contain Text ""(.*)""")]
        public void ThenEventPageShouldContainText(string p0, string p1)
        {
            try
            {

                string url = p0; 

                switch (url)
                {
                    case "Less Than 12 Months":

                        Assert.IsTrue(GenericHelper.GetElement(By.XPath(".//*[@class='cf expired']/strong")).Text.Contains(p1));
                        break;
                    case "Greater Than 12 Months":

                        Assert.IsTrue(GenericHelper.GetElement(By.XPath(".//*[@class='cf tint']/h3")).Text.Contains(p1));
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
