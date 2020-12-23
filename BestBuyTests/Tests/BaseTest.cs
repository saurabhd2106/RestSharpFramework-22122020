﻿using AventStack.ExtentReports;
using BestBuyApp.ProductRequests;
using CommonLibs.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BestBuyTests.Tests
{
    [TestClass]
    public class BaseTest
    {

        public string EnpointUrl { get; set; }

        public string ProductResource { get; set; }

        public string ProductEndPointUrl { get; set; }

        public static string CurrentWorkingDirectory;

        public static string CurrentProjectDirectory;

        public static string CurrentSolutionDirectory;

        public RequestFactory requestFactory;

        public static ExtentReportsUtils ExtentReportUtils;

        public TestContext TestContext { get; set; }

        [AssemblyInitialize]
        public static void OneTimeSetup(TestContext TestContext)
        {

            CurrentWorkingDirectory = Environment.CurrentDirectory;

            CurrentProjectDirectory = Directory.GetParent(CurrentWorkingDirectory).Parent.Parent.FullName;

            CurrentSolutionDirectory = Directory.GetParent(CurrentWorkingDirectory).Parent.Parent.Parent.FullName;

            string htmlReportFilename = $"{CurrentProjectDirectory}/Reports/Test.html";
            
            ExtentReportUtils = new ExtentReportsUtils(htmlReportFilename);
            

        }

        [ClassInitialize(InheritanceBehavior.BeforeEachDerivedClass)]
        public static void PreSetup(TestContext TestContext)
        {

            Console.WriteLine("Pre Setup");


        }

        [TestInitialize]
        public void Setup()
        {
            ExtentReportUtils.CreateTestcase("Setup");

            EnpointUrl = "http://ec2-3-129-89-35.us-east-2.compute.amazonaws.com:3030";

            ProductResource = "products";

            ProductEndPointUrl = $"{EnpointUrl}/{ProductResource}";

            ExtentReportUtils.Log(Status.Info, $"Product Enpoint URL - {ProductEndPointUrl} ");
            requestFactory = new RequestFactory();
        }

        [TestCleanup]
        public void Cleanup()
        {

            if(TestContext.CurrentTestOutcome == UnitTestOutcome.Failed 
                || TestContext.CurrentTestOutcome == UnitTestOutcome.Error)
            {
                ExtentReportUtils.Log(Status.Fail, "One or more test step failed");

            }
            else if(TestContext.CurrentTestOutcome == UnitTestOutcome.Aborted)
            {
                ExtentReportUtils.Log(Status.Skip, "Test Aborted");
            }


        }


        [AssemblyCleanup]
        public static void PostCleanUp()
        {
            Console.WriteLine("Post Cleanup");

            ExtentReportUtils.FlushReport();
        }

    }
}
