using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Manufacturer
    {
        public Manufacturer()
        {
           this.Models = new HashSet<Model>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

       
        public virtual ICollection<Model> Models { get; set; }
       
       
    }
}
