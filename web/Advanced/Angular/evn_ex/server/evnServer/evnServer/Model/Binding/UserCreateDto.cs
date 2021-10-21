
namespace evnServer.Model.Binding
{
using System;
    using System.ComponentModel.DataAnnotations;
    public class UserCreateDto
    {
        [Required(ErrorMessage = "Names are required")]
        [StringLength(45, ErrorMessage = "Names max lenght is 45 chars")]
        public string FullName { get; set; }


        [Required(ErrorMessage = "Department Name is required.")]
        public string DepartmentName { get; set; }

        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "Edication required")]
        [StringLength(20, ErrorMessage = "Education max lenght is 20 chars")]
        public string Education { get; set; }

        [Range(0, 10, ErrorMessage = "Score must be positive with max value 10")]
        public int Score { get; set; }
    }
}
