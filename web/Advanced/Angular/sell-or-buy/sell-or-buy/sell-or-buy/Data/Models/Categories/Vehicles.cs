using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sell_or_buy.Data.Models.Categories
{
    public class Vehicles: VehiclesAndParts
    {

        public string Transmision { get; set; }
        public string FuelType { get; set; }
        public string VehclesType { get; set; }
        public int DoorsCount { get; set; }
        public string EmissionClass { get; set; }
        public string VehicleCondition { get; set; }
        public string ExteriorColor { get; set; }
        public string InteriorMaterial { get; set; }
        public string AirConditioner { get; set; }
    }
}
