using BestBuyApp.ProductRequests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyTests.Tests
{
    public class BaseTest
    {

        public string EnpointUrl { get; set; }

        public string ProductResource { get; set; }
        
        public string ProductEndPointUrl { get; set; }


        public RequestFactory requestFactory;

        [AssemblyInitialize]
        public static void PreSetup(TestContext context)
        {

            

            Console.WriteLine("Pre Setup");

            
        }

        [TestInitialize]
        public void Setup()
        {
            EnpointUrl = "http://ec2-3-129-89-35.us-east-2.compute.amazonaws.com:3030";

            ProductResource = "products";

            ProductEndPointUrl = $"{EnpointUrl}/{ProductResource}";

            requestFactory = new RequestFactory();
        }

        [TestCleanup]
        public void Cleanup()
        {

        }


        [AssemblyCleanup]
        public void PostCleanUp()
        {

        }

    }
}
