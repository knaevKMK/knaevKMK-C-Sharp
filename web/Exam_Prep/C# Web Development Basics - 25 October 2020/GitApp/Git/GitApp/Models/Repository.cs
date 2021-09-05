using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GitApp.Models
{
    public class Repository: IEntity
    {
        public Repository( )
        {
            IsPublc = false;
            Commits = new HashSet<Commit>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateOn { get; set; }
        public bool IsPublc { get; set; }
        [ForeignKey("Owner")]
        public int OwnerId { get; set; }
        public User Owner { get; set; }
        public virtual ICollection<Commit> Commits { get; set; }
    }
}
