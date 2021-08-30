using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;
using WebApplication3.Views.ExportDto;
using WebApplication3.Views.ImportDto;

namespace WebApplication3.Services
{
    public interface ICarService
    {

        ICollection<CarExportDto> AllCars();
        void AddAllCars(ICollection<CarImportDto> carsDto);
        CarExportDto GetCarById(int id);
        CarExportDto AddCar(CarImportDto carDto);
        CarExportDto DeleteCar(int id);

        CarExportDto UpdateCar(CarImportDto carDto);
    }
}
