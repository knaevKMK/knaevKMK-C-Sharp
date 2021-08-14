using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable
namespace Models.Entities
{
 public   class Part
    {

        public Part()
        {
            this.Cars = new HashSet<Car>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int? SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
