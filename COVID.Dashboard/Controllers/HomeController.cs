using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using COVID.Dashboard.ApiClient;
using COVID.Dashboard.ApiClient.Interface;

namespace COVID.Dashboard.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApiClient _apiClient;

        public HomeController(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public ActionResult Index()
        {
            return View();
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