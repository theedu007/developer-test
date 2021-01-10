using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using COVID.Dashboard.Models.Auxiliary;

namespace COVID.Dashboard.Models
{
    public class CovidDataViewModel
    {
        public Dictionary<string, CasesDeathModel> Top10RegionsData { get; set; } = new Dictionary<string, CasesDeathModel>();

        public List<SelectListItem> OptionsList { get; set; } = new List<SelectListItem>();
        public string IsoCode { get; set; }
    }
}