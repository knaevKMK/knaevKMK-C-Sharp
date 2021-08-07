using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ef_intro_code_first.Model
{
    class Employee
    {
        public Employee()
        {
            Departments = new HashSet<Department>();
            EmployeesProjects = new HashSet<EmployeesProjects>();
            InverseManager = new HashSet<Employee>();
        }
        [Key]
        [Column("EmployeeId")]
        public int Id { get; set; }
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
        [Column("DeaprtmentID")]
        public int DepartmentId { get; set; }
        [Column("ManagerID")]
        public int ManagerId { get; set; }
        [Column(TypeName = "smaldatetime")]
        public DateTime HireDate { get; set; }
        [Column(TypeName = "decimal(15,4)")]
        public decimal Salary { get; set; }
        [Column("AddressID")]
        public int AddressId { get; set; }


        [ForeignKey(nameof(AddressId))]
        [InverseProperty("Employees")]
        public virtual Address Address { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty("Employees")]
        public virtual Department Department { get; set; }

        [ForeignKey(nameof(ManagerId))]
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
