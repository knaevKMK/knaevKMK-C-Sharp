using BattleCards_App.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleCards_App.Data
{
    public class AppDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public AppDbContext( DbContextOptions options) : base(options)
        {
        }

    //    public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<UserCard> UserCards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>();

            modelBuilder.Entity<Card>();
            
            modelBuilder.Entity<UserCard>(entity=> {
                entity.HasKey(e => new { e.CardId, e.UserId });
                                            });
            
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
