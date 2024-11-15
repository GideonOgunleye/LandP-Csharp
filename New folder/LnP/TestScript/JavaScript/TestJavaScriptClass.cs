﻿using System;
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
    }
}
