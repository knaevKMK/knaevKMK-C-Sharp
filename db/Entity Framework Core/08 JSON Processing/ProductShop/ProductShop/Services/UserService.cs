using AutoMapper;
using Data;
using Models;
using Models.DtoImport;
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
        private static IMapper Mapper = new MapperConfiguration(c => {
            c.CreateMap<UserImportDto, User>();
        }).CreateMapper();
        private static ApplicationDbContext db = new ApplicationDbContext();
        public void Add(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
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
