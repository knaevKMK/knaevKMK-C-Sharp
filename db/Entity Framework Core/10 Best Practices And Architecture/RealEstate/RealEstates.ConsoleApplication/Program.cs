using System;
using Microsoft.EntityFrameworkCore;
using RealEstate.Data;
namespace RealEstates.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            var db = new ApplicationDBContext();
            db.Database.Migrate();
        }
    }
}
