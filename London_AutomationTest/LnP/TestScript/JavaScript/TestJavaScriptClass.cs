using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using LnP.ComponentHelper;
using LnP.Settings;
using System.Threading;

namespace LnP.TestScript.JavaScript
{
    [TestClass]
    public class TestJavaScriptClass
    {
        IWebDriver driver;
        [TestMethod]
        public void TestJavaScript()
        {
            NavigationHelper.NavigateToUrl("https://www.udemy.com/bdd-with-selenium-webdriver-and-speckflow-using-c/");
            //LinkHelper.ClickLink(By.LinkText("File a Bug"));
            IJavaScriptExecutor executor = ((IJavaScriptExecutor) ObjectRepository.Driver);
            //executor.ExecuteScript("document.getElementById('Bugzilla_login').value='rahul@bugzila.com'");
            //executor.ExecuteScript("document.getElementById('Bugzilla_password').value='rathore'");
            //executor.ExecuteScript("document.getElementById('log_in').click()");

            IWebElement element = ObjectRepository.Driver.FindElement(By.XPath("//div[@id='related']/ul/li[1]/a"));
            executor.ExecuteScript("window.scrollTo(0," + element.Location.Y + ")");
            element.Click();

        }

        [TestMethod]
        public void ScrollToView()
        {
            NavigationHelper.NavigateToUrl("http://qa.conventionbureau.london/search-accommodation");
            Thread.Sleep(5000);
            JavaScriptExecutor.ScrollToView(By.XPath(".//*[@id='list']/ul/li[3]/div/h3/a"));
            Thread.Sleep(1000);
        }

        [TestMethod]
        public void VerifyImage()
        {
            
            NavigationHelper.NavigateToUrl("http://qa.visitlondon.com/offers-and-competitions/competitions");
            Thread.Sleep(5000);
            //JavaScriptExecutor.ScrollToView(By.XPath(".//*[@id='content']/div[2]/div[1]/div[2]/div/div[1]"));
            //JavaScriptExecutor.ScrollToView(By.XPath(".//*[@id='content']/div[2]/div/section[1]/div/a/img"));
            //Assert.IsTrue(GenericHelper.GetElement(By.XPath(".//*[@id='content']/div[2]/div/section[1]/div/a/img")).Displayed);

             /* try
              // Boolean ImagePresent = (Boolean)((JavaScriptExecutor)driver).executeScript();
              {
                  Thread.Sleep(5000);
                  JavaScriptExecutor.ScrollToView(By.XPath(".//*[@id='content']/div[2]/div/section[1]/div/a/img"));
                  Thread.Sleep(5000);
                //Assert.IsTrue(GenericHelper.GetElement(By.XPath(".//*[@id='content']/div[2]/div/section[1]/div/a/img")).Text.Contains("chinatown_on_yee_jon_mo1920x1080.jpg"));
                //GenericHelper.GetElement(By.CssSelector());
                GenericHelper.GetElement(By.XPath(".//*[contains@src,'chinatown_on_yee_jon_mo1920x1080.jpg']"));

            }
              catch (Exception e)
              {
                  //Logger.Error("Exception: " + e);
                  Console.WriteLine("Image not displayed." + e);
                  Assert.Fail("Exception" + e);
                  throw;
              }*/


            // IWebElement section = GenericHelper.GetElement(By.XPath(".//*[@id='content']/div[2]/div[1]/div[2]/div/div[1]/div[1]"));
            
            Thread.Sleep(5000);
            JavaScriptExecutor.ScrollToView(By.XPath(".//*[@id='content']/div[2]/div/section[1]/div/a/img"));
            Thread.Sleep(5000);
            IWebElement section = GenericHelper.GetElement(By.XPath(".//*[@id='content']/div[2]/div/section[1]/div/a/img"));

            //Boolean ImageFile = (Boolean)()
            //IWebDriver driver;

            //IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //Boolean ImagePresent = (Boolean)(js.ExecuteScript("return arguments[0].complete && typeof arguments[0].naturalWidth != \"undefined\" && arguments[0].naturalWidth > 0", section));
            Boolean ImagePresent = (Boolean)((IJavaScriptExecutor)driver).ExecuteScript("return arguments[0].complete && typeof arguments[0].naturalWidth != \"undefined\" && arguments[0].naturalWidth > 0", section);
            try
            {
                if (!ImagePresent)
                {

                    Console.WriteLine("Image not displayed.");
                    Assert.Fail();

                }
                else
                {

                    Console.WriteLine("Image displayed.");

                }

            }
            catch (Exception e)
            {
                Assert.Fail("Exception" + e);
                throw;
            } 


            //string title = (string)js.ExecuteScript("");




            //IWebElement Image = section.FindElement(By.XPath(".//*[@id='content']/div[2]/div[1]/div[2]/div/div[1]/div[1]/img"));

            //Assert.IsTrue((section).Displayed);

            // try
            // {

            // } catch (Exception e)
            // {
            //Logger.Error("Exception: " + e);
            //    Assert.Fail("Exception" + e);
            //    throw;
            // }

            //Boolean ImagePresent = (Boolean) ((JavaScriptExecutor)


        }

        [TestMethod]
        public void FindLinks()
        {
            NavigationHelper.NavigateToUrl("http://qa.conventionbureau.london/search-accommodation");
            Thread.Sleep(5000);
            JavaScriptExecutor.ScrollToView(By.XPath(".//*[@id='list']/ul/li[3]/div/h3/a"));
            Thread.Sleep(1000);

            var url = "http://qa.conventionbureau.london/search-accommodation";
            //var httpClient = new HttpClient();
        }
    }
}
