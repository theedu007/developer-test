using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID.Dashboard.Models.DTO
{
    public class RegionDTO
    {
        public string Iso { get; set; }
        public string Name { get; set; }
        public string Province { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
    }
}
