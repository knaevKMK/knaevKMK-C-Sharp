using AutoMapper;
using Data;
using Models;
using Models.DtoImport;
using Nancy.Json;
using Newtonsoft.Json;
using Services.interfaces;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class UserService : IUserService
    {
        private static string OUT_USER_SOLD_PRODUCT_FILE_PATH =
            "./../../../../Resourses/Out/users-sold-products.json";


        private static IMapper Mapper = new MapperConfiguration(c => {
            c.CreateMap<UserImportDto, User>();
        }).CreateMapper();
        private static ApplicationDbContext db = new ApplicationDbContext();
        public void Add(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public string ExportSuccessfullySoldProducts()
        {
            var list = db.Users
                .Where(x => x.BuyedProducts.Count > 0)
                .OrderBy(x=>x.LastName)
                .ThenBy(x=>x.FirstName)
                .Select(x => new {
                    fistName = x.FirstName,
                    lastName = x.LastName,
                    soldProducts = x.BuyedProducts.Select(y => new {
                        name = y.Name,
                        price =y.Price,
                        buyerFirsName=y.Buyer.FirstName,
                        buyerLastName=y.Buyer.LastName
                    }).ToArray()
                }).ToList();
            string jsondata = new JavaScriptSerializer().Serialize(list);

            File.WriteAllText(OUT_USER_SOLD_PRODUCT_FILE_PATH, jsondata);

            return "Success export file users-sold-products.json";
        }

        public User FindUserById(int id)
        {
         
            return   db.Users.Find( id);
        }

        public string ImportFromFile(string filePath)
        {
  

            //Used  Newtonsoft.Json;
         
            if (db.Users.Count<User>()!=0)
            {
                return "User DB is not Empty";
            }
  
            IEnumerable<UserImportDto> UsersDto =JsonConvert.DeserializeObject<IEnumerable<UserImportDto>>(File.ReadAllText(filePath));

            var report = new List<String>();
            foreach (var userDto in UsersDto)
            {
                try {
                    User user = Mapper.Map<User>(userDto);
                    if (user==null)
                    {
                        throw new Exception();
                    }
                    this.Add(user);
                    report.Add("Success add User - " + user.LastName);
                } catch (Exception e) {
                    report.Add("Invalid User");
                }
            }

            return string.Join(Environment.NewLine, report);
        }
    }
}
