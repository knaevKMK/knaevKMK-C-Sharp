using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BattleCards_App.Models
{
    public class User: IEntity
    {
        public User()
        {
            UserCards = new HashSet<UserCard>();
        }
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [MaxLength(20)]
        public string Username { get; set; }
        [Required]
            public string Email { get; set; }
        [Required]
    [MaxLength(20)]
        public string Password { get; set; }

        public virtual ICollection<UserCard> UserCards { get; set; }

    }
}
