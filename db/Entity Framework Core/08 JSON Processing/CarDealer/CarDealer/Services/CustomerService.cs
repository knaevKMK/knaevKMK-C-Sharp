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
    public class CustomerService
    {

        private static ApplicationDbContext db = new ApplicationDbContext();
        private static IMapper Mapper = new MapperConfiguration(c => {
            c.CreateMap<CustomerImportDto, Customer>();
        }).CreateMapper();
        public string ImportFromJson()
        {

            ICollection<CustomerImportDto> customerDtos = new JavaScriptSerializer().Deserialize<ICollection<CustomerImportDto>>(
                File.ReadAllText(FilePats.IMPORT_DIRECTORY+FilePats.IMPORT_CUSTOMERS));
            foreach (var customerDto in customerDtos)
            {
                Customer customer = Mapper.Map<Customer>(customerDto);
                db.Customers.Add(customer);
                db.SaveChanges();
            }


            return $"Successfully imported {db.Customers.Count<Customer>()}.";
        }
    }
}
