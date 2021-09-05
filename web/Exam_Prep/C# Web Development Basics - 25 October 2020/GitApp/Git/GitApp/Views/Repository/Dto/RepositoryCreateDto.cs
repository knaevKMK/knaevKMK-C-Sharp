using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GitApp.Views.Repository.Dto
{
    public class RepositoryCreateDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string Name { get; set; }
       
        [Required]
        [EnumDataType(typeof(Type))]
        public Type Type { get; set; }
    }
}
