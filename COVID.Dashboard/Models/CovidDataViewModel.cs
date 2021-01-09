using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using COVID.Dashboard.Models.Auxiliary;

namespace COVID.Dashboard.Models
{
    public class CovidDataViewModel
    {
        public Dictionary<IsoRegionModel, CasesDeathModel> Top10RegionsData;
    }
}