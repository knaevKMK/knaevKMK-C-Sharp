using BattleCards_App.Data;
using BattleCards_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleCards_App.Repositories
{
    public class UsersRepository : BaseRepository<User, AppDbContext>
    {
        public UsersRepository(AppDbContext ctx) : base(ctx)
        {
        }

        internal User GetByUsernameAndPassword(string username, string password)
        {
            return _ctx.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        internal User GetByUsername(string username)
        {
            return _ctx.Users.FirstOrDefault(u => u.Username == username);
        }

        internal object GetByEmail(string email)
        {
            return _ctx.Users.FirstOrDefault(u=>u.Email==email);
        }
    }
}
