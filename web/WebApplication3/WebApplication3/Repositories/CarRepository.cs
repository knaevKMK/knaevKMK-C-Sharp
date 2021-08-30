using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDbContext _ctx;

        public CarRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }


        public Car AddCar(Car car)
        {
            _ctx.Cars.Add(car);
            _ctx.SaveChanges();
            return car;
        }
       public void AddCars(ICollection<Car> cars)
        {
            _ctx.Cars.AddRange(cars);
            _ctx.SaveChanges();
        }
        public Car DeleteCar(int id)
        {
            Car car = this.GetCarById(id);
            _ctx.Cars.Remove(car);
            _ctx.SaveChanges();
            return car;

        }

        public ICollection<Car> GetAllCars()
        {
            return _ctx.Cars
                    .OrderBy(c=>c.Manufacturer.Name)
                    .ToList<Car>();
        }

        public Car GetCarById(int id)
        {
            Car car = _ctx.Cars.First(c => c.Id == id);
            if (car == null)
            {
                throw new ArgumentNullException($"Car with id {id} does not exist");
            }
            return car;
        }

        public Car UpdateCar( Car car)
        {
            _ctx.Cars.Attach(car);
            _ctx.SaveChanges();

            return car;
        }
    }
}
