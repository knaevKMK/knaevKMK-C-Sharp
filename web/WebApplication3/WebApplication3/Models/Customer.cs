using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Customer: IEntity
    {

        public Customer()
        {
            Sales = new HashSet<Sale>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BrthDate { get; set; }
        public bool IsYongDriver { get; set; }
        public virtual ICollection<Sale>    Sales { get; set; }
    }
}
