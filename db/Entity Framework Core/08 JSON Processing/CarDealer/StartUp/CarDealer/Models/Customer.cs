using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable
namespace CarDealer.Models
{
  public  class Customer
    {
        public Customer()
        {
            this.Sales = new HashSet<Sale>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirhtDate { get; set; }
        public bool IsYoungDriver { get; set; }
        public ICollection<Sale> Sales { get; set; }
    }
}
