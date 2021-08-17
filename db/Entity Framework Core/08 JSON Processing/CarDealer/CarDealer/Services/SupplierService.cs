

using AutoMapper;
using Data;
using Models.DtoImport;
using Models.Entities;
using Nancy.Json;
using Newtonsoft.Json;
using Static;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SupplierService
    {
        private static ApplicationDbContext db = new ApplicationDbContext();
        private static IMapper mapper = new MapperConfiguration(c=> {
            c.CreateMap<SpplierImportDto,Supplier>();
        }).CreateMapper();


        public static string ImportFromJson() {
            if (db.Suppliers.Count<Supplier>()>0)
            {
                return "Spplier DB is not Empty";
            }

            ICollection<SpplierImportDto> spplierImportDtos = new JavaScriptSerializer()
                .Deserialize<ICollection<SpplierImportDto>>(File.ReadAllText(FilePats.IMPORT_DIRECTORY + FilePats.IMPORT_SUPPLIERS));
            foreach (var suplierDto in spplierImportDtos)
            {
                Supplier supplier = mapper.Map<Supplier>(suplierDto);

                db.Suppliers.Add(supplier);
                db.SaveChanges();

            }

            return $"Successfully imported {db.Suppliers.Count<Supplier>()}.";
        }

        public string ExportLocalSuppliers()
        {

            var list = db.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new { 
                    Id=s.Id,
                    Name=s.Name,
                    PartsCount= s.Parts.Count()
                })
                .ToList();

            string jsonData = JsonConvert.SerializeObject(list);

            File.WriteAllText(
                FilePats.EXPORT_DIRECTORY+FilePats.EXPORT_SUPPLIER_LOCAL
                , jsonData);

            return "Success create file " + FilePats.EXPORT_SUPPLIER_LOCAL;
        }
    }
}
