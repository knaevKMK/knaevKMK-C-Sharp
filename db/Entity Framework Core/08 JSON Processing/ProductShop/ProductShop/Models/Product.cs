using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Product
    {
        public Product()
        {
            this.Categories = new HashSet<Category>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }

        [Required]
        public int SellerId { get; set; }
        [InverseProperty("SoldProducts")]
        public virtual User Seller { get; set; }


  public int? BuyerId { get; set; }
        [InverseProperty("BuyedProducts")]
        public virtual User Buyer { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
