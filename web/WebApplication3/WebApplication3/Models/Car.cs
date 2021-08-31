using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Models
{
    public class Car
    {

        public int Id { get; set; }

        public int ModelId { get; set; }
        public Model Model { get; set; }

        [ForeignKey("Engine")]
        public int EngineId { get; set; }
        public Engine Engine { get; set; }
        [ForeignKey("Transmision")]
        public int TransmisionId { get; set; }
        public Transmision Transmision { get; set; }
        [ForeignKey("TypeCabin")]
        public int TypeCabinId { get; set; }
        public TypeCabin TypeCabin { get; set; }

        public DateTime RegisterOn { get; set; }

        public string ImageUrl { get; set; }
    }
}
