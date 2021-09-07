using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleCards_App.Models
{
    public class UserCard
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public string CardId { get; set; }
        public Card Card { get; set; }

    }
}
