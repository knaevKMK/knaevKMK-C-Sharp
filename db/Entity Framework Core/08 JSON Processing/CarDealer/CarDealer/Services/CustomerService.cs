using AutoMapper;
using Data;
using Models.DtoExport;
using Models.DtoImport;
using Models.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Static;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Services
{
    public class CustomerService
    {

        private static ApplicationDbContext db = new ApplicationDbContext();
        private static IMapper Mapper = new MapperConfiguration(c => {
            c.CreateMap<CustomerImportDto, Customer>();
            c.CreateMap< Customer, CustomerNameBDateIsYoungDriverDto>()
            .ForMember(e=>e.BirthDate, opt=>opt.MapFrom(src=>src.BirthDate));
          
            c.CreateMap<Customer, CustomerNameBDateIsYoungDriverDto>();
        }).CreateMapper();
       
        public string ImportFromJson()
        {

            string json = File.ReadAllText(path: FilePats.IMPORT_DIRECTORY + FilePats.IMPORT_CUSTOMERS);

            //   List<CustomerImportDto> customerDtos = JsonSerializer.Deserialize<List<CustomerImportDto>>(json);
            List<CustomerImportDto> customerDtos = JsonConvert.DeserializeObject<List<CustomerImportDto>>(json,
     new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd'T'HH:mm:ss" });


            foreach (var customerDto in customerDtos)
            {
                Customer customer = Mapper.Map<Customer>(customerDto);
                customer.BirthDate = customerDto.birthDate;
                Console.WriteLine();
                 db.Customers.Add(customer);
               db.SaveChanges();
            }


            return $"Successfully imported {db.Customers.Count<Customer>()}.";
        }

        public string ExportOrderedCustomers()
        {

            //   List<CustomerNameBDateIsYoungDriverDto> customerDtos =

            var customerDtos = db.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
               .Select(c => Mapper.Map<CustomerNameBDateIsYoungDriverDto>(c))
               //.Select(c=> new
               //{
               //    Name=c.Name,
               //    BurthDate= c.BirthDate,
               //    iSYoungDriver=c.IsYoungDriver
               //})
                .ToList();

            string jsonData =  JsonConvert.SerializeObject(customerDtos);
            Console.WriteLine();
            File.WriteAllText(FilePats.EXPORT_DIRECTORY+FilePats.EXPORT_ORDERED_CUSTOMERS,jsonData);

            return "Success create file ordered-customers.json";
        }

        public string ExportTotalSalesByCustomer()
        {
            using (var context = new ApplicationDbContext())
            {
               
                var list = db.Customers
                              .Where(c => c.Sales.Count() > 0)
                              .Select(c => new {
                                  fullName = c.Name,
                                  boughtCars = c.Sales.Count(),
                                  spentMoney = c.Sales
                                                       .SelectMany(s => s.Car.Parts, (carPrice,partPrice) =>new{ carPrice,partPrice })
                                                       .Select(e=>e.partPrice.Price)
                                                       .Sum()
                              })
                              .OrderByDescending(x=>x.spentMoney)
                              .ThenByDescending(x=>x.boughtCars)
                              .ToList();

                string jsonData = JsonConvert.SerializeObject(list);

                File.WriteAllText(
                    FilePats.EXPORT_DIRECTORY + FilePats.EXPORT_CUSTOMERS_SALES
                    , jsonData);
                return "Success create file " + FilePats.EXPORT_CUSTOMERS_SALES;
            }
          
        }

        private decimal getTotoalPrice(int customerId)
        {

            using (var ctx = new ApplicationDbContext())
            {


                string query = "SELECT SUM(p.Price) " +
    "  FROM Customers as cu " +
     $" Where cu.id = {customerId} " +
      " JOIN Sales as s ON cu.Id = s.CustomerId " +
     " JOIN Cars as ca ON s.CarId = ca.Id " +
     " JOIN CarPart as cp ON ca.Id = cp.CarsId " +
     " JOIN Parts as p ON cp.PartsId = p.Id " +
     " Group By cu.Id";
   //             object result = ctx.Customers.SelectMany.SqlQuery(query);


                return new decimal(0.0);
            }
            }
        }
    }

