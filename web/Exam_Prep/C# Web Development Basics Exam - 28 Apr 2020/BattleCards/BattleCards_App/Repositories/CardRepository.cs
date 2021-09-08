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

        internal ICollection<CardVM> GetAllByUserName(string userName)
        {
            List<UserCard> userCards = _ctx.UserCards.ToList();
            if (userName != null)
            { userCards = userCards
               .Where(uc => uc.User.UserName == userName).ToList();
            }    
       return userCards.Select(uc => new CardVM() {
           Id=uc.CardId,
           Name= uc.Card.Name,
           ImageUrl= uc.Card.ImageUrl,
           Keyword= uc.Card.Keyword,
           Healt= uc.Card.Healt,
           Attack=uc.Card.Attack,
           Description= uc.Card.Description
                 })
                .ToList();
        }
    }
}
