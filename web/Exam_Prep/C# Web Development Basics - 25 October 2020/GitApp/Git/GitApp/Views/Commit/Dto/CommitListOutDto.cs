using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GitApp.Views.Commit.Dto
{
    public class CommitListOutDto
    {
        [Key]
        public int Id { get; set; }
        public string Repository { get; set; }
        public string Description { get; set; }
        public DateTime CreateOn { get; set; }

    }
}
