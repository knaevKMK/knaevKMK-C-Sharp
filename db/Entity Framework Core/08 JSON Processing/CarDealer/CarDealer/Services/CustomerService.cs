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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }
    }
}
