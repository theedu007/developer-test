using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using COVID.Dashboard.ApiClient;
using COVID.Dashboard.ApiClient.Interface;
using COVID.Dashboard.Buisness.Interface;
using COVID.Dashboard.Models;

namespace COVID.Dashboard.Controllers
{
    public class HomeController : Controller
    {
        private readonly IReportService _reportService;

        public HomeController(IReportService reportService)
        {
            _reportService = reportService;
        }

        public ActionResult Index()
        {
            var model = new CovidDataViewModel();
            var viewData = _reportService.GetTop10RegionsMostCovidCases();

            model.Top10RegionsData = viewData.ToDictionary(x => x.Key.RegionName, x => x.Value);
            model.OptionsList = viewData
                .Select(x => new SelectListItem() {Value = x.Key.Iso, Text = x.Key.RegionName})
                .ToList(); 
            return View(model);
        }

        [HttpGet]
        public ActionResult GetDashboardByProvincePartialView(string iso)
        {
            var viewData = _reportService.GetTop10CovidCasesProvincesByRegion(iso);
            var model = new CovidDataViewModel();
            model.Top10RegionsData = viewData.ToDictionary(x => x.Key.Province, x => x.Value);
            return PartialView("TableDashboard", model);
        }
    }
}