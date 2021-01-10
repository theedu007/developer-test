using System.Collections.Generic;
using System.Web.Mvc;
using COVID.Dashboard.ApiClient.Exception;
using COVID.Dashboard.Buisness.Interface;
using COVID.Dashboard.Controllers;
using COVID.Dashboard.Models.Auxiliary;
using Moq;
using NUnit.Framework;

namespace COVID.Dashboard.Tests.Controllers
{
    [TestFixture]
    public class DownloadControllerTests
    {
        [TestCase]
        public void GetJson_IsoNull_ApiClientReturnsData_ShouldReturnFile()
        {
            var dictionary = new Dictionary<IsoRegionModel, CasesDeathModel>();
            dictionary.Add(
                new IsoRegionModel() { RegionName = "United State", Iso = "US"},
                new CasesDeathModel() {Cases = 1, Deaths = 1});
            
            var reportService = new Mock<IReportService>();
            reportService.Setup(x => x.GetTop10CovidCasesByCountry())
                .Returns(() => dictionary);

            var controller = new DownloadController(reportService.Object);
            var result = controller.GetJsonFileForRegion(null) as FileResult;

            Assert.IsInstanceOf<FileStreamResult>(result);
            Assert.AreEqual("application/json", result.ContentType);
            Assert.AreEqual("CasesByCountry.json", result.FileDownloadName);
        }

        [TestCase]
        public void GetJson_IsoHasValue_ApiClientReturnsData_ShouldReturnFile()
        {
            var dictionary = new Dictionary<ProvinceIsoModel, CasesDeathModel>();
            var iso = "US";
            dictionary.Add(
                new ProvinceIsoModel() { Province = "Alabama", Iso = iso },
                new CasesDeathModel() { Cases = 1, Deaths = 1 });

            var reportService = new Mock<IReportService>();
            reportService.Setup(x => x.GetTop10CovidCasesByCountryRegions(It.IsAny<string>()))
                .Returns(() => dictionary);

            var controller = new DownloadController(reportService.Object);
            var result = controller.GetJsonFileForRegion(iso) as FileResult;

            Assert.IsInstanceOf<FileStreamResult>(result);
            Assert.AreEqual("application/json", result.ContentType);
            Assert.AreEqual("CasesByCountryProvidence.json", result.FileDownloadName);
        }

        [TestCase]
        public void GetJson_ApiClientThrowsException_ShouldReturnEmptyResult()
        {
            var reportService = new Mock<IReportService>();
            reportService.Setup(x => x.GetTop10CovidCasesByCountry())
                .Throws(new ApiClientException("test message"));

            var controller = new DownloadController(reportService.Object);
            var result = controller.GetJsonFileForRegion(null);

            Assert.IsInstanceOf<EmptyResult>(result);
        }

        [TestCase]
        public void GetCvs_IsoNull_ApiClientReturnsData_ShouldReturnFile()
        {
            var dictionary = new Dictionary<IsoRegionModel, CasesDeathModel>();
            dictionary.Add(
                new IsoRegionModel() { RegionName = "United State", Iso = "US" },
                new CasesDeathModel() { Cases = 1, Deaths = 1 });

            var reportService = new Mock<IReportService>();
            reportService.Setup(x => x.GetTop10CovidCasesByCountry())
                .Returns(() => dictionary);

            var controller = new DownloadController(reportService.Object);
            var result = controller.GetCvsForRegion(null) as FileResult;

            Assert.IsInstanceOf<FileContentResult>(result);
            Assert.AreEqual("text/csv", result.ContentType);
            Assert.AreEqual("CasesByCountry.csv", result.FileDownloadName);
        }

        [TestCase]
        public void GetCvs_IsoHasValue_ApiClientReturnsData_ShouldReturnFile()
        {
            var dictionary = new Dictionary<ProvinceIsoModel, CasesDeathModel>();
            var iso = "US";
            dictionary.Add(
                new ProvinceIsoModel() { Province = "Alabama", Iso = iso },
                new CasesDeathModel() { Cases = 1, Deaths = 1 });

            var reportService = new Mock<IReportService>();
            reportService.Setup(x => x.GetTop10CovidCasesByCountryRegions(It.IsAny<string>()))
                .Returns(() => dictionary);

            var controller = new DownloadController(reportService.Object);
            var result = controller.GetCvsForRegion(iso) as FileResult;

            Assert.IsInstanceOf<FileContentResult>(result);
            Assert.AreEqual("text/csv", result.ContentType);
            Assert.AreEqual("CasesByCountryProvidence.csv", result.FileDownloadName);
        }

        [TestCase]
        public void GetCsv_ApiClientThrowsException_ShouldReturnEmptyResult()
        {
            var reportService = new Mock<IReportService>();
            reportService.Setup(x => x.GetTop10CovidCasesByCountry())
                .Throws(new ApiClientException("test message"));

            var controller = new DownloadController(reportService.Object);
            var result = controller.GetCvsForRegion(null);

            Assert.IsInstanceOf<EmptyResult>(result);
        }

        [TestCase]
        public void GetXml_IsoNull_ApiClientReturnsData_ShouldReturnFile()
        {
            var dictionary = new Dictionary<IsoRegionModel, CasesDeathModel>();
            dictionary.Add(
                new IsoRegionModel() { RegionName = "United State", Iso = "US" },
                new CasesDeathModel() { Cases = 1, Deaths = 1 });

            var reportService = new Mock<IReportService>();
            reportService.Setup(x => x.GetTop10CovidCasesByCountry())
                .Returns(() => dictionary);

            var controller = new DownloadController(reportService.Object);
            var result = controller.GetXmlForRegion(null) as FileResult;

            Assert.IsInstanceOf<FileContentResult>(result);
            Assert.AreEqual("application/xml", result.ContentType);
            Assert.AreEqual("CasesByCountry.xml", result.FileDownloadName);
        }

        [TestCase]
        public void GetXml_IsoHasValue_ApiClientReturnsData_ShouldReturnFile()
        {
            var dictionary = new Dictionary<ProvinceIsoModel, CasesDeathModel>();
            var iso = "US";
            dictionary.Add(
                new ProvinceIsoModel() { Province = "Alabama", Iso = iso },
                new CasesDeathModel() { Cases = 1, Deaths = 1 });

            var reportService = new Mock<IReportService>();
            reportService.Setup(x => x.GetTop10CovidCasesByCountryRegions(It.IsAny<string>()))
                .Returns(() => dictionary);

            var controller = new DownloadController(reportService.Object);
            var result = controller.GetXmlForRegion(iso) as FileResult;

            Assert.IsInstanceOf<FileContentResult>(result);
            Assert.AreEqual("application/xml", result.ContentType);
            Assert.AreEqual("CasesByCountryProvidence.xml", result.FileDownloadName);
        }

        [TestCase]
        public void GetXml_ApiClientThrowsException_ShouldReturnEmptyResult()
        {
            var reportService = new Mock<IReportService>();
            reportService.Setup(x => x.GetTop10CovidCasesByCountry())
                .Throws(new ApiClientException("test message"));

            var controller = new DownloadController(reportService.Object);
            var result = controller.GetXmlForRegion(null);

            Assert.IsInstanceOf<EmptyResult>(result);
        }
    }
}
