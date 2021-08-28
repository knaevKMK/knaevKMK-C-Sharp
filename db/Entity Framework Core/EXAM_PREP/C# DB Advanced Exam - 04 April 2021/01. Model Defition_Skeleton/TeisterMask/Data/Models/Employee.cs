using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TeisterMask.Data.Models
{
 public   class Employee
    {

        public Employee()
        {
            this.EmployeeTasks = new HashSet<EmployeeTasks>();
        }
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public String Email { get; set; }
        [Required]
        public string Phone { get; set; }

        public virtual ICollection<EmployeeTasks> EmployeeTasks { get; set; }
    }
}
