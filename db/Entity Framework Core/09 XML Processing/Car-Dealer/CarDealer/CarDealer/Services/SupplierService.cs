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
    public class SupplierService
    {
      private static  ApplicationDbContext dbctx = new ApplicationDbContext();
        public string importFromXml()
        {

            if (dbctx.Suppliers.Count<Supplier>() >0)
            {
                return "Supplier Db is not empty";
            }
            var suppliers = XDocument
                .Load(Static.Static.READ_DIR_PATH + Static.Static.READ_SUPPLIER_PATH)
                .Root.Elements()
                .Select(e => new Supplier
                {
                    Name = e.Element("name").Value,
                    IsImporter = bool.Parse(e.Element("isImporter").Value)
                })
                .ToList();

            dbctx.Suppliers.AddRange(suppliers);
            dbctx.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }
    }
}
