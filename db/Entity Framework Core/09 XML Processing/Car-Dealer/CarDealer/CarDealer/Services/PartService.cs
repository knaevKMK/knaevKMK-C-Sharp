using CarDealer.Data;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CarDealer.Services
{
    public class PartService
    {
       private static ApplicationDbContext dbctx = new ApplicationDbContext();

        internal string importFromXml()
        {
            if (dbctx.Parts.Count<Part>()>0)
            {
                return "Part DB is not empty";
            }
            var parts = XDocument
                .Load(Static.Static.READ_DIR_PATH + Static.Static.READ_PART_PATH)
                .Root.Elements()
                .Select(e=> new Part { 
                    Name= e.Element("name").Value,
                    Price = decimal.Parse(e.Element("price").Value),
                    Quantity= int.Parse(e.Element("quantity").Value),
            //        SupplierId= int.Parse(e.Element("supplierId").Value),
                   Supplier = dbctx.Suppliers.Find( int.Parse(e.Element("supplierId").Value))
                })
                .ToList();
            dbctx.Parts.AddRange(parts);
            dbctx.SaveChanges();
            return $"Successfully imported {parts.Count}";
        }
    }
}
