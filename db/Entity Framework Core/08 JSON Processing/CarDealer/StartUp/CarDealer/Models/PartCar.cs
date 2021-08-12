using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable
namespace CarDealer.Models
{
   public class PartCar
    {

        public int PartId { get; set; }
        public Part Part { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
