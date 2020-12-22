using BestBuyAPITest.Model;
using CommonLibs.Client;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyApp.ProductRequests
{
    public class RequestFactory
    {

        RestClientCustom restClientCustom;

        public RequestFactory()
        {
            restClientCustom = new RestClientCustom();
        }

        public IRestResponse<RootProductDto> GetAllProduct(string endpointUrl)
        {

            IRestRequest restRequest = new RestRequest(endpointUrl);

            IRestResponse<RootProductDto> restResponse = restClientCustom.SendGetRequest<RootProductDto>(restRequest, null, null);

            return restResponse;

        }

        public IRestResponse<RootProductDto> GetAllProduct(string endpointUrl, Dictionary<string, object> queryParam)
        {
          
            IRestRequest restRequest = new RestRequest(endpointUrl);

            IRestResponse<RootProductDto> restResponse = restClientCustom.SendGetRequest<RootProductDto>(restRequest, null, queryParam);

            return restResponse;

        }

        public IRestResponse<RootProductDto> AddProduct(string endpointUrl, object requestPayload)
        {
            IRestRequest restRequest = new RestRequest(endpointUrl);

            IRestResponse<RootProductDto> restResponse = restClientCustom.SendPostRequest<RootProductDto>(restRequest, null, requestPayload);

            return restResponse;
        }

    }
}
