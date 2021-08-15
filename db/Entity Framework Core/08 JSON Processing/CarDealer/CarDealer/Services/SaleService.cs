using AutoMapper;
using Data;
using Models.DtoImport;
using Models.Entities;
using Nancy.Json;
using Static;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SaleService
    {
        private static ApplicationDbContext db = new ApplicationDbContext();
        private static IMapper Mapper = new MapperConfiguration(c => {
            c.CreateMap<SaleImportDto, Sale>();
        }).CreateMapper();
        public string ImportFromJson()
        {
            ICollection<SaleImportDto> saleDtos = new JavaScriptSerializer().Deserialize<ICollection<SaleImportDto>>(
                File.ReadAllText(FilePats.IMPORT_DIRECTORY + FilePats.IMPORT_SALES));
            foreach (var saleDto in saleDtos)
            {
                Sale sale = Mapper.Map<Sale>(saleDto);
                Car car = db.Cars.FirstOrDefault(x => x.Id == saleDto.carId);
               if (car == null)
                {
                    continue;
                }
                //TODO
                //    sale.CarId = null;
                sale.Car = car;

                Customer customer = db.Customers.FirstOrDefault(x => x.Id == saleDto.customerId);

                if (customer == null)
                {
                    continue;
                }
                sale.Customer = customer;

                db.Sales.Add(sale);
                 db.SaveChanges();

            }


            return $"Successfully imported {db.Sales.Count<Sale>()}.";
        }
    }
}
