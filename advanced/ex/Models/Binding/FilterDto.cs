using ex.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ex.Models.Binding
{
    public class FilterDto
    {


        public byte? IdSort { get; set; }
        public string Name { get; set; }
        public byte? NameSort { get; set; }
        public DepartmentEnum? Department { get; set; }
        public byte? DeprtmentSort { get; set; }
        public string? Education { get; set; }
        public byte? EdicationSort { get; set; }
        public int? Score { get; set; }
        public byte? ScoreSort { get; set; }
        
        public DateTime? BirthDate { get; set; }
        public ArrowEnum? arrow { get; set; }
        public byte? BirthDateSort { get; set; }
    }
}
