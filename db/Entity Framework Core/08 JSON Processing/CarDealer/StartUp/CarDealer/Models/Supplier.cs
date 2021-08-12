using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable
namespace CarDealer.Models
{
   public class Supplier
    {
        public Supplier()
        {
            this.Parts = new HashSet<Part>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsImpoerter { get; set; }
        public ICollection<Part> Parts { get; set; }
    }
}
