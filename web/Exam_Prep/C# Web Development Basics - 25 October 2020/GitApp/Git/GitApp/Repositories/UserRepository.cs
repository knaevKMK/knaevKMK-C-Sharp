using GitApp.Data;
using GitApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitApp.Repositories
{
    public class UserRepository : BaseRepository<User, GitDbContext>
    {
        public readonly GitDbContext ctx;
        public UserRepository(DbContext ctx) : base(ctx)
        {
            this.ctx = new GitDbContext();
        }
        public User GetUserByUsername(string username, string password) {
        return ctx.Users.First(u=>u.Username==username && u.Password==password);
        }
        public User GetUserByUsername(string username)
        {
            return ctx.Users.First(u => u.Username == username);
        }
    }
}
