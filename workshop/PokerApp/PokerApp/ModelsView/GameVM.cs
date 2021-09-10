using PokerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokerApp.ModelsView
{
    public class GameVM
    {
        public int Bet { get; set; }
        public int Win { get; set; }
        public int Credit { get; set; }
        public bool IsFirstDeal { get; set; } = true;
        public List<Card> PlayerCards { get; set; } = new List<Card>();
    }
}
