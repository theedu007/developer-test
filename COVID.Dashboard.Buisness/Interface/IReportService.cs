using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COVID.Dashboard.Models.Auxiliary;
using COVID.Dashboard.Models.DTO;

namespace COVID.Dashboard.Buisness.Interface
{
    public interface IReportService
    {
        Dictionary<IsoRegionModel, CasesDeathModel> GetTop10RegionsMostCovidCases();
    }
}
