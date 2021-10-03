using BookLibrary_v1._1._1.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary_v1._1._1.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext( DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}
