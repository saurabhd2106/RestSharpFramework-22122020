using AventStack.ExtentReports;
using BestBuyAPITest.Model;
using BestBuyTests.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BestBuyTests.Tests
{
    [TestClass]
    public class ProductApiTest : BaseTest
    {

        [TestMethod]
        public void VerifyGetAPITestWithQueryParamAndDeserializeResponse()
        {
            ExtentReportUtils.CreateTestcase("TC-1 - Verify Get API Test with Query Parameter");
            Console.WriteLine("Test case 1");
            //Prepare the test data
            int limit = 2;

            ExtentReportUtils.Log(Status.Info, $"Query parameter uses is limit and the value is {limit}");


            Dictionary<string, object> queryParameters = new Dictionary<string, object>();

            queryParameters.Add("$limit", limit);

            //Send the call and get the response
            IRestResponse<RootProductDto> restResponse;

            restResponse = requestFactory.GetAllProduct(ProductEndPointUrl, queryParameters);

            StatusCode.VerifyNotFoundStatusCode(restResponse);

            Assert.AreEqual(limit, restResponse.Data.limit);


        }

        [TestMethod]
        public void VerifyGetAPITestAndDeserializeResponse()
        {
            ExtentReportUtils.CreateTestcase("TC-2 - Verify Get All API Test and Deserialize Response");
            //Send the call and get the response
            IRestResponse<RootProductDto> restResponse;

            restResponse = requestFactory.GetAllProduct(ProductEndPointUrl);

            //Add Assertions

            StatusCode.VerifySuccessStatusCode(restResponse);



        }

        [TestMethod]
        public void VerifyPostAPITestWithStringRequestPayload()
        {

            ExtentReportUtils.CreateTestcase("TC-2 - Verify Post API Test With String Request Payload");

            //Send the call and get the response
            IRestResponse<RootProductDto> restResponse;

            string requestPayload = "{\r\n  \"name\": \"IPhone\",\r\n  \"type\": \"Mobile\",\r\n  \"price\": 1000,\r\n  \"shipping\": 20,\r\n  \"upc\": \"ABC@123\",\r\n  \"description\": \"Best Mobile\",\r\n  \"manufacturer\": \"Apple\",\r\n  \"model\": \"IPhone 12\",\r\n  \"url\": \"string\",\r\n  \"image\": \"string\"\r\n}";

            restResponse = requestFactory.AddProduct(ProductEndPointUrl, requestPayload);

            //Add Assertions
            StatusCode.VerifyCreatesStatusCode(restResponse);

        }

        [TestMethod]
        public void VerifyPostAPITestWithDictionaryAsRequestPayload()
        {

            //Send the call and get the response
            IRestResponse<RootProductDto> restResponse;

            Dictionary<string, object> requestPayload = new Dictionary<string, object>();

            requestPayload.Add("name", "IPhone");
            requestPayload.Add("type", "Mobile");
            requestPayload.Add("price", 1000);
            requestPayload.Add("shipping", 30);
            requestPayload.Add("upc", "IPhone 123");
            requestPayload.Add("description", "Best IPhone");
            requestPayload.Add("manufacturer", "Apple");
            requestPayload.Add("model", "IPhone 12");
            requestPayload.Add("url", "asfdsd");
            requestPayload.Add("image", "Apple");

            restResponse = requestFactory.AddProduct(ProductEndPointUrl, requestPayload);

            //Add Assertions
            StatusCode.VerifyCreatesStatusCode(restResponse);

        }

        [TestMethod]
        public void VerifyPostAPITestWithDtoObjectAsRequestPayload()
        {

            //Send the call and get the response
            IRestResponse<RootProductDto> restResponse;


            ProductDto requestPayload = new ProductDto();

            requestPayload.name = "Samsung Mobile";
            requestPayload.type = "Mobile";
            requestPayload.price = 1000;
            requestPayload.shipping = 10;
            requestPayload.upc = "asd@udfg";
            requestPayload.description = "Best Mobile";
            requestPayload.manufacturer = "Samsung";
            requestPayload.model = "M21";
            requestPayload.url = "asfhgsdjh";
            requestPayload.image = "asfskd";

            restResponse = requestFactory.AddProduct(ProductEndPointUrl, requestPayload);

            //Add Assertions
            StatusCode.VerifyCreatesStatusCode(restResponse);

        }



    }
}
