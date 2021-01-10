using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace COVID.Dashboard.ApiClient.ApiConfig
{
    public class ApiConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("BaseUrl")]
        public string BaseUrl => (string)base["BaseUrl"];

        [ConfigurationProperty("ApiKey")]
        public string ApiKey => (string)base["ApiKey"];

        [ConfigurationProperty("ApiHost")]
        public string ApiHost => (string)base["ApiHost"];
    }
}