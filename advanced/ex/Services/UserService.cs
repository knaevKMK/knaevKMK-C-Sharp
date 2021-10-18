using AutoMapper;
using ex.Data;
using ex.Models;
using ex.Models.Binding;
using ex.Models.Enums;
using ex.Models.Service;
using ex.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ex.Services
{
    public class UserService: IUserService
    {

        private readonly ApplicationDbContext data;
        private readonly IMapper mapper;

        public UserService(ApplicationDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = configMapper(mapper);
        }

        private IMapper configMapper(IMapper mapper)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<User, UserViewModel>();
                c.CreateMap<UserServiceModel, User>();
            });
            return config.CreateMapper();
        }

        public string CategoryEnum { get; private set; }

        public void add(UserServiceModel userServiceModel)
        {
           
          
            
            User user = mapper.Map<User>(userServiceModel);
            
            user.Code = " " 
                + (1+this.data.Users.Count()).ToString().PadLeft(3,'0') 
                + (int)Enum.Parse(typeof(DepartmentEnum) ,userServiceModel.Department.ToString()) 
                + getLastSixDigits(userServiceModel.BirthDate);


          //  Console.WriteLine();

            this.data.Users.Add(user);
            this.data.SaveChanges();
        }

        private string getLastSixDigits(DateTime birthDate)
        {
            string[] s = birthDate.GetDateTimeFormats()[2].Split("/");
            var result = s[1].ToString().PadLeft(2, '0') + s[0].ToString().PadLeft(2, '0') + s[2].ToString().PadLeft(2, '0');
        //    Console.WriteLine();
            return result;
        }

        public object  getAll(FilterDto sort)
        {
            bool _sort = false;


            IQueryable<User> users = data.Users.AsQueryable();
            PropertyInfo[] properties = typeof(FilterDto).GetProperties();
            foreach (var field in properties)
            {
                var _value=field.GetValue(sort);
                if (_value==null)
                {
                    continue;
                }
              
                switch (field.Name) {
                    case "IdSort": users = users.OrderByDescending(u => u.Id); break;
                    case "NameSort": users = users.OrderByDescending(u => u.FullName); break;
                    case "DeprtmentSort": users = users.OrderByDescending(u => u.Department); break;
                    case "EdicationSort": users = users.OrderByDescending(u => u.Education); break;
                    case "ScoreSort": users = users.OrderByDescending(u => (int)u.Score); break;
                    case "BirthDateSort": users = users.OrderByDescending(u => u.BirthDate); break;
                    case "Name": users = users.Where(u => u.FullName.Any(_u=>u.FullName.Contains((string)_value))); break;
                    case "Department": users = users.Where(u => u.Department.Equals(_value)); break;
                    case "Education": users = users.Where(u => u.Education.Any(_u=>u.Education.Contains((string)_value))); break;
                    case "Score": users = users.Where(u => u.Score==(int)_value); break;
                    case "BirthDate": users= users.Where(u => u.BirthDate.Equals(_value)); break;
                }
                    _sort = true;
            }

            List<UserViewModel> _users = users
                .Select(user => mapper.Map<UserViewModel>(user))
                .ToList();
            return new FilterServiceModel
            {
               IsSorted= _sort,
               users= _users
            };
        }

        public List<UserViewModel> getAll()
        {
            return data.Users
                .Select(user => mapper.Map<UserViewModel>(user))
                .ToList();
        }
    }
}
