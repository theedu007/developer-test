using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COVID.Dashboard.ApiClient.Interface;
using COVID.Dashboard.Buisness.Interface;
using COVID.Dashboard.Models.Auxiliary;
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

        public Dictionary<IsoRegionModel, int> GetTop10RegionsMostCovidCases()
        {
            var client = _apiClient.GetRestClient();
            var request = _apiClient.GetRestRequest("reports");
            var response = client.Get<ReportDataDTO>(request);
            var filtererData = response.Data.Data.OrderByDescending(d => d.Confirmed) // Order data by confirmed cases
                .GroupBy(x => new {x.Region.Iso, x.Region.Name}) // Group Data by region
                .ToDictionary(group => group.Key,
                    group =>
                        group.Sum(item => item.Confirmed)) // take grouped data an convert in <IsoCode, TotalCases> 
                .Take(10)
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => new IsoRegionModel() {Iso = x.Key.Iso, RegionName = x.Key.Name}, x => x.Value);
            return new Dictionary<IsoRegionModel, int>();
        }
    }
}
