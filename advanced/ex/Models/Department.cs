
namespace ex.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class Department
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0,10)]
        public int Code { get; set; }
        public IEnumerable<User> Candidates { get; set; } = new HashSet<User>();
    }
}
