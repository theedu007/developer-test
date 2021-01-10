using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COVID.Dashboard.ApiClient.Exception;
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

        public Dictionary<IsoRegionModel, CasesDeathModel> GetTop10RegionsMostCovidCases()
        {
            var client = _apiClient.GetRestClient();
            var request = _apiClient.GetRestRequest("reports");
            var response = client.Get<ReportDataDTO>(request);

            if (!response.IsSuccessful)
            {
                throw new ApiClientException("There was an error in request data from endpoint");
            }

            var filtererData = response.Data.Data // Order data by confirmed cases
                .GroupBy(x => new {x.Region.Iso, x.Region.Name}) // Group Data by region
                .ToDictionary(group => group.Key,
                    group => new CasesDeathModel()
                    {
                        Cases = group.Sum(item => item.Confirmed),
                        Deaths = group.Sum(item => item.Deaths)
                    }) // take grouped data an convert in <IsoCode, TotalCases> 
                .OrderByDescending(x => x.Value.Cases)
                .Take(10)
                .ToDictionary(x => new IsoRegionModel() {Iso = x.Key.Iso, RegionName = x.Key.Name}, x => x.Value);
            return filtererData;
        }

        public Dictionary<ProvinceIsoModel, CasesDeathModel> GetTop10CovidCasesProvincesByRegion(string iso)
        {
            var client = _apiClient.GetRestClient();
            var request = _apiClient.GetRestRequest("reports");
            request.AddParameter("iso", iso, ParameterType.QueryString);
            var response = client.Get<ReportDataDTO>(request);

            if (!response.IsSuccessful)
            {
                throw new ApiClientException("There was an error in request data from endpoint");
            }

            var filteredData = response.Data.Data
                .OrderByDescending(x => x.Confirmed)
                .Take(10)
                .ToDictionary(
                    x => new ProvinceIsoModel() { Province = x.Region.Province, Iso = x.Region.Iso },
                    x => new CasesDeathModel() { Cases = x.Confirmed, Deaths = x.Deaths });
            return filteredData;
        }

    }
}
