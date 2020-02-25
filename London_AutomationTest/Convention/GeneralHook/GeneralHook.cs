using Convention.ComponentHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Convention.GeneralHook
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
        //private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public TestContext TestContext { get; set; }

        private ScreenshotTaker ScreenshotTaker { get; set; }

        [BeforeScenario()]

        public void Initialise()
        {


        }

        [AfterScenario()]
        public void CleanUp()
        {

        }
    }
}
