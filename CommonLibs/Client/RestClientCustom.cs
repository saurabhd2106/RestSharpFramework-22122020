using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibs.Client
{
    public class RestClientCustom
    {
        public IRestClient RestClient { get; }

        public RestClientCustom()
        {
            RestClient = new RestClient();

        }

        public IRestResponse<T> SendGetRequest<T>(IRestRequest request, Dictionary<string,string> headers, Dictionary<string, object> parameters)
        {

            addHeadersToRequest(request, headers);

            addParametersToRequest(request, parameters);
            

            IRestResponse<T> restResponse;

            restResponse = RestClient.Get<T>(request);

            return restResponse;

        }

        public IRestResponse<T> SendPostRequest<T>(IRestRequest request, Dictionary<string, string> headers, object requestPayload)
        {

            addHeadersToRequest(request, headers);

            addRequestPayloadToRequest(request, requestPayload);

            IRestResponse<T> restResponse;

            restResponse = RestClient.Post<T>(request);

            return restResponse;

        }

        public IRestResponse<T> SendPutRequest<T>(IRestRequest request, Dictionary<string, string> headers, object requestPayload)
        {

            addHeadersToRequest(request, headers);

            addRequestPayloadToRequest(request, requestPayload);

            IRestResponse<T> restResponse;

            restResponse = RestClient.Put<T>(request);

            return restResponse;

        }

        public IRestResponse<T> SendPatchRequest<T>(IRestRequest request, Dictionary<string, string> headers, object requestPayload)
        {

            addHeadersToRequest(request, headers);

            addRequestPayloadToRequest(request, requestPayload);

            IRestResponse<T> restResponse;

            restResponse = RestClient.Patch<T>(request);

            return restResponse;

        }
        public IRestResponse<T> SendDeleteRequest<T>(IRestRequest request, Dictionary<string, string> headers)
        {

            addHeadersToRequest(request, headers);


            IRestResponse<T> restResponse;

            restResponse = RestClient.Delete<T>(request);

            return restResponse;

        }


        private void addRequestPayloadToRequest(IRestRequest request, object requestPayload)
        {
            request.AddJsonBody(requestPayload);
        }

        private void addParametersToRequest(IRestRequest request, Dictionary<string, object> parameters)
        {
            if (parameters != null)
            {

                foreach (var param in parameters)
                {
                    request.AddParameter(param.Key, param.Value);
                }

            }
        }

        private void addHeadersToRequest(IRestRequest request, Dictionary<string, string> headers)
        {
            if (headers != null)
            {

                foreach (var header in headers)
                {
                    request.AddHeader(header.Key, header.Value);
                }

            }
        }
    }
}
