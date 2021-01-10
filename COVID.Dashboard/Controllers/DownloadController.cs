using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using COVID.Dashboard.Buisness.Implementation;
using COVID.Dashboard.Buisness.Interface;
using COVID.Dashboard.Models.Auxiliary;
using COVID.Dashboard.Models.DTO;

namespace COVID.Dashboard.Controllers
{
    public class DownloadController : Controller
    {
        private readonly IReportService _reportService;
        private const string fileNameForCountry = "CasesByCountry";
        private const string fileNameForProvince = "CasesByCountryProvidence";

        public DownloadController(IReportService reportService)
        {
            _reportService = reportService;
        }
        // GET: Download

        [HttpGet]
        public ActionResult GetJsonFileForRegion(string iso)
        {
            var content = new MemoryStream();
            var filename = "";

            if (string.IsNullOrEmpty(iso))
            {
                var dataDictionary = _reportService.GetTop10RegionsMostCovidCases();
                var newDataDictionay = dataDictionary
                    .ToDictionary(x => x.Key.RegionName, x => x.Value);
                var bytes = FormatingService.GeJsonBytes(newDataDictionay);
                content = new MemoryStream(bytes);
                filename = fileNameForCountry;
            }
            else
            {
                var dataDictionary = _reportService.GetTop10CovidCasesProvincesByRegion(iso);
                var newDataDictionary = dataDictionary
                    .ToDictionary(x => x.Key.Province, x => x.Value);
                var bytes = FormatingService.GeJsonBytes(newDataDictionary);
                content = new MemoryStream(bytes);
                filename = fileNameForProvince;
            }

            return File(content, "application/json", $"{filename}.json");
        }

        [HttpGet]
        public ActionResult GetCvsForRegion(string iso)
        {
            var bytes = new byte[0];
            var filename = "";

            if (string.IsNullOrEmpty(iso))
            {
                var dataDictionary = _reportService.GetTop10RegionsMostCovidCases();
                var newDataDictionay = dataDictionary
                    .ToDictionary(x => x.Key.RegionName, x => x.Value);
                bytes = FormatingService.GetCvsBytes(newDataDictionay);
                filename = fileNameForCountry;
            }
            else
            {
                var dataDictionary = _reportService.GetTop10CovidCasesProvincesByRegion(iso);
                var newDataDictionary = dataDictionary
                    .ToDictionary(x => x.Key.Province, x => x.Value);
                bytes = FormatingService.GetCvsBytes(newDataDictionary);
                filename = fileNameForProvince;
            }

            return File(bytes, "text/csv", $"{filename}.csv");
        }

        [HttpGet]
        public ActionResult GetXmlForRegion(string iso)
        {
            var bytes = new byte[0];
            var filename = "";

            if (string.IsNullOrEmpty(iso))
            {
                var dataDictionary = _reportService.GetTop10RegionsMostCovidCases()
                    .ToDictionary(x => x.Key.RegionName, x => x.Value); ;
                bytes = FormatingService.GetXmlBytes(dataDictionary, "Cases");
                filename = fileNameForCountry;
            }
            else
            {
                var dataDictionary = _reportService.GetTop10CovidCasesProvincesByRegion(iso)
                    .ToDictionary(x => x.Key.Province, x => x.Value);
                bytes = FormatingService.GetXmlBytes(dataDictionary, "Cases");
                filename = fileNameForProvince;
            }
            return File(bytes, "application/xml", $"{filename}.xml");
        }
    }
}
