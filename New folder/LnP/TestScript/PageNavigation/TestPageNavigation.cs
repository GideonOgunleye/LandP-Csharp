using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using LnP.ComponentHelper;
using LnP.Settings;

namespace LnP.TestScript.PageNavigation
{
    [TestClass]
   public class TestPageNavigation
    {
        [TestMethod]
        public void OpenPage()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            Console.WriteLine("Title of Page : {0}",WindowHelper.GetTitle());
            
        }
    }
}
