using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


#nullable disable
namespace ef_intro_code_first.Model
{
    public class Address
        
    {
        public Address()
        {
            Employees = new HashSet<Employee>();
        }

        [Key]
        [Column("AddressId")]
        public int AddressId { get; set; }


        [Required]
        [StringLength(100)]
        public string AddressText { get; set; }

        [Column("TownID")]
        public int TownID { get; set; }


        [ForeignKey(nameof(TownID))]
        [InverseProperty("Addresses")]
        public Town Town { get; set; }


        [InverseProperty(nameof(Employee.Address))]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
