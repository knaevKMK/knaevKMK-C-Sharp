using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GitApp.Views.Repository.Dto
{
    public class RepositoryListOutDto
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public DateTime CreateOn { get; set; }
        public int CommitCount { get; set; }
    }
}
