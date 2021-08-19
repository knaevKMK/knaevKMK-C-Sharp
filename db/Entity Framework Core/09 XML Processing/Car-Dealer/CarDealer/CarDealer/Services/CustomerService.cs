using CarDealer.Data;
using CarDealer.DtoImport;
using CarDealer.Models;
using CarDealer.Static;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CarDealer.Services
{
  public  class CustomerService
    {
      private static  ApplicationDbContext dbctx = new ApplicationDbContext();

        public string importFromXml()
        {
            if (dbctx.Customers.Count<Customer>() >0)
            {
                return "Customer db is not empty";
            }
            var customers = XDocument
                .Load(Static.Static.READ_DIR_PATH + Static.Static.READ_CUSTOMER_PATH)
                .Root.Elements()
                .Select(e=> new Customer {
                        Name=e.Element("name").Value,
                        BirthDate=DateTime.Parse(e.Element("birthDate").Value),
                        IsYoungDriver=bool.Parse(e.Element("isYoungDriver").Value)
                })
                .ToList();
            dbctx.Customers.AddRange(customers);
            dbctx.SaveChanges();
            return $"Successfully imported {customers.Count}";
        }
    }
}
