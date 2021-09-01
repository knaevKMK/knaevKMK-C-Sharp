using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Car: IEntity
    {
        public Car()
        {
            Sales = new HashSet<Sale>();
            PartCars = new HashSet<PartCar>();
        }
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public long TravelledDistance { get; set; }
        public virtual ICollection<PartCar> PartCars { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }

    }
}
