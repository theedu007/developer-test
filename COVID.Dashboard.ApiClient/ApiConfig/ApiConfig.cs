using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace COVID.Dashboard.ApiClient.ApiConfig
{
    public static class ApiConfig
    {
        private static ApiConfigSection Config => (ApiConfigSection)ConfigurationManager.GetSection("CovidApi");

        public static ApiConfigSection GetApiConfigSection()
        {
            return Config;
        }

    }
}