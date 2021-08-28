using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TeisterMask.Data.Models.Enums;

namespace TeisterMask.Data.Models
{
 public  class Task
    {
        public Task()
        {
            this.EmployeeTasks = new HashSet<EmployeeTasks>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime OpenDate { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        public ExecutionType ExecutionType { get; set; }
        public LabelType LabelType { get; set; }

        [Required]
        [ForeignKey("Project")]
        public int? ProjectId { get; set; }
        public virtual Project Propject { get; set; }
        
        public virtual ICollection<EmployeeTasks> EmployeeTasks { get; set; }
    }
}
