using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Repositories
{
    public class CustomerRepository : BaseRepository<Sale, ApplicationDbContext>
    {
        public CustomerRepository(DbContext ctx) : base(ctx)
        {
        }
    }
}
