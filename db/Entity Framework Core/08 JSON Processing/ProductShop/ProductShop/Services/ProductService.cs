using AutoMapper;
using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DtoImport;
using Nancy.Json;
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
        private static string OUT_PRODUCT_FILE_PATH = "./../../../../Resourses/Out/products-in-range.json";

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

        public string ExportProductInRange(int DownRange, int UpRange)
        {

            var list = db.Products
                .Where(x => x.Price >= DownRange && x.Price <= UpRange)
                .Select(x=>new  { name =x.Name,price=x.Price,seller= x.Seller.FirstName+ " "+x.Seller.LastName  })
                .ToList();



            string jsondata = new JavaScriptSerializer().Serialize(list);

            File.WriteAllText(OUT_PRODUCT_FILE_PATH, jsondata);
            return "Success export: products-in-range.json ";

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
