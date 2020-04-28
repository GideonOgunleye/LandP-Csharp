using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using LnP.BaseClasses;
using LnP.ComponentHelper;
using LnP.Settings;

namespace LnP.StepDefinition
{
   

    [Binding]
    public class SitecoreValidLoginSteps
    {
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(BaseClass));

        [Given(@"User is On CMS Login Page '(.*)'")]
        public void GivenUserIsOnCMSLoginPage(string url)
        {
            NavigationHelper.NavigateToUrl(url);
            Thread.Sleep(1000);
        }


        [When(@"User Enters Valid Credebtials")]
        public void WhenUserEntersValidCredebtials(Table table)
        {

            try
            {
                foreach (var row in table.Rows)
                {
                    TextBoxHelper.TypeInTextBox(By.Id("UserName"), row["Username"]);
                    TextBoxHelper.TypeInTextBox(By.Id("Password"), row["Password"]);
                }
            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                Assert.Fail("Exception" + e);
                throw;
            }
        }


        [When(@"Clicks Login Button")]
        public void WhenClicksLoginButton()
        {
            //.//*[@id='Tree_Node_B19728F2E3EB46B3AE78A61C084384DF']/span[contains(text(), 'Chinese-New-Year')]

            try
            {
                ButtonHelper.ClickButton(By.XPath("//input[@id='LogInBtn']"));
                
            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                Assert.Fail("Exception" + e);
                throw;
            }
        }

        [Then(@"Sitecore Experience Platform Page Should Be Displayed")]
        public void ThenSitecoreExperiencePlatformPageShouldBeDisplayed()
        {
            
            Thread.Sleep(5000);

            try
            {
                
                AssertHelper.AreEqual(GenericHelper.GetElement(By.XPath(".//*[@class='sc-launchpad-item']/span[contains(text(), 'Content Editor')]")).Text, "Content Editor");

            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                Assert.Fail("Exception" + e);
                throw;
            }
        }

        [When(@"User Clicks on Content Editor Tab")]
        public void WhenUserClicksOnContentEditorTab()
        {

            try
            {
                ButtonHelper.ClickButton(By.XPath(".//*[@class='sc-launchpad-item']/span[contains(text(), 'Content Editor')]"));
                Thread.Sleep(5000);
            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                Assert.Fail("Exception" + e);
                throw;
            }
        }

        [Then(@"Content Editor Page Should Be Displayed")]
        public void ThenContentEditorPageShouldBeDisplayed()
        {
            try
            {
                AssertHelper.AreEqual(GenericHelper.GetElement(By.XPath(".//*[@class='scEditorHeaderTitlePanel']/a[contains(text(), 'Home')]")).Text, "Home");
                GenericHelper.TakeScreenShot();
                ButtonHelper.ClickButton(By.XPath(".//*[@class='sc-accountInformation']/li[1]/span"));
                Thread.Sleep(1000);

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
