using BattleCards_App.Dto;
using BattleCards_App.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleCards_App.Services
{
    public class CardService

           {
        private readonly CardRepository _cardRepository;

        public CardService(CardRepository cardRepository )
        {
            _cardRepository = cardRepository;
          
        }
        internal ICollection<CardVM> GetAllCards()
        {

            return _cardRepository.GetAllByUserName(null);

        }
        internal ICollection<CardVM> GetAllCards(string userName)
        {
         

            return _cardRepository.GetAllByUserName(userName);

        }

       
    }
}
