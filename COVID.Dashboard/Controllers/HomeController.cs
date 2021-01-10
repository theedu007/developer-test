using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using COVID.Dashboard.ApiClient;
using COVID.Dashboard.ApiClient.Exception;
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
            try
            {
                var viewData = _reportService.GetTop10CovidCasesByCountry();

                model.Top10RegionsData = viewData.ToDictionary(x => x.Key.RegionName, x => x.Value);
                model.OptionsList = viewData
                    .Select(x => new SelectListItem() { Value = x.Key.Iso, Text = x.Key.RegionName })
                    .ToList();
                return View(model);
            }
            catch (ApiClientException)
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult GetDashboardByProvincePartialView(string iso)
        {
            var model = new CovidDataViewModel();
            model.IsoCode = iso;

            try
            {
                if (string.IsNullOrEmpty(iso))
                {
                    var viewData = _reportService.GetTop10CovidCasesByCountry();
                    model.Top10RegionsData = viewData.ToDictionary(x => x.Key.RegionName, x => x.Value);
                }
                else
                {
                    var viewData = _reportService.GetTop10CovidCasesByCountryRegions(iso);
                    model.Top10RegionsData = viewData.ToDictionary(x => x.Key.Province, x => x.Value);
                }
                return PartialView("TableDashboard", model);
            }
            catch (ApiClientException)
            {
                return PartialView("TableDashboard", model);
            }
        }
    }
}