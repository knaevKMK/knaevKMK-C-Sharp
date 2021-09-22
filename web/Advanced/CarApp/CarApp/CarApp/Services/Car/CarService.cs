namespace CarApp.Services.Car
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using CarApp.Data;
    using CarApp.Data.Models;
    using CarApp.Models.Car;
    using CarApp.Services.Car.Model;

    public class CarService : ICarService
    {
        private readonly ApplicationDbContext data;
        private readonly IConfigurationProvider mapper;
       

        public CarService(ApplicationDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper.ConfigurationProvider;
        }

        public IEnumerable<CarCategoryServiceModel> AllCategories()
            => this.data
                  .Categories
                  .ProjectTo<CarCategoryServiceModel>(mapper)
                  .ToList();

        public bool CategoryExists(int categoryId)
         => this.data
                .Categories
                .Any(c=>c.Id==categoryId);

        public int Create(CarFromModel car)
        {
            Car carData = new Car
            {
                Brand = car.Brand,
                Model = car.Model,
                Description = car.Description,
                ImageUrl = car.ImageUrl,
                Year = car.Year,
                CategoryId = car.CategoryId,
                IsPublic = car.IsPublic
            };
            data.Cars.Add(carData);
               data.SaveChanges();
            return carData.Id;
        }
    }
}
