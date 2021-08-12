using AutoMapper;
using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DtoImport;
using Services.interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService
    {
        private static IMapper Mapper = new MapperConfiguration(c => {
            c.CreateMap<ProductImportDto, Product>();
        }).CreateMapper();
        private static ApplicationDbContext db = new ApplicationDbContext();
        private static IUserService UserService = new UserService();
        public void Add(Product product)
        {

            db.Products.Add(product);
            db.SaveChanges();
        }

        public string LoadFromJson(string filePath)
        {
            if (db.Products.Count<Product>() != 0)
            {
                return "Product DB is not Empty";

            }
         
                var report = new List<string>();
                IEnumerable<ProductImportDto> productsDto = JsonSerializer.Deserialize<IEnumerable<ProductImportDto>>(File.ReadAllText(filePath));

                foreach (var productDto in productsDto)
                {
                    try {
                        Product product = Mapper.Map<Product>(productDto);
                        if (product == null)
                        {
                            throw new Exception();
                        }
                        product.Seller = db.Users.FirstOrDefault(x=>x.Id== productDto.SellerId);

                        if (productDto.BuyerId != null)
                        {
                            product.Buyer = db.Users.FirstOrDefault(x => x.Id == productDto.BuyerId);

                        }
                       
                        
                        this.Add(product);
                        report.Add("Success add Product - " + product.Name);




                    } catch (Exception e) {
                     
                        report.Add(e.InnerException.ToString());
                    }

                }

               return (string.Join(Environment.NewLine, report));
                    } 
    }
}
