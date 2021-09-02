using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Repositories
{
    public class PartRepository : IRepository<Part> //BaseRepository<Part, ApplicationDbContext>
    {
        private readonly ApplicationDbContext ctx;

        public PartRepository(ApplicationDbContext ctx)
        {
            this.ctx = ctx;
        }

        public Part Add(Part entity)
        {
       ctx.Parts.Add(entity);
            ctx.SaveChanges();

            return entity;
        }

        public Part Delete(int id)
        {
            Part part = GetById(id);
            ctx.Parts.Remove(part);
            ctx.SaveChanges();
            return part;
        }

        public List<Part> GetAll()
        {
            return ctx.Parts.ToList();
        }

        public Part GetById(int id)
        {
            return ctx.Parts.Find(id);
        }

        public bool IsEmpty()
        {
            return ctx.Parts.Count<Part>() == 0;
        }

        public Part Update(Part entity)
        {
            ctx.Entry(entity).State = EntityState.Modified;
            ctx.SaveChanges();

            return entity;
        }
    }
}
