using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

#nullable disable
namespace ef_intro_code_first.Model
{
    class EmployeesProjects
    {
       
        [Key]
        [Column("EmployeeID")]
        public int EmployeeID { get; set; }
        [Key]
        [Column("ProjectID")]
        public int ProjectID { get; set; }

        [ForeignKey(nameof(EmployeeID))]
        [InverseProperty("EmployeesProjects")]
        public virtual Employee Employee { get; set; }


        [ForeignKey(nameof(ProjectID))]
        [InverseProperty("EmployeesProjects")]
        public  virtual Project Project { get; set; }
    }
}
