using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using COVID.Dashboard.ApiClient.ApiConfig;
using COVID.Dashboard.ApiClient.Interface;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace COVID.Dashboard.ApiClient.Implementation
{
    public class ApiClient : IApiClient
    {
        private readonly ApiConfigSection _apiConfig;

        public ApiClient(ApiConfigSection apiConfig)
        {
            _apiConfig = apiConfig;
        }

        public RestClient GetRestClient()
        {
            var client = new RestClient(_apiConfig.BaseUrl);
            client.UseNewtonsoftJson();
            client.ThrowOnAnyError = true;
            return client;
        }

        public RestRequest GetRestRequest(string endpoint)
        {
            var request = new RestRequest(endpoint, DataFormat.Json);
            request.AddHeader("x-rapidapi-key", _apiConfig.ApiKey);
            request.AddHeader("x-rapidapi-host", _apiConfig.ApiHost);

            return request;
        }
    }
}