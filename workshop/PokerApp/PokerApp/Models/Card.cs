using PokerApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokerApp.Models
{
    public class Card
    {

        public Suit  Suit { get; set; }
        public Value Value { get; set; }
        public bool IsHold { get; set; } = false;
        public bool IsWinner { get; set; }
    }
}
