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
        public CommitRepository(DbContext ctx) : base(ctx)
        {
        }
    }
}
