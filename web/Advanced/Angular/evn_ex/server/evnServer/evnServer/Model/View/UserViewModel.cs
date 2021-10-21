
namespace evnServer.Model.View
{
using System;
    public class UserViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string DepartmentName { get; set; }
        public string Code { get; set; }
        public string Education { get; set; }
        public DateTime BirthDate { get; set; }
        public int Score { get; set; }
    }
}
