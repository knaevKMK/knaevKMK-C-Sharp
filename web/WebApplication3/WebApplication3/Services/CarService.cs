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

        public ICollection<CarDto> AllCars()
        {


            //ToDo
            throw new NotImplementedException();
        }

        public CarDto DeleteCar(int id)
        {
            //ToDo
            throw new NotImplementedException();
        }

        public CarDto GetCarById(int id)
        {
            //ToDo
            throw new NotImplementedException();
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

            Console.WriteLine();
            foreach (var carDto in carDtos)
            {
                try { 
                Car car = new Car() {
                Make=carDto.make,
                Model= carDto.model,
                TravelledDistance = carDto.travelledDistance
                };

                    foreach (var id in carDto.partsId)
                    {
                        Part part = partRepository.GetById(id);
                        if (part==null)
                        {
                            continue;
                        }
                        PartCar partCar = new PartCar { Car = car, Part = part };
                        car.PartCars.Add(partCar);
                    }
                  CarRepository.Add(car);
            }catch (Exception) { continue; }
        }


        }
    }
}
