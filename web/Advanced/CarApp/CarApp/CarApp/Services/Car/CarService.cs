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

        public CarQueryServiceModel All(
             string brand = null,
            string searchTerm = null,
           CarSorting sorting = CarSorting.DateCreated,
            int currentPage = 1,
            int carsPerPage = int.MaxValue,
            bool publicOnly = true)
        {

            var carsQuery = this.data.Cars
                .Where(c => !publicOnly || c.IsPublic);

            if (!string.IsNullOrWhiteSpace(brand))
            {
                carsQuery = carsQuery.Where(c => c.Brand == brand);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                carsQuery = carsQuery.Where(c =>
                    (c.Brand + " " + c.Model).ToLower().Contains(searchTerm.ToLower()) ||
                    c.Description.ToLower().Contains(searchTerm.ToLower()));
            }

            var totalCars = carsQuery.Count();

            var cars = GetCars(carsQuery
                .Skip((currentPage - 1) * carsPerPage)
                .Take(carsPerPage));

            return new CarQueryServiceModel
            {
                TotalCars = totalCars,
                CurrentPage = currentPage,
                CarsPerPage = carsPerPage,
                Cars = cars
            };
        }
        private IEnumerable<CarDetailsServiceModel> GetCars(IQueryable<Car> carQuery)
           => carQuery
               .ProjectTo<CarDetailsServiceModel>(this.mapper)
               .ToList();
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
        public IEnumerable<string> AllBrands()
            => this.data
                .Cars
                .Select(c => c.Brand)
                .Distinct()
                .OrderBy(br => br)
                .ToList();

        public CarDetailsServiceModel GetCarById(int id) =>
            this
            .data
            .Cars
            .Where(c => c.Id == id)
            .ProjectTo<CarDetailsServiceModel>(mapper)
            .FirstOrDefault();
    }
}
