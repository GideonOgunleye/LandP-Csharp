using Convention.ComponentHelper;
using Convention.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Convention.TestScript
{
    [TestClass]
    public class TestCvbNav
    {
        [TestMethod]
        public void GetCvbNav()
        {
            //ExtentReportHelper.extentTest = ExtentReportHelper.extentReport.CreateTest("GetNav Test");

            //ExtentReport extent = new ExtentReports();
            //ExtentReportHelper.extentTest = extent.CreateTest("GetNav", "Testing");

            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            ReportHelper.PassingTestLogger("TestReport Sucessful");

            //ExtentReportHelper.extentTest.Log(Status.Pass, "Pass");
            //ExtentReportHelper.extentTest.Pass("Test Passed");
            Thread.Sleep(5000);
            //ExtentReportHelper.extentTest.Pass("Test Passed");


        }
    }
}
