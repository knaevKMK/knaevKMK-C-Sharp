


namespace evnServer.Model.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Names are required")]
        [StringLength(45)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Code required")]
        [StringLength(11)]
        public string Code { get; set; }

        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "Edication required")]
        [StringLength(20)]
        public string Education { get; set; }

        [Range(0, 10, ErrorMessage = "Score must be positive with max value 10")]
        public int Score { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
