using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Views.ImportDto
{
    public class CarImportDto
    {
        [Required(ErrorMessage ="Field is required")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Field is required")]
        public string Manufaturer { get; set; }
        [Required(ErrorMessage = "Field is required")]
        public string Engine { get; set; }
        [Required(ErrorMessage = "Field is required")]
        public string Transmision { get; set; }
        [Required(ErrorMessage = "Field is required")]
        public string CabinType { get; set; }
        [Required(ErrorMessage = "Field is required")]
        public string ImageUrl { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
