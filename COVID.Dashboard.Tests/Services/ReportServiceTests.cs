using System.Collections.Generic;
using COVID.Dashboard.ApiClient.Exception;
using COVID.Dashboard.ApiClient.Interface;
using COVID.Dashboard.Buisness.Implementation;
using COVID.Dashboard.Models.Auxiliary;
using COVID.Dashboard.Models.DTO;
using Moq;
using NUnit.Framework;
using RestSharp;

namespace COVID.Dashboard.Tests.Services
{
    [TestFixture]
    public class ReportServiceTests
    {
        [TestCase]
        public void GetTop10RegionsMostCovidCases_RequestSuccessful_ShouldReturnDictionary()
        {
            var restSharpResponse = new Mock<IRestResponse<ReportDataDTO>>();
            restSharpResponse.SetupGet(x => x.IsSuccessful)
                .Returns(true);
            restSharpResponse.SetupGet(x => x.Data)
                .Returns(() => new ReportDataDTO()
                {
                    Data = new List<ReportDTO>()
                });

            var restSharpClient = new Mock<RestClient>();
            restSharpClient.Setup(x => x.Execute<ReportDataDTO>(It.IsAny<IRestRequest>(), Method.GET))
                .Returns(() => restSharpResponse.Object);

            var apiClient = new Mock<IApiClient>();
            apiClient.Setup(x => x.GetRestClient())
                .Returns(() => restSharpClient.Object);
            
            apiClient.Setup(x => x.GetRestRequest(It.IsAny<string>()))
                .Returns(() => new RestRequest());

            var reportService = new ReportService(apiClient.Object);

            var result = reportService.GetTop10RegionsMostCovidCases();
            
            Assert.IsInstanceOf<Dictionary<IsoRegionModel,CasesDeathModel>>(result);
        }

        [TestCase]
        public void GetTop10RegionsMostCovidCases_RequestFailed_ShouldThrowException()
        {
            var restSharpResponse = new Mock<IRestResponse<ReportDataDTO>>();
            restSharpResponse.SetupGet(x => x.IsSuccessful)
                .Returns(false);

            var restSharpClient = new Mock<RestClient>();
            restSharpClient.Setup(x => x.Execute<ReportDataDTO>(It.IsAny<IRestRequest>(), Method.GET))
                .Returns(() => restSharpResponse.Object);

            var apiClient = new Mock<IApiClient>();
            apiClient.Setup(x => x.GetRestClient())
                .Returns(() => restSharpClient.Object);

            apiClient.Setup(x => x.GetRestRequest(It.IsAny<string>()))
                .Returns(() => new RestRequest());

            var reportService = new ReportService(apiClient.Object);

            Assert.Throws<ApiClientException>(() => reportService.GetTop10RegionsMostCovidCases());
        }

        [TestCase]
        public void GetTop10CovidCasesProvincesByRegion_RequestSuccessful_ShouldReturnDictionary()
        {
            var restSharpResponse = new Mock<IRestResponse<ReportDataDTO>>();
            restSharpResponse.SetupGet(x => x.IsSuccessful)
                .Returns(true);
            restSharpResponse.SetupGet(x => x.Data)
                .Returns(() => new ReportDataDTO()
                {
                    Data = new List<ReportDTO>()
                });

            var restSharpClient = new Mock<RestClient>();
            restSharpClient.Setup(x => x.Execute<ReportDataDTO>(It.IsAny<IRestRequest>(), Method.GET))
                .Returns(() => restSharpResponse.Object);

            var apiClient = new Mock<IApiClient>();
            apiClient.Setup(x => x.GetRestClient())
                .Returns(() => restSharpClient.Object);

            apiClient.Setup(x => x.GetRestRequest(It.IsAny<string>()))
                .Returns(() => new RestRequest());

            var reportService = new ReportService(apiClient.Object);

            var result = reportService.GetTop10CovidCasesProvincesByRegion("US");

            Assert.IsInstanceOf<Dictionary<ProvinceIsoModel, CasesDeathModel>>(result);
        }

        [TestCase]
        public void GetTop10CovidCasesProvincesByRegion_RequestFailed_ShouldThrowException()
        {
            var restSharpResponse = new Mock<IRestResponse<ReportDataDTO>>();
            restSharpResponse.SetupGet(x => x.IsSuccessful)
                .Returns(false);

            var restSharpClient = new Mock<RestClient>();
            restSharpClient.Setup(x => x.Execute<ReportDataDTO>(It.IsAny<IRestRequest>(), Method.GET))
                .Returns(() => restSharpResponse.Object);

            var apiClient = new Mock<IApiClient>();
            apiClient.Setup(x => x.GetRestClient())
                .Returns(() => restSharpClient.Object);

            apiClient.Setup(x => x.GetRestRequest(It.IsAny<string>()))
                .Returns(() => new RestRequest());

            var reportService = new ReportService(apiClient.Object);

            Assert.Throws<ApiClientException>(() => reportService.GetTop10CovidCasesProvincesByRegion("US"));
        }

    }
}
