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
      
        public UserRepository(GitDbContext ctx) : base(ctx)
        {
          
        }
        public User GetUserByUsernameAndPassword(string username, string password)
        {
            try
            {

                return base.ctx.Set<User>().First(u => u.Username == username && u.Password == password);
            }
            catch (Exception)
            {

                return null;
            }
        }
        public User GetUserByUsername(string username)
        {

            try
            {
                return base.ctx.Set<User>().FirstOrDefault(u=>u.Username==username);

            }
            catch (Exception)
            {

                return null;
            }
          
        }
    }
}
