using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Visit.GeneralHook
{
    [Binding]
    public class GeneralHook
    {
        //private readonly IObjectContainer _objectContainer;
        //public IWebDriver _idriver;

        //public GeneralHook(IObjectContainer objectContainer)
        //{
        //  _objectContainer = objectContainer;
        //}

        [BeforeScenario()]

        public void Initialise()
        {
            Console.WriteLine("Result :{0}", "Before Scenario................");

        }

        [AfterScenario()]
        public void CleanUp()
        {
            Console.WriteLine("Result :{0}", "After Scenario.................");
        }

    }
}
