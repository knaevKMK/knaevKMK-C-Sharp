using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Repositories
{
  public   interface ICarRepository
    {

        ICollection<Car> GetAllCars();
        void AddCars(ICollection<Car> cars);


        Car GetCarById(int id);

        Car AddCar(Car car);
        Car DeleteCar(int id);
        Car UpdateCar(Car car);
    }
}
