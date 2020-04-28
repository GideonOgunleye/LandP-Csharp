using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LnP.ComponentHelper;

namespace LnP.TestScript.Log4Net
{
    [TestClass]
    public class TestLogger
    {
        //public string Name { get; private set; }

        [TestMethod]
        public void TestLog4Net()
        {
            //1. Create the layout
            //2. Use this layout in the appender
            //3. Initialize the configuration
            //4. Get the instance of the logger

            /*var patterLayout = new PatternLayout();
            patterLayout.ConversionPattern = "%message";
            patterLayout.ActivateOptions();

            var consoleAppender = new ConsoleAppender();
            {
                /*Name = "ConsoleAppender",
                Layout = patterLayout,
                Threshold = Level.All#1#
            }*/
            ILog Logger = Log4NetHelper.GetLogger(typeof(TestLogger));

            for (var i = 0; i < 3000; i++)
            {
                Logger.Debug("This is Debug Information");
                Logger.Info("This is Info Information");
                Logger.Warn("This is Warn Information");
                Logger.Error("This is Error Information");
                Logger.Fatal("This is Fatal Information");
            }


        }

        [TestMethod]
        public void TestLog4NetSec()
        {
            //Log4NetHelper.Layout = "%message%newline";
            //ILog Logger = Log4NetHelper.GetLogger(typeof(TestLogger));
            ILog Logger = Log4NetHelper.GetXmlLogger(typeof(TestLogger));

            for (var i = 0; i < 3000; i++)
            {
                Logger.Debug("This is Debug Information");
                Logger.Info("This is Info Information");
                Logger.Warn("This is Warn Information");
                Logger.Error("This is Error Information");
                Logger.Fatal("This is Fatal Information");
            }


        }
    }
}
