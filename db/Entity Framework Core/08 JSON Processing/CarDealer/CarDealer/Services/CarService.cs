
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
    public class CarService
    {
        private static ApplicationDbContext db = new ApplicationDbContext();
        private static IMapper mapper = new MapperConfiguration(c=> {
            c.CreateMap<CarImportDto,Car>();
        }).CreateMapper();
        public string ImportFromJson()
        {
            ICollection<CarImportDto> carImportDtos = new JavaScriptSerializer().Deserialize<ICollection<CarImportDto>>(
                File.ReadAllText(FilePats.IMPORT_DIRECTORY + FilePats.IMPORT_CARS));

            foreach (var carDto in carImportDtos)
            {
                Car car = mapper.Map<Car>(carDto);
            
           //     db.SaveChanges();


                foreach (var partId in carDto.partsId)
                {
                  
                        Part part = db.Parts.Find(partId);
                    if (part==null)
                    {
                        continue;
                    }
                    car.Parts.Add(part);
                }
                db.Cars.Add(car);
                db.SaveChanges();
            }

            return $"Successfully imported {db.Cars.Count<Car>()}.";
        }

        public string CarsByMake(string v)
        {
            throw new NotImplementedException();
        }

        public string ExportCarsWithTheirParts()
        {
            throw new NotImplementedException();
        }
    }
}
