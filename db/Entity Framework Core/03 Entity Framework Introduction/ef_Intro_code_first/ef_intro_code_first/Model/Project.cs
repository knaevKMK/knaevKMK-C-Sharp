using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

#nullable disable
namespace ef_intro_code_first.Model
{
    class Project
    {
        public Project()
        {

        }
        [Key]
        [Column("ProjectID")]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName ="ntext")]
        public string Description { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime StartDate { get; set; }
        [Column(TypeName ="smalldatetime")]
        public DateTime EndDate { get; set; }


        [InverseProperty(nameof(Model.EmployeesProjects.Project))]
        public virtual ICollection<EmployeesProjects> EmployeesProjects { get; set; }
    }
}
