using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using LnP.BaseClasses;
using LnP.ComponentHelper;

namespace LnP.StepDefinition
{
    [Binding]
    public sealed class KeywordSearchSteps
    {
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(BaseClass));

        [Given(@"User is on Home Page '(.*)'")]
        public void GivenUserIsOnHomePage(string p0)
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

        [When(@"I Enter '(.*)' Keyword")]
        public void WhenIEnterKeyword(string p0)
        {
            try
            {
                //NavigationHelper.NavigateToUrl(p0);
                TextBoxHelper.TypeInTextBox(By.XPath(".//*[@class='header-search cf']/input"), p0);
                Thread.Sleep(5000);


            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                Assert.Fail("Exception" + e);
                throw;
            }
        }

        [When(@"I Hit The Search Button")]
        public void WhenIHitTheSearchButton()
        {
            try
            {
                ButtonHelper.ClickButton(By.XPath(".//*[@class='close-overlay-3 TT-feedback-popup-close']"));
                Thread.Sleep(5000);


            }
            catch (Exception e)
            {
                Logger.Error("No Pop-Up: " + e);
                
                //throw;
            }


            try
            {
                ButtonHelper.ClickButton(By.XPath(".//*[@class='header-search cf']/button"));
                Thread.Sleep(5000);


            }
            catch (Exception e)
            {
                Logger.Error("Exception: " + e);
                Assert.Fail("Exception" + e);
                throw;
            }
        }

        [Then(@"I Should See Search Results for '(.*)' Containing The Keyword '(.*)'")]
        public void ThenIShouldSeeSearchResultsForContainingTheKeyword(string p0, string p1)
        {
            try
            {

                string url = p0;

                switch (url)
                {
                    case "Natural Museum":
                        
                        Thread.Sleep(5000);
                        //JavaScriptExecutor.ScrollToWebElement(By.XPath(".//*[@class='search-tile-title']/a"));
                        JavaScriptExecutor.ScrollToView(By.XPath("//*[@id='list']/ul/li[1]/a/span"));
                        Assert.IsTrue(GenericHelper.GetElement(By.XPath("//*[@id='list']/ul/li[1]/a/span")).Text.Contains(p1));
                        //ButtonHelper.ClickButton(By.XPath(".//*[@class='search-grid-results']/li[1]/div[1]/div/h3/a"));
                        break;
                    case "Science Museum":
                        Thread.Sleep(5000);
                        JavaScriptExecutor.ScrollToView(By.XPath("//*[@id='list']/ul/li[1]/a/span"));
                        Assert.IsTrue(GenericHelper.GetElement(By.XPath("//*[@id='list']/ul/li[1]/a/span")).Text.Contains(p1));
                        break;
                    case "Premier Inn":
                        Thread.Sleep(5000);
                        JavaScriptExecutor.ScrollToView(By.XPath("//*[@id='list']/ul/li[1]/a/span"));
                        Assert.IsTrue(GenericHelper.GetElement(By.XPath("//*[@id='list']/ul/li[1]/a/span")).Text.Contains(p1));
                        break;
                    /*   case "Holiday Inn":
                         Thread.Sleep(5000);
                         JavaScriptExecutor.ScrollToView(By.XPath(".//*[@class='search-grid-results']/li[1]/div[1]/div/h3/a"));
                         Assert.IsTrue(GenericHelper.GetElement(By.XPath(".//*[@class='search-grid-results']/li[1]/div[1]/div/h3/a")).Text.Contains(p1));
                         break;
                     case "Harry Potter":
                         Thread.Sleep(5000);
                         JavaScriptExecutor.ScrollToView(By.XPath(".//*[@class='search-grid-results']/li[1]/div[1]/div/h3/a"));
                         Assert.IsTrue(GenericHelper.GetElement(By.XPath(".//*[@class='search-grid-results']/li[1]/div[1]/div/h3/a")).Text.Contains(p1));
                         break;*/
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
