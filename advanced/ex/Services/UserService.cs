
namespace ex.Services
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using ex.Data;
    using ex.Models;
    using ex.Models.Binding;
    using ex.Models.Service;
    using ex.Models.View;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class UserService : IUserService
    {

        private readonly ApplicationDbContext data;
        private readonly IConfigurationProvider _mapper;

        public UserService(ApplicationDbContext data, IMapper mapper)
        {
            this.data = data;
            this._mapper = mapper.ConfigurationProvider;
        }

       
        public void add(UserServiceModel userServiceModel)
        {
            User user = _mapper.CreateMapper().Map<User>(userServiceModel);
            Department department = data.Departments.FirstOrDefault(d => d.Name == userServiceModel.DepartmentName);
            user.Department = department;
            user.Code = " "
                + (1 + this.data.Users.Count()).ToString().PadLeft(3, '0')
                + department.Code
                + getLastSixDigits(userServiceModel.BirthDate);

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
            var query = this.data.Users.Where(u => u.Id != null);
            PropertyInfo[] properties = typeof(FilterDto).GetProperties();
            foreach (var field in properties)
            {
                var _value = field.GetValue(sort);
                if (_value == null)
                {
                    continue;
                }

                switch (field.Name)
                {
                    //sort
                    case "IdSort":
                        query = (byte)_value == (byte)1 ? query.OrderByDescending(u => u.Id)
                 : query.OrderBy(u => u.Id); break;
                    case "NameSort":
                        query = (byte)_value == (byte)1 ? query.OrderByDescending(u => u.FullName)
               : query.OrderBy(u => u.FullName); break;
                    case "DeprtmentSort":
                        query = (byte)_value == (byte)1 ? query.OrderByDescending(u => u.Department)
          : query.OrderBy(u => u.Department); break;
                    case "EdicationSort":
                        query = (byte)_value == (byte)1 ? query.OrderByDescending(u => u.Education)
          : query.OrderBy(u => u.Education); break;
                    case "ScoreSort":
                        query = (byte)_value == (byte)1 ? query.OrderByDescending(u => (int)u.Score)
              : query.OrderBy(u => (int)u.Score); break;
                    case "BirthYearSort":
                        query = (byte)_value == (byte)1 ? query.OrderByDescending(u => u.BirthDate.Year)
          : query.OrderBy(u => u.BirthDate.Year); break;


                    // filter
                    case "Name": query = query.Where(u => u.FullName.Contains(sort.Name)); break;
                    case "Department": query = query.Where(u => u.Department.Name.Equals(sort.Department.Value.ToString())); break;
                    case "Education": query = query.Where(u => u.Education.Contains(sort.Education)); break;
                    case "Score":
                        query =
                  sort.arrowScore == null
                  ? query.Where(u => u.Score == (int)_value)
                  : sort.arrowScore == 0
                                      ? query.Where(u => u.Score < sort.Score)
                                      : query.Where(u => u.Score > sort.Score); break;
                    case "BirthYaer":
                        query =
           sort.arrowBirth == null
            ? query.Where(u => u.BirthDate.Year == (int)_value)
            : sort.arrowBirth == 0 ? query.Where(u => u.BirthDate.Year < sort.BirthYaer)
                                    : query.Where(u => u.BirthDate.Year > sort.BirthYaer); break;


                }
           
            }

            return query
                  .ProjectTo<UserViewModel>(_mapper)
                  .ToList();

        }

        public List<UserViewModel> getAll()
        {
            return data.Users
                  .ProjectTo<UserViewModel>(_mapper)
                  .ToList();
        }
    }
}