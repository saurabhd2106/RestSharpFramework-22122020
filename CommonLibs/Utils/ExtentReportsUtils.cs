using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibs.Utils
{
    public class ExtentReportsUtils
    {
        private ExtentReports extentReport;

        private ExtentHtmlReporter htmlReporter;

        private ExtentTest extentTest;


        public ExtentReportsUtils(string htmlReportFilename)
        {
            _ = htmlReportFilename.Trim();

            htmlReporter = new ExtentHtmlReporter(htmlReportFilename);

            extentReport = new ExtentReports();

            extentReport.AttachReporter(htmlReporter);

        }

        public void CreateTestcase(string testcaseName)
        {
            extentTest = extentReport.CreateTest(testcaseName);
        }

        public void CreateTestcase(string testcaseName, string description)
        {
            extentTest = extentReport.CreateTest(testcaseName, description);
        }

        public void Log(Status status, string logMessage)
        {

            extentTest.Log(status, logMessage);

        }

        public void FlushReport()
        {
            extentReport.Flush();
        }
    }
}
