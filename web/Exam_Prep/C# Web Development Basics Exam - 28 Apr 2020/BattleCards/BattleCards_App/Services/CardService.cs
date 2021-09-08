using BattleCards_App.Dto;
using BattleCards_App.Models;
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

            return _cardRepository.GetAll();

        }
        internal ICollection<CardVM> GetAllCards(string userName)
        {
         

            return _cardRepository.GetAllByUserName(userName);

        }

        internal void CreateCard(CardVM card,User user)
        {

            Models.Card _card = new Models.Card() {
            Name=card.Name,
            Keyword=card.Keyword,
            Attack=card.Attack,
            Healt=card.Healt,
            ImageUrl=card.ImageUrl,
            Description=card.Description
            };

            _cardRepository.Add(_card, user);
            

           
        }

        internal void AddToCollection(string cardId, string userId)
        {
          
            _cardRepository.AddCardToCollection(cardId, userId);
        }

        internal void RemoveFromCollection(string cardId, string userId)
        {
            _cardRepository.RemoveFromCollection(cardId, userId);
        }
    }
}
