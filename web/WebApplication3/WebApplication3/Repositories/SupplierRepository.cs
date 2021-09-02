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
            Supplier supplier = GetById(id);

            dbContext.Suppliers.Remove(supplier);
            dbContext.SaveChanges();

            return supplier;
        }

        public List<Supplier> GetAll()
        {
            return dbContext.Suppliers.ToList();
        }

        public Supplier GetById(int id)
        {
            return dbContext.Suppliers.Find(id);
        }

        public bool IsEmpty()
        {
            return dbContext.Suppliers.Count<Supplier>() == 0;
        }

        public Supplier Update(Supplier entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            dbContext.SaveChanges();

            return entity;
        }
    }
}
