

using AutoMapper;
using Data;
using Models.DtoImport;
using Models.Entities;
using Nancy.Json;
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
            throw new NotImplementedException();
        }
    }
}
