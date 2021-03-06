using AutoMapper;
using Data;
using Models.DtoImport;
using Models.Entities;
using Nancy.Json;
using Newtonsoft.Json;
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

        public string ExportSalesWithAppliedDiscount()
        {

            var list = db.Sales
                .Where(x=>x.Car!=null && x.Customer!=null)
                .Take(10)
                .Select(s => new
                {
                    car = new
                    {
                        Make = s.Car.Make,
                        Models = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    customerName = s.Customer.Name,
                    Discount = s.Discount,
                    price = s.Car.Parts.Select(p=>p.Price).Sum(),
                    priceWithDiscount = s.Car.Parts.Select(p => p.Price).Sum() * (1-s.Discount/100)
                })
                .OrderByDescending(x=>x.priceWithDiscount)
                .ToList();
            string jsonData = JsonConvert.SerializeObject(list);

            File.WriteAllText(
                FilePats.EXPORT_DIRECTORY+FilePats.EXPORT_SALES_DISCOUNT
                ,jsonData);


            return "Success create file " + FilePats.EXPORT_SALES_DISCOUNT;
        }
    }
}
