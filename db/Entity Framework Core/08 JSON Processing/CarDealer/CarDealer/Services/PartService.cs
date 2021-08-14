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
    public class PartService
    {
        private static ApplicationDbContext db = new ApplicationDbContext();
        private static IMapper Mapper = new MapperConfiguration(c=> {
            c.CreateMap<PartImportDto,Part>();
        }).CreateMapper();
        public string ImportFromJson()
        {

            ICollection<PartImportDto> partImportDtos = new JavaScriptSerializer()
                .Deserialize<ICollection<PartImportDto>>(File.ReadAllText(FilePats.IMPORT_DIRECTORY + FilePats.IMPORT_PARTS));

            foreach (var partDto in partImportDtos)
            {
                
                Part part = Mapper.Map<Part>(partDto);
                var supplier = db.Suppliers.FirstOrDefault(x=>x.Id==partDto.supplierId);
                if (supplier==null)
                {
                    continue;
                }
                part.SupplierId = null;
                part.Supplier = supplier;
                db.Parts.Add(part);
             db.SaveChanges();
             }
            return $"Successfully imported {db.Parts.Count<Part>()}.";
        }
    }
}
