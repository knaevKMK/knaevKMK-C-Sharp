using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BattleCards_App.Models
{
    public class Card
    {
        public Card()
        {
            UserCards = new HashSet<UserCard>();
        }

        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [MaxLength(15)]
        public string Name { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string Keyword { get; set; }
        [Required]

        public int Attack { get; set; }
        [Required]
        public int Healt { get; set; }
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        public virtual ICollection<UserCard> UserCards { get; set; }
    }
}
