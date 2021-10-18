

using ex.Models.Enums;
using System;

namespace ex.Models.Service
{
    public class UserServiceModel
    {

        public string FullName { get; set; }
        public DepartmentEnum Department { get; set; }
        public string Code { get; set; }
        public string Education { get; set; }
        public DateTime BirthDate { get; set; }
        public int Score { get; set; }
    }
}
