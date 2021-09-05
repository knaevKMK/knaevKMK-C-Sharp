using GitApp.Data;
using GitApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitApp.Repositories
{
    public class CommitRepository : BaseRepository<Commit, GitDbContext>
    {
        public CommitRepository(GitDbContext ctx) : base(ctx)
        {
        }


        override public  ICollection<Commit> All() {

            return ctx.Commits
              //  .Where(c=> c.Creator== )
                .ToList();

        }

    }
}
