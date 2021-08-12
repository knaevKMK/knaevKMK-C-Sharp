using AutoMapper;
using RealEstate.Data;
using RealEstates.Importers.Dto;
using RealEstates.Models;
using RealEstates.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
namespace RealEstates.Importers
{
    class Program
    {
        static void Main(string[] args)
        {
          
            ImportJsonFile("../../../resourse/HouseSofia.json");
        }

        private static void ImportJsonFile(string filename)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap< PropertyJsonDto,Property>();
            });

            var mapper = config.CreateMapper();
            var dbContext = new ApplicationDBContext();
            IPropertyService propertyService = new PropertyService(dbContext);


            var properties = JsonSerializer.Deserialize<IEnumerable<PropertyJsonDto>>(
                File.ReadAllText(filename));

            foreach (var propertyDto in properties)
            {

                var property = mapper.Map<Property>(propertyDto);

                //set TypeRpoperty
                TypeProperty typeProperty = dbContext.TypeProperties
                    .FirstOrDefault(x=>x.Name==propertyDto.BuildingType);

                if (typeProperty==null)
                {

                   typeProperty =(new TypeProperty { Name = propertyDto.PropertyType });
                }
                property.TypeProperty = typeProperty;

                //set Building
                Building building = dbContext.Buildings.FirstOrDefault(x => x.Name == propertyDto.BuildingType);

                if (building==null)
                {
                    building = new Building { Name = propertyDto.BuildingType };
                }
                property.Building = building;

                //set district as class,now is string


                //TODO check property relations before save-- debug

                Console.WriteLine();

              propertyService.Add(property);
            }
        }
    }
}
