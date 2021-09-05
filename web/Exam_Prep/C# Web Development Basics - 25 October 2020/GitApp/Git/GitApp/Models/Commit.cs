using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GitApp.Models
{
    public class Commit
    {
        public int Id { get; set; }

        // text field
        public string Description { get; set; }
        public DateTime CreateOn { get; set; }


        [ForeignKey("Creator")]
        public int? CreatorId { get; set; }
        public User Creator { get; set; }
        [ForeignKey("Repository")]
        public int? RepositoryId { get; set; }
        public Repository Repository { get; set; }
    }
}
