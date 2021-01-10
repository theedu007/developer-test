using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID.Dashboard.ApiClient.Exception
{
    public class ApiClientException : System.Exception
    {
        public ApiClientException(string message) : base(message)
        {
            
        }
    }
}
