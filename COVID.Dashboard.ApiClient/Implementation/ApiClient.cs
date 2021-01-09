using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using COVID.Dashboard.ApiClient.ApiConfig;
using COVID.Dashboard.ApiClient.Interface;
using RestSharp;

namespace COVID.Dashboard.ApiClient.Implementation
{
    public class ApiClient : IApiClient
    {
        private readonly ApiConfigSection _apiConfig;

        public ApiClient(ApiConfigSection apiConfig)
        {
            _apiConfig = apiConfig;
        }

        public RestClient GetRestClient(string endpoint)
        {
            var client = new RestClient(_apiConfig.BaseUrl);
            return client;
        }
    }
}