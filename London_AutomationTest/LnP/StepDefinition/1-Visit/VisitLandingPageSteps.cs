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
using LnP.Settings;

namespace LnP.StepDefinition
{
    [Binding]
    public sealed class VisitLandingPageSteps
    {
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(BaseClass));

        [When(@"Product is Checked In")]
        public void WhenProductIsCheckedIn()
        {
            //Search For Product
            try
            {
                //Type in Search Box
                Thread.Sleep(3000);
                TextBoxHelper.TypeInTextBox(By.XPath(".//*[@id='TreeSearch']"), "test-landing-page");
                //Click on Search Button
                Thread.Sleep(5000);
                ButtonHelper.ClickButton(By.XPath(".//*[@id='SearchPanel']/table[1]/tbody/tr/td[2]/div/div/a"));
                //Click on Product
                Thread.Sleep(5000);
                ButtonHelper.ClickButton(By.XPath(".//*[@id='SearchResult']/table/tbody/tr[1]/td[2]/a[4]"));
                Thread.Sleep(5000);

            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                Assert.Fail("Exception" + e);
                throw;
            }

            //Check if Product Is Not Checked In
            if (GenericHelper.GetElement(By.XPath(".//*[@id='EditorPanel7868EA52BEB84600A1F56F8C6C3B6571']/div[2]/div[2]/div[1]")).Text.Contains("If you publish now, the selected version will not be visible on the Web site because it has been replaced by an older version."))
            {
                try
                {
                    //Click on Navigation Pane
                    ButtonHelper.ClickButton(By.XPath(".//*[@id='Ribbon7868EA52BEB84600A1F56F8C6C3B6571_Nav_ReviewStrip']"));
                    Thread.Sleep(1000);
                    //Click on Check In
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
            else
            {
                Console.WriteLine("Product Not In Check In Mode");
            }
        }


        [Then(@"I Should Be Able To Preview Visit Landing Page '(.*)'")]
        public void ThenIShouldBeAbleToPreviewVisitLandingPage(string url)
        {
            NavigationHelper.NavigateToUrl(url);
            Thread.Sleep(1000);
        }

        [When(@"I Click on Toggle Ribbon")]
        public void WhenIClickOnToggleRibbon()
        {
            Thread.Sleep(5000);
            ObjectRepository.Driver.SwitchTo().Frame("scWebEditRibbon");
            Thread.Sleep(1000);
            ButtonHelper.ClickButton(By.XPath(".//*[@class='container-narrow']/div[1]/nav/a[4]"));
        }

        [Then(@"I Should Be Able To Edit The Page")]
        public void ThenIShouldBeAbleToEditThePage()
        {

            /*  Thread.Sleep(5000);
              ButtonHelper.ClickButton(By.XPath(".//*[@class='sc-messageBar-head alert']/div[2]/span[2]/i"));
              Thread.Sleep(5000);
              ButtonHelper.ClickButton(By.XPath(".//*[@class='sc-messageBar-messages-wrap data-sc-registered sc-messageBar-messages-nested-children']/div[2]/div[1]/div[2]/span/a"));
              Thread.Sleep(5000);
            */

            //Try to check in if page is in page if already in Edit Mode

            

            

            try
            {
                Thread.Sleep(3000);
                ButtonHelper.ClickButton(By.XPath(".//*[@class='sc-messageBar-head alert']/div[2]/span[2]/i"));
                Thread.Sleep(5000);
                ButtonHelper.ClickButton(By.XPath(".//*[@class='sc-messageBar-messages-wrap data-sc-registered sc-messageBar-messages-nested-children']/div[2]/div[1]/div[2]/span/a"));
                Thread.Sleep(5000);

            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                Console.WriteLine("Error Returned" + e);
                //Assert.Fail("Exception" + e);
                //throw;
            }

            /*   try
               {
                   //ObjectRepository.Driver.SwitchTo().Frame("scWebEditRibbon");
                   Thread.Sleep(3000);
                   ButtonHelper.ClickButton(By.XPath(".//*[@class='sc-messageBar-head alert']/div[2]/span[2]/a"));

               }
               catch (Exception e)
               {
                   Logger.Error("Exception: " + e);
                   Assert.Fail("Exception" + e);
                   throw;
               }
            */

        }

        [Then(@"Insert Component on Page")]
        public void ThenInsertComponentOnPage()
        {

            

            try
            {
                ButtonHelper.ClickButton(By.XPath(".//*[@class='container-narrow']/div[1]/nav[1]/a[3]"));
                Thread.Sleep(5000);
                //JavaScriptExecutor.ScrollToView(By.XPath(".//*[@class='cf intro-block']"));
                JavaScriptExecutor.ScrollTo(0, 5000);
                Thread.Sleep(1000);
                //ButtonHelper.ClickButton(By.XPath(".//*[@class='sticky-nav-init']/div[30]/div[2]/span"));
                ButtonHelper.ClickButton(By.XPath(".//*[@class='sticky-nav-init']/div[29]/div[2]/span"));

            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                Console.WriteLine("Error Returned" + e);
                //Assert.Fail("Exception" + e);
                //throw;
            }

            /*    try
                {
                    //ObjectRepository.Driver.SwitchTo().Frame("scWebEditRibbon");
                    Thread.Sleep(3000);
                    ButtonHelper.ClickButton(By.XPath(".//*[@class='container-narrow']/div[1]/nav[1]/a[3]"));
                    Thread.Sleep(5000);

                }
                catch (Exception e)
                {
                    Logger.Error("Exception: " + e);
                    Assert.Fail("Exception" + e);
                    throw;
                }
            */
        }





    }
}
