using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
#nullable disable
namespace ef_intro_code_first.Model
{
    public class Employee
    {
        public Employee()
        {
            Departments = new HashSet<Department>();
            EmployeesProjects = new HashSet<EmployeesProjects>();
            InverseManager = new HashSet<Employee>();
        }
        [Key]
        [Column("EmployeeID")]
        public int EmployeeID { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string MiddleName { get; set; }
        [Required]
        [StringLength(50)]
        public string JobTitle { get; set; }
        [Column("DepartmentID")]
        public int DepartmentID { get; set; }
        [Column("ManagerID")]
        public int ManagerID { get; set; }
        [Column(TypeName = "smaldatetime")]
        public DateTime HireDate { get; set; }
        [Column(TypeName = "decimal(15,4)")]
        public decimal Salary { get; set; }
        [Column("AddressID")]
        public int? AddressID { get; set; }


        [ForeignKey(nameof(AddressID))]
        [InverseProperty("Employees")]
        public virtual Address Address { get; set; }

        [ForeignKey(nameof(DepartmentID))]
        [InverseProperty("Employees")]
        public virtual Department Department { get; set; }

        [ForeignKey(nameof(ManagerID))]
        [InverseProperty(nameof(Employee.InverseManager))]
        public virtual Employee Manager { get; set; }



        [InverseProperty("Manager")]
        public virtual ICollection<Department> Departments { get; set; }
        
        [InverseProperty(nameof(Model.EmployeesProjects.Employee))]
        public virtual ICollection<EmployeesProjects> EmployeesProjects { get; set; }


        [InverseProperty(nameof(Employee.Manager))]
        public virtual ICollection<Employee> InverseManager { get; set; }
    }
}
