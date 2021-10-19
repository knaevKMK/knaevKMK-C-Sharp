

namespace ex.Models.Binding
{
    using ex.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
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
        public byte? arrowScore { get; set; }
        public byte? ScoreSort { get; set; }
        
        public int? BirthYaer { get; set; }
        public byte? arrowBirth { get; set; }
        public byte? BirthYearSort { get; set; }
    }
}
