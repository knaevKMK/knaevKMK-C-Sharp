using GitApp.Data;
using GitApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitApp.Repositories
{
    public class RepositoryRepository : BaseRepository<Repository, GitDbContext>
    {
      //  private readonly GitDbContext ctx;
        public RepositoryRepository(GitDbContext ctx) : base(ctx)
        {
        //    this.ctx = new GitDbContext();
        }

        internal Repository GetByName(string name)
        {
            Repository repository = base.ctx.Set<Repository>().First(r => r.Name == name);
            if (repository==null)
            {
                throw new Exception("Repository with this name does not exist");
            }
            return repository;
        }
    }
}
