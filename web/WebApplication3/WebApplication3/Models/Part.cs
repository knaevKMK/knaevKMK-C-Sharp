using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Part: IEntity
    {
        public Part()
        {
            this.PartCars = new HashSet<PartCar>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Prce { get; set; }
        public long Quantty { get; set; }
        public virtual ICollection<PartCar> PartCars { get; set; }
        public int SupplerId { get; set; }
        public Supplier Supplier { get; set; }
    }

}
