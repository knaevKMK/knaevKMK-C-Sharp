using PokerApp.Data;
using PokerApp.Models;
using PokerApp.ModelsView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokerApp.Services
{
    public class GameService
    {
        private readonly ApplicaitonDbContext _db;

        private Game _game= new Game() ;
          private  const int CardsCount = 5;
        public GameService(ApplicaitonDbContext db)
        {
            _db = db;
        }

        internal GameVM Play(GameVM game)
        {
           
            // TODO db total credit and bet count
            //and logs for all payments

            // equal credit in db with vm.credit
            int win = 0;
            List<Card> cards = _game.Deck.Dealing(game.IsFirstDeal).ToList();


            //ToDo in client app only
            //low-down credit with bet value
            _game.Credit = _game.Credit - game.Bet;

            if (!game.IsFirstDeal)
            {
                //todO  GET WIn combination.class
                // get pay table.class
                       win = 50;
            }
           
            return new GameVM()
            {
                Bet = game.Bet,
                PlayerCards= cards,
                Credit = (int)(_game.Credit) /100,
                IsFirstDeal = false,
                Win = win,
            };

        }

      
    }
}
