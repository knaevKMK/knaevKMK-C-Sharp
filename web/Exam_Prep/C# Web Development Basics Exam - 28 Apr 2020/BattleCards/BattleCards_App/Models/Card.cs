using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BattleCards_App.Constants;

namespace BattleCards_App.Models
{
        using static FieldConstatnts;
    public class Card
    {
        public Card()
        {
            UserCards = new HashSet<UserCard>();
        }
        [Key]
        [MaxLength(KEY_MAX_LENGHT)]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [MinLength(CARD_NAME_MIN_LENGHT)]
        [MaxLength(CARD_NAME_MAX_LENGHT)]
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
