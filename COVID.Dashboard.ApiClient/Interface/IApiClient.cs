using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace COVID.Dashboard.ApiClient.Interface
{
    public interface IApiClient
    {
        RestClient GetRestClient();

        RestRequest GetRestRequest(string endpoint);
    }
}
