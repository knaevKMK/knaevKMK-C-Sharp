using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Views.ExportDto
{
    public class CarExportDto
    {

       
        public string Manufacturer { get; set; }
        public string Model { get; set; }

        public string Engine { get; set; }
        public string Transmision { get; set; }
        public string type { get; set; }

        public DateTime RegisterOn { get; set; }

        public string ImageUrl { get; set; }
    }
}
