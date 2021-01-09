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

        public DownloadController(IReportService reportService)
        {
            _reportService = reportService;
        }
        // GET: Download

        [HttpGet]
        public ActionResult GetJsonFileForRegion()
        {
            var dataDictionary = _reportService.GetTop10RegionsMostCovidCases();
            var newDataDictionay = dataDictionary
                .ToDictionary(x => x.Key.RegionName, x => x.Value);
            var bytes = FormatingService.GeJsonBytes(newDataDictionay);
            var content = new MemoryStream(bytes);

            return File(content, "application/json", "CovidCasesByRegion.json");
        }

        [HttpGet]
        public ActionResult GetCvsForRegion()
        {
            var dataDictionary = _reportService.GetTop10RegionsMostCovidCases();
            var newDataDictionay = dataDictionary
                .ToDictionary(x => x.Key.RegionName, x => x.Value);
            var bytes = FormatingService.GetCvsBytes(newDataDictionay);

            return File(bytes, "text/csv", "CovidCasesByRegion.csv");
        }

        [HttpGet]
        public ActionResult GetXmlForRegion()
        {
            var dataDictionary = _reportService.GetTop10RegionsMostCovidCases()
                .ToDictionary(x => x.Key.RegionName, x => x.Value); ;
            var bytes = FormatingService.GetXmlBytes(dataDictionary, "Cases");

            return File(bytes, "application/xml", "CovidCasesByRegion.xml");
        }
    }
}
