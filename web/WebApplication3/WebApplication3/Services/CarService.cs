using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;
using WebApplication3.Repositories;
using WebApplication3.Views.ImoprtDto;
using Newtonsoft.Json;
using System.IO;

namespace WebApplication3.Services
{
    public class CarService : ICarService
    {
        private readonly PartRepository partRepository;
        private readonly CarRepository CarRepository;
        //   private readonly IMapper mapper;

        public CarService(
            CarRepository CarRepository
, PartRepository partRepository
            //,IMapper mapper
            )
        {
            this.CarRepository = CarRepository;
            this.partRepository = partRepository;
            //     this.mapper = mapper;
        }


        private Car MapCarImportDtoToEntity(CarDto carDto)
        {

            //ToDo Validate
            Car car = //mapper.Map<Car>(carDto);
                new Car() { };
            //ToDo Create and add fields: manufacturer, model, enums
            return car;
        }

        public bool IsImported() {
            return !CarRepository.IsEmpty();
        }
        public CarDto AddCar(CarDto carDto)
        {

            //ToDo
            throw new NotImplementedException();



        }

        public  ICollection<CarDto> AllCars(int? page)
        {
            if (page==null)
            {
                page = 0;
            }


        return    CarRepository.GetAll((int)page)
                 .Select(car=> new CarDto { Id= car.Id, make=car.Make, model=car.Model, travelledDistance=car.TravelledDistance })
                 .ToList();
        }

        public CarDto DeleteCar(int id)
        {
            

            
            Car car = CarRepository.Delete(id);

            return car == null ? null : new CarDto() { Id = car.Id, make = car.Make, model = car.Model };
        }

        public CarDto GetCarById(int id)
        {
            Car car = CarRepository.GetById(id);
            return new CarDto() { Id= car.Id, make=car.Make,model=car.Model,travelledDistance=car.TravelledDistance};
        }

        public CarDto UpdateCar(CarDto carDto)
        {
            //ToDo
            throw new NotImplementedException();
        }


        private CarDto MapCarEntityToExportDto(Car car)
        {
            //ToDo
            throw new NotImplementedException();
        }

        public void ImportFromJson()
        {

            ICollection<CarDto> carDtos = JsonConvert.DeserializeObject<ICollection<CarDto>>(File.ReadAllText("./Data/ImportFromFile/cars.json"));

            foreach (var carDto in carDtos)
            {
                try { 
                Car car = new Car() {
                Make=carDto.make,
                Model= carDto.model,
                TravelledDistance = carDto.travelledDistance
                };
                    IEnumerable<int> enumerable = carDto.partsId.Distinct();
                    foreach (var id in enumerable)
                    {
                        try
                        {
                            Part part = partRepository.GetById(id);
                            if (part==null)
                            {
                                throw new Exception();
                            }

                            car.PartCars.Add(new PartCar() {Part = part });
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }
                                           

                  CarRepository.Add(car);
            }catch (Exception) { continue; }
        }


        }
    }
}
