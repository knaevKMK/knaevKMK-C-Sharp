using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GitApp.Views.Commit.Dto
{
    public class CommitCreateDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        public string Description { get; set; }

        public string Name { get; set; }

    }
}
