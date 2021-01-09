using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using COVID.Dashboard.ApiClient.Interface;
using COVID.Dashboard.Buisness.Interface;
using COVID.Dashboard.Models.DTO;
using RestSharp;

namespace COVID.Dashboard.Buisness.Implementation
{
    public class ReportService : IReportService
    {
        private readonly IApiClient _apiClient;

        public ReportService(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public List<ReportDTO> GetTop10RegionsMostCovidCases()
        {
            var client = _apiClient.GetRestClient();
            var request = _apiClient.GetRestRequest("reports");
            var response = client.Get<ReportDataDTO>(request);
            var filtererData = response.Data.Data.OrderByDescending(d => d.Confirmed)
                .Take(10)
                .ToList();
            return filtererData;
        }
    }
}
