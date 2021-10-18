using ex.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ex.Models.Binding
{
    public class UserAddDto
    {
        [Required(ErrorMessage = "Names are required")]
        [StringLength( 45, ErrorMessage ="Names max lenght is 45 chars")]
        public string FullName { get; set; }


        [Required(ErrorMessage = "Department is required.")]
        public DepartmentEnum Department { get; set; }
        
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "Edication required")]
        [StringLength(20, ErrorMessage ="Education max lenght is 20 chars")]
        public string Education { get; set; }

        [Range(0, 10, ErrorMessage = "Score must be positive with max value 10")]
        public int Score { get; set; }
    }
}
