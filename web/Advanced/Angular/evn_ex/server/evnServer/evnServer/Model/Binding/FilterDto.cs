

using evnServer.Model.Enums;

namespace evnServer.Model.Binding
{
    public class FilterDto
    {

        public byte? IdSort { get; set; }
        public string Name { get; set; }
        public byte? NameSort { get; set; }
        public string Department { get; set; }
        public byte? DepartmentSort { get; set; }
        public string Education { get; set; }
        public byte? EducationSort { get; set; }
        public int? Score { get; set; }
        public byte? ArrowScore { get; set; }
        public byte? ScoreSort { get; set; }

        public int? BirthYaer { get; set; }
        public byte? ArrowBirth { get; set; }
        public byte? BirthYearSort { get; set; }
    }
}
