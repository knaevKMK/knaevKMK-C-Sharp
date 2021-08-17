
using AutoMapper;
using Data;
using Models.DtoExport;
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
using System.Text.Json.Serialization;
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

        public string CarsByMake(string carMake)
        {
            var list = db.Cars
                .Where(c => c.Make == carMake)
                .OrderBy(c => c.Model)
                .ThenBy(c => c.TravelledDistance)
                .Select(c => new { 
                    Id=c.Id,
                    Make= c.Make,
                    Model= c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToList();
            string jsonData = JsonConvert.SerializeObject(list);
            File.WriteAllText(FilePats.EXPORT_DIRECTORY+FilePats.EXPORT_CARS_TOYOTA, jsonData);

            return $"Successfully create file toyota-cars.json";
        }

        public string ExportCarsWithTheirParts()
        {

            var list = db.Cars
                .Select(c => new
                {
                    car = new
                    {
                        Make = c.Model,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance
                    },
                    parts = c.Parts
                       .Select(p => new { Name = p.Name, Price = p.Price }).ToList()

        }) 
                .ToList();

           

            string jsonData = JsonConvert.SerializeObject(list);


            File.WriteAllText(FilePats.EXPORT_DIRECTORY+FilePats.EXPORT_CARS_PARTS, jsonData);

            return "Success create " + FilePats.EXPORT_CARS_PARTS;
        }

       
    }
}
