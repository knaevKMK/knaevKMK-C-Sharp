using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



#nullable disable
namespace ef_intro_code_first.Model
{
    class Department
    {

        public Department()
        {

        }
        [Key]
        [Column("DepartmentId")]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Column("ManagerID")]
        public int ManagerId { get; set; }


        [ForeignKey(nameof(ManagerId))]
        [InverseProperty(nameof(Employee.Departments))]
        public virtual Employee Manager { get; set; }


        [InverseProperty(nameof(Employee.Department))]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
