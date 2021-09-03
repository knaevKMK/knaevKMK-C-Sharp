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


      
        public bool IsImported() {
            return !CarRepository.IsEmpty();
        }
        public CarDto AddCar(CarDto carDto)
        {
            Car car = CarRepository.Add(MapDtoToEntity(carDto));
            return MapEntityToDto(car);
        }

        public  ICollection<CarDto> AllCars()
        {
           //todo make page allcars to sub-lists

        return    CarRepository.GetAll(0)
                 .Select(car=>MapEntityToDto(car))
                 .ToList();
        }

        private CarDto MapEntityToDto(Car car)
        {
            return new CarDto { Id = car.Id, make = car.Make, model = car.Model, travelledDistance = car.TravelledDistance };
        }

        private Car MapDtoToEntity(CarDto car)
        {
            return new Car { Id = car.Id, Make = car.make, Model = car.model, TravelledDistance = car.travelledDistance };
        }

        public CarDto DeleteCar(int id)
        {
            Car car = CarRepository.Delete(id);
            return car == null ? null : MapEntityToDto(car);
        }

        public CarDto GetCarById(int id)
        {
            Car car = CarRepository.GetById(id);
            return MapEntityToDto(car);
        }

        public CarDto UpdateCar(CarDto carDto)
        {
                    Car car = CarRepository.Update(MapDtoToEntity(carDto));
            return MapEntityToDto(car);
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
