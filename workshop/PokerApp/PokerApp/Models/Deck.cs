using PokerApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokerApp.Models
{
    public class Deck
    {
        public Deck()
        {
           this._CreateNewDeck();
        }

        private void  _CreateNewDeck()
        {
            for (int suit = 1; suit <= 4; suit++)
            {
                for (int value = 1; value <= 13; value++)
                {
                    Card _card = new Card() { Suit = (Suit)suit, Value = (Value)value };

                    _Deck.Add(_card);
                }
            }

        }

        public virtual List<Card> _Deck { get; set; }
        public virtual List<int> OutCards { get; set; } = new List<int>();

        public virtual List<Card> PlayerCards { get; set; } = new List<Card>();

        public List<Card> Dealing(bool first) {
            return first ? FirstDeal() : SecondDeal();
        }

        private List<Card> SecondDeal()
        {
            PlayerCards = PlayerCards
                   .Where(c => !c.IsHold)
                   .Select(c => {
                       int index = RandomGenerator.GetRanodom(52, OutCards);
                       OutCards.Add(index);
                       Card card = _Deck.ElementAt(index);
                       _Deck.RemoveAt(index);
                       return card;
                   })
                   .ToList();

                  return PlayerCards;
        }

        private List<Card> FirstDeal()
        {
            for (int i = 0; i < 5; i++)
            {
                int index = RandomGenerator.GetRanodom(52, OutCards);
                OutCards.Add(index);
                PlayerCards.Add(_Deck.ElementAt(index));
                _Deck.RemoveAt(index);
            }
            return PlayerCards;
        }
    }
}
