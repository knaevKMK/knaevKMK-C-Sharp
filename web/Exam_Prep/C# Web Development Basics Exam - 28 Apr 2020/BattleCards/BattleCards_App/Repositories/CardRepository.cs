using BattleCards_App.Data;
using BattleCards_App.Dto;
using BattleCards_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleCards_App.Repositories
{
    public class CardRepository : BaseRepository<Card, AppDbContext>
    {
        public CardRepository(AppDbContext ctx) : base(ctx)
        {
        }
         public Card Add(Card card,User user) 
        {
            _ctx.Cards.Add(card);
            _ctx.SaveChanges();
        
            UserCard userCards = new UserCard() {Card=card,User=user };
;           _ctx.UserCards.Add(userCards);
            _ctx.SaveChanges();

            return card;
        }
        internal ICollection<CardVM> GetAll()
        {
            return _ctx.Cards
                .Select(uc => new CardVM()
            {
                Id = uc.Id,
                Name = uc.Name,
                ImageUrl = uc.ImageUrl,
                Keyword = uc.Keyword,
                Healt = uc.Healt,
                Attack = uc.Attack,
                Description = uc.Description
            })
                     .ToList();
        }
        internal ICollection<CardVM> GetAllByUserName(string userId)
        {
            List<string> ids = _ctx.UserCards.ToList()
               .Where(uc => uc.UserId == userId).ToList()
                .Select(uc =>
          uc.CardId)
                .ToList();

            return _ctx.Cards
                .Where(c => ids.Contains(c.Id))
                .Select(uc=>new CardVM() {
                    Id = uc.Id,
                    Name = uc.Name,
                    ImageUrl = uc.ImageUrl,
                    Keyword = uc.Keyword,
                    Healt = uc.Healt,
                    Attack = uc.Attack,
                    Description = uc.Description
                }
                                ).ToList();
        }

        internal void RemoveFromCollection(string cardId, string userId)
        {

            UserCard _userCards = _ctx.UserCards.FirstOrDefault(e => e.CardId == cardId && e.UserId == userId);
            _ctx.UserCards.Remove(_userCards);
            _ctx.SaveChanges();

        }

        internal void AddCardToCollection(string cardId, string userId)
        {
            _ctx.UserCards.Add(new UserCard() { CardId= cardId,UserId=userId});
            _ctx.SaveChanges();
        }
    }
}
