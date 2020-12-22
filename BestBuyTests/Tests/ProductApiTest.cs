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
            //Prepare the test data
            int limit = 2;

            Dictionary<string, object> queryParameters = new Dictionary<string, object>();

            queryParameters.Add("$limit", limit);

            //Send the call and get the response
            IRestResponse<RootProductDto> restResponse;

            restResponse = requestFactory.GetAllProduct(ProductEndPointUrl, queryParameters);

            StatusCode.VerifySuccessStatusCode(restResponse);

            Assert.AreEqual(limit, restResponse.Data.limit);


        }

        [TestMethod]
        public void VerifyGetAPITestAndDeserializeResponse()
        {
            
            //Send the call and get the response
            IRestResponse<RootProductDto> restResponse;

            restResponse = requestFactory.GetAllProduct(ProductEndPointUrl);

            //Add Assertions

            StatusCode.VerifySuccessStatusCode(restResponse);



        }

        [TestMethod]
        public void VerifyPostAPITestWithStringRequestPayload()
        {

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
