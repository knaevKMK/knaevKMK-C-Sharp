using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Supplier: IEntity
    {

        public Supplier()
        {
            Parts = new HashSet<Part>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsImporter { get; set; }
        public virtual ICollection<Part> Parts { get; set; }
    }
}
