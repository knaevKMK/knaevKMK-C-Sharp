using GitApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitApp.Data
{
    public class GitDbContext : DbContext
    {
        public GitDbContext()
        {
                    }
        public GitDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Repository> Repositories { get; set; }
        public DbSet<Commit> Commits { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>(entity=> {
              
                });

                        modelBuilder.Entity<Repository>(entity=> {
                            entity.HasOne(e => e.Owner)
                                .WithMany(p => p.Repositories)
                                .HasForeignKey(e => e.OwnerId)
                                .OnDelete(DeleteBehavior.ClientSetNull);
                        });
            
            modelBuilder.Entity<Commit>(entity=> {

                entity.HasOne(e => e.Repository)
                .WithMany(p => p.Commits)
                .HasForeignKey(e => e.RepositoryId)
                .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(e => e.Creator)
                .WithMany(c => c.Commits)
                .HasForeignKey(e => e.CreatorId)
                .OnDelete(DeleteBehavior.SetNull);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
