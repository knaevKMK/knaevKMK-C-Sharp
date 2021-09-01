using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;
using WebApplication3.Views.ImoprtDto;

namespace WebApplication3.Services
{
    public interface ICarService
    {
        bool IsImported();
        ICollection<CarDto> AllCars();
        CarDto GetCarById(int id);
        CarDto AddCar(CarDto carDto);
        CarDto DeleteCar(int id);

        CarDto UpdateCar(CarDto carDto);
        void ImportFromJson();
    }
}
