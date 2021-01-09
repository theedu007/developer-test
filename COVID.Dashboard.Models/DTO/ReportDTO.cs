using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID.Dashboard.Models.DTO
{
    public class ReportDTO
    {
        public string Date { get; set; }
        public int Confirmed { get; set; }
        public int Deaths { get; set; }
        public int Recovered { get; set; }
        public int Confirmed_Diff { get; set; }
        public int Deaths_Diff { get; set; }
        public int recovered_diff { get; set; }
        public string Last_Update { get; set; }
        public int Active { get; set; }
        public int Active_Diff { get; set; }
        public decimal Fatality_Rate { get; set; }

        public RegionDTO Region { get; set; }
    }
}
