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
                //ButtonHelper.ClickButton(By.XPath(".//*[@class='sc-accountInformation']/li[1]/span"));
                //Thread.Sleep(1000);

            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                Assert.Fail("Exception" + e);
                throw;
            }
        }

        [When(@"User Navigates to Venue CMS Url '(.*)'")]
        public void WhenUserNavigatesToVenueCMSUrl(string url)
        {
            NavigationHelper.NavigateToUrl(url);
            Thread.Sleep(1000);
        }

        [When(@"User Searches For Event '(.*)'")]
        public void WhenUserSearchesForEvent(string p0)
        {
            try
            {
                //NavigationHelper.NavigateToUrl(p0);
                TextBoxHelper.TypeInTextBox(By.XPath(".//*[@id='TreeSearch']"), p0);
                Thread.Sleep(5000);


            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                Assert.Fail("Exception" + e);
                throw;
            }

            // User Clicks on Search Button
            try
            {
                ButtonHelper.ClickButton(By.XPath(".//*[@id='SearchPanel']/table[1]/tbody/tr/td[2]/div/div/a"));
                Thread.Sleep(5000);


            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                Assert.Fail("Exception" + e);
                throw;
            }

            //User Clicks on Event
            try
            {
                //ButtonHelper.ClickButton(By.XPath(".//*[@id='SearchResult']/table/tbody/tr[1]/td[2]/a[2]"));
                ButtonHelper.ClickButton(By.XPath(".//*[@id='SearchResult']/table/tbody/tr[1]/td[2]/a"));
                Thread.Sleep(5000);


            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                Assert.Fail("Exception" + e);
                throw;
            }
        }

        [When(@"User Searches For Venue '(.*)'")]
        public void WhenUserSearchesForVenue(string p0)
        {
            try
            {
                //NavigationHelper.NavigateToUrl(p0);
                TextBoxHelper.TypeInTextBox(By.XPath(".//*[@id='TreeSearch']"), p0);
                Thread.Sleep(5000);


            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                Assert.Fail("Exception" + e);
                throw;
            }

            // User Clicks on Search Button
            try
            {
                ButtonHelper.ClickButton(By.XPath(".//*[@id='SearchPanel']/table[1]/tbody/tr/td[2]/div/div/a"));
                Thread.Sleep(5000);


            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                Assert.Fail("Exception" + e);
                throw;
            }

            //User Clicks on Venue
            try
            {
                //ButtonHelper.ClickButton(By.XPath(".//*[@id='SearchResult']/table/tbody/tr[1]/td[2]/a[2]"));
                ButtonHelper.ClickButton(By.XPath(".//*[@id='SearchResult']/table/tbody/tr[1]/td[2]/a"));
                Thread.Sleep(5000);


            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                Assert.Fail("Exception" + e);
                throw;
            }
        }


        [Then(@"User Should Be Able To Lock and Edit Venue")]
        public void ThenUserShouldBeAbleToLockAndEditVenue()
        {
            try
            {
                ButtonHelper.ClickButton(By.XPath(".//*[@id='EditorPanelA49449A5C1AF4DBD9E200BD17A202551']/div[2]/div[2]/ul/li/a"));
                Thread.Sleep(1000);
                //Assert.IsTrue(GenericHelper.GetElement(By.XPath("//*[@id='EditorPanelA49449A5C1AF4DBD9E200BD17A202551']/div[2]/div[2]/div[1]")).Text.Contains("If you publish now, the selected version will not be visible on the Web site because it has been replaced by an older version."));

            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                Assert.Fail("Exception" + e);
                throw;
            }
        }

        [Then(@"User Should Be Able To Lock and Edit Event")]
        public void ThenUserShouldBeAbleToLockAndEditEvent()
        {
            try
            {
                ButtonHelper.ClickButton(By.XPath(".//*[@id='EditorPanel41A042FA163349FABB04C0831883AF6F']/div[2]/div[2]/ul/li/a"));
                Thread.Sleep(1000);
                Assert.IsTrue(GenericHelper.GetElement(By.XPath("//*[@id='EditorPanel41A042FA163349FABB04C0831883AF6F']/div[2]/div[2]/div[1]")).Text.Contains("If you publish now, the selected version will not be visible on the Web site because it has been replaced by an older version."));

            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                Assert.Fail("Exception" + e);
                throw;
            }
        }


        [Then(@"User Should Be Able To Publish Event")]
        public void ThenUserShouldBeAbleToPublishEvent()
        {
            //Click Review Navigation Tab
            try
            {
                ButtonHelper.ClickButton(By.XPath(".//*[@id='Ribbon41A042FA163349FABB04C0831883AF6F_Nav_ReviewStrip']"));
                Thread.Sleep(1000);
            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                Assert.Fail("Exception" + e);
                throw;
            }
            //Click Publish 
            try
            {
                //ButtonHelper.ClickButton(By.XPath(".//*[@id='C22AEF88C58BC4BFD8F34299782312338']/div[1]/div[3]/a[2]/span"));
                //Thread.Sleep(5000);
                //JavaScriptPopHelper.ClickOkOnPopup();
                //ObjectRepository.Driver.SwitchTo().Frame("scContentIframeId0"); //*[@id="scContentIframeId0"]
                //ObjectRepository.Driver.SwitchTo().ParentFrame();
                //Console.WriteLine("Parent Frame is: " + ObjectRepository.Driver.SwitchTo().ParentFrame());
                //ObjectRepository.Driver.SwitchTo().Frame(ObjectRepository.Driver.FindElement(By.XPath(".//*[@class='ui-dialog ui-widget ui-widget-content ui-corner-all ui-front ui-draggable ui-resizable']/iframe")));
                ButtonHelper.ClickButton(By.XPath(".//*[@id='C22AEF88C58BC4BFD8F34299782312338']/div[1]/div[2]/a[1]"));
                Thread.Sleep(1000);
            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                Assert.Fail("Exception" + e);
                throw;
            }
        }

        [Then(@"User Should Be Able To Check In Venue")]
        public void ThenUserShouldBeAbleToCheckInVenue()
        {
            //Click Review Navigation Tab
            try
            {
                ButtonHelper.ClickButton(By.XPath(".//*[@id='RibbonA49449A5C1AF4DBD9E200BD17A202551_Nav_ReviewStrip']"));
                Thread.Sleep(1000);
            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                Assert.Fail("Exception" + e);
                throw;
            }
            //Click Publish 
            try
            {
                ButtonHelper.ClickButton(By.XPath(".//*[@id='C22AEF88C58BC4BFD8F34299782312338']/div[1]/div[2]/a[1]"));
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
