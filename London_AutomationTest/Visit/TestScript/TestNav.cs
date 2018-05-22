using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Visit.ComponentHelper;
using Visit.Settings;

namespace Visit.TestScript
{
    [TestClass]
    public class TestNav
    {
        [TestMethod]
        public void GetNav()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            Thread.Sleep(5000);
        }
    }
}
