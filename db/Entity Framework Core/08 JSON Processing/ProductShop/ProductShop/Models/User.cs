using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
 public   class User
    {
        public User()
        {
            this.SoldProducts = new HashSet<Product>();
          this.BuyedProducts = new HashSet<Product>();
        }
      
        public int Id { get; set; }
        public string  FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public int? age { get; set; }


     [InverseProperty("Seller")]
        public virtual ICollection<Product> SoldProducts { get; set; }

     [InverseProperty("Buyer")]
   public virtual ICollection<Product> BuyedProducts { get; set; }
    }
}
