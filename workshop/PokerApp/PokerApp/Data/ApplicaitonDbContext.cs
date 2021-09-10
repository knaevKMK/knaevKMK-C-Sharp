using Microsoft.EntityFrameworkCore;
using PokerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokerApp.Data
{
    public class ApplicaitonDbContext : DbContext
    {
        public ApplicaitonDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Counters> Counters { get; set; }
    }
}
