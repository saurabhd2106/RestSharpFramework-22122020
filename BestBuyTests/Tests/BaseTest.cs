using AventStack.ExtentReports;
using BestBuyApp.ProductRequests;
using CommonLibs.Utils;
using Microsoft.Extensions.Configuration;
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

        public static IConfiguration Configuration;

        public TestContext TestContext { get; set; }

        public static DatabaseUtils DatabaseUtils { get; set; }

        [AssemblyInitialize]
        public static void OneTimeSetup(TestContext TestContext)
        {

            CurrentWorkingDirectory = Environment.CurrentDirectory;

            CurrentProjectDirectory = Directory.GetParent(CurrentWorkingDirectory).Parent.Parent.FullName;

            CurrentSolutionDirectory = Directory.GetParent(CurrentWorkingDirectory).Parent.Parent.Parent.FullName;

            string htmlReportFilename = $"{CurrentProjectDirectory}/Reports/Test.html";
            
            ExtentReportUtils = new ExtentReportsUtils(htmlReportFilename);

            Configuration = new ConfigurationBuilder().AddJsonFile(CurrentProjectDirectory + "/Config/appSettings.json").Build();

           
        }

        [ClassInitialize(InheritanceBehavior.BeforeEachDerivedClass)]
        public static void PreSetup(TestContext TestContext)
        {

            Console.WriteLine("Pre Setup");

            DatabaseUtils = new DatabaseUtils();
        }

        [TestInitialize]
        public void Setup()
        {
            ExtentReportUtils.CreateTestcase("Setup");

            EnpointUrl = $"{Configuration["environment:server"]}:{Configuration["environment:portNumber"]}";

            ProductResource = "products";

            ProductEndPointUrl = $"{EnpointUrl}/{ProductResource}";

            ExtentReportUtils.Log(Status.Info, $"Product Enpoint URL - {ProductEndPointUrl} ");
            requestFactory = new RequestFactory();

            //Establish a Database connection;

            string dataSource = Configuration["dataBase:dataSource"];
            string userId = Configuration["dataBase:userId"];
            string password = Configuration["dataBase:password"];
            string dbName = Configuration["dataBase:dbName"];

            DatabaseUtils.CreateConnection(dataSource,userId,password, dbName);
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

            DatabaseUtils.CloseConnection();
        }


        [AssemblyCleanup]
        public static void PostCleanUp()
        {
            Console.WriteLine("Post Cleanup");

            ExtentReportUtils.FlushReport();
        }

    }
}
