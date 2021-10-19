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

        public List<UserViewModel> getAll(FilterDto sort)
        {
            bool _sort = false;


           var query =  this.data.Users.Where(u=>u.Id!=null);
            PropertyInfo[] properties = typeof(FilterDto).GetProperties();
            foreach (var field in properties)
            {
                var _value=field.GetValue(sort);
                if (_value==null)
                {
                    continue;
                }
              
                switch (field.Name) {
                    //sort
                    case "IdSort": query = (byte)_value==(byte)1? query.OrderByDescending(u => u.Id)
                            : query.OrderBy(u => u.Id); break;
                    case "NameSort": query = (byte)_value == (byte)1 ? query.OrderByDescending(u => u.FullName)
                            : query.OrderBy(u => u.FullName); break;
                    case "DeprtmentSort": query = (byte)_value == (byte)1 ? query.OrderByDescending(u => u.Department)
                            : query.OrderBy(u => u.Department); break;
                    case "EdicationSort": query = (byte)_value == (byte)1 ? query.OrderByDescending(u => u.Education)
                            : query.OrderBy(u => u.Education); break;
                    case "ScoreSort": query = (byte)_value == (byte)1 ? query.OrderByDescending(u => (int)u.Score)
                            : query.OrderBy(u => (int)u.Score); break;
                    case "BirthYaerSort": query = (byte)_value == (byte)1 ? query.OrderByDescending(u => u.BirthDate.Year)
                            : query.OrderBy(u => u.BirthDate.Year); break;

                        
                    // filter
                    case "Name": query = query.Where(u => u.FullName.Contains((string)_value)); break;
                    case "Department": query = query.Where(u => u.Department.Equals(_value)); break;
                    case "Education": query = query.Where(u => u.Education.Contains((string)_value)); break;
                    case "Score": query =
                            sort.arrowScore==null
                            ? query.Where(u => u.Score == (int)_value)
                            : sort.arrowScore==0 
                                                ? query.Where(u=>u.Score<sort.Score)
                                                : query.Where(u=>u.Score>sort.Score); break;
                    case "BirthYaer": query =
                         sort.arrowBirth == null
                          ? query.Where(u => u.BirthDate.Year==(int)_value)
                          : sort.arrowBirth==0 ? query.Where(u => u.BirthDate.Year < sort.BirthYaer)
                                                  : query.Where(u => u.BirthDate.Year > sort.BirthYaer); break;


                    //arrow

                    case "arrowScore":query = (byte)_value == (byte)1 ? query.Where(u => u.Score > sort.Score)
                           : query.Where(u =>u.Score<sort.Score); break;
                    case "arrowBirth": query = (byte)_value == (byte)1 ? query.Where(u => u.BirthDate.Year > sort.BirthYaer)
                           : query.Where(u => u.BirthDate.Year < sort.BirthYaer); break;
                }
                    _sort = true;
            }

          return query.ToList()
                .Select(user => mapper.Map<UserViewModel>(user))
                .ToList();
          
        }

        public List<UserViewModel> getAll()
        {
            return data.Users
                .Select(user => mapper.Map<UserViewModel>(user))
                .ToList();
        }
    }
}
