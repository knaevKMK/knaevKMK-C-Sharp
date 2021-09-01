using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;
using WebApplication3.Repositories;
using WebApplication3.Views.ExportDto;
using WebApplication3.Views.ImportDto;

namespace WebApplication3.Services
{
    public class CarService : ICarService
    {
        private readonly IRepository CarRepository;
     //   private readonly IMapper mapper;

        public CarService(
            IRepository CarRepository
            //,IMapper mapper
            )
        {
            this.CarRepository = CarRepository;
       //     this.mapper = mapper;
        }
        public void AddAllCars(ICollection<CarImportDto> carsDto)
        {
            List<Car> cars = carsDto
                 .Select(MapCarImportDtoToEntity)
                 .ToList();
            this.CarRepository.AddCars(cars);
        }

        private Car MapCarImportDtoToEntity(CarImportDto carDto)
        {

            //ToDo Validate
            Car car = //mapper.Map<Car>(carDto);
                new Car() { };
            //ToDo Create and add fields: manufacturer, model, enums
            return car;
        }

        public CarExportDto AddCar(CarImportDto carDto)
        {
            Car car = this.CarRepository.AddCar(MapCarImportDtoToEntity(carDto));

            return this.MapCarEntityToExportDto(car);


        }

        public ICollection<CarExportDto> AllCars()
        {
            ICollection<Car> cars = this.CarRepository.GetAllCars();
           
           
               return cars  .Select(car => new CarExportDto() {
                  Manufacturer=car.Model.Manufacturer.Name,
                  Model= car.Model.Name,
                  ImageUrl=car.ImageUrl,
                  Engine=car.Engine.Type,
                  Transmision=car.Transmision.Type,
                  type=car.TypeCabin.Type
                  })
                  .ToList();
        }

        public CarExportDto DeleteCar(int id)
        {
            //ToDo
            throw new NotImplementedException();
        }

        public CarExportDto GetCarById(int id)
        {
            //ToDo
            throw new NotImplementedException();
        }

        public CarExportDto UpdateCar(CarImportDto carDto)
        {
            //ToDo
            throw new NotImplementedException();
        }


        private CarExportDto MapCarEntityToExportDto(Car car)
        {
            //   return mapper.Map<CarExportDto>(car);
            return new CarExportDto() {
                Manufacturer = car.Model.Manufacturer.Name,
                Model = car.Model.Name,
                ImageUrl = car.ImageUrl,
                type = car.TypeCabin.Type,
                Id = car.Id,
                Engine = car.Engine.Type,
                Transmision = car.Transmision.Type
            };
        }
    }
}
