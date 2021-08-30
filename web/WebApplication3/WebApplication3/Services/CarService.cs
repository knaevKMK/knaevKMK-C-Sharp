﻿using AutoMapper;
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
        private readonly ICarRepository CarRepository;
        private readonly IMapper mapper;

        public CarService(ICarRepository CarRepository, IMapper mapper)
        {
            this.CarRepository = CarRepository;
            this.mapper = mapper;
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
            Car car = mapper.Map<Car>(carDto);
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
            //ToDo
            throw new NotImplementedException();
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
            return mapper.Map<CarExportDto>(car);
        }
    }
}
