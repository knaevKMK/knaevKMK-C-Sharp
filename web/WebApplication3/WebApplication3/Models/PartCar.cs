using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class PartCar
    {
        public int CarId { get; set; }
        public int PartId { get; set; }
        public Car Car { get; set; }
        public Part Part { get; set; }
    }
}
