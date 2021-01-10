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
        public Dictionary<string, CasesDeathModel> Top10RegionsData { get; set; }

        public List<SelectListItem> OptionsList { get; set; }
        public string IsoCode { get; set; }
    }
}