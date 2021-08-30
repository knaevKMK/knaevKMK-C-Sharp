using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models.Enum;

namespace WebApplication3.Models
{
    public class Car
    {

        public int Id { get; set; }

        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
        
        public int ModelId { get; set; }
        public Model Model { get; set; }

        public EngineEnum Engine { get; set; }
        public TransmisionEnum Transmision { get; set; }
        public TypeCabinEnum type { get; set; }

        public DateTime RegisterOn { get; set; }

        public string ImageUrl { get; set; }
    }
}
