using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Repositories
{
    public class SupplierRepository : IRepository<Supplier>
    {
        private readonly ApplicationDbContext dbContext;

        public SupplierRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Supplier Add(Supplier entity)
        {
            dbContext.Add(entity);
            dbContext.SaveChanges();
            return entity;
        }

        public Supplier Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Supplier> GetAll()
        {
            throw new NotImplementedException();
        }

        public Supplier GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool IsEmpty()
        {
            return dbContext.Suppliers.Count<Supplier>() == 0;
        }

        public Supplier Update(Supplier entity)
        {
            throw new NotImplementedException();
        }
    }
}
