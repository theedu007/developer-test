using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COVID.Dashboard.Models.DTO;

namespace COVID.Dashboard.Buisness.Interface
{
    public interface IReportService
    {
        List<ReportDTO> GetTop10RegionsMostCovidCases();
    }
}
