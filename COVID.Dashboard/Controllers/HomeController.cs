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
            var viewData = _reportService.GetTop10RegionsMostCovidCases();
            return View(new CovidDataViewModel() {Top10RegionsData = viewData});
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}