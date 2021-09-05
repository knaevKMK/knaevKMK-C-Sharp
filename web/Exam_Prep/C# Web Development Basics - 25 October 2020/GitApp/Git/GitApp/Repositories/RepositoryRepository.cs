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
        public RepositoryRepository(DbContext ctx) : base(ctx)
        {
        }
    }
}
