
namespace evnServer.Service.impl
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using evnServer.Data;
    using evnServer.Model.Binding;
    using evnServer.Model.Entity;
    using evnServer.Model.Service;
    using evnServer.Model.View;
    using System;
using System.Collections.Generic;
using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    public class UserService: IUserService
    {

        private readonly ApplicationDbContext data;
        private readonly IConfigurationProvider mapper;

        public UserService(IMapper mapper, ApplicationDbContext data)
        {
            this.mapper = mapper.ConfigurationProvider;
            this.data = data;
        }

        public List<UserViewModel> All()
        {
            return this.data.Users
                   .ProjectTo<UserViewModel>(this.mapper)
                   .ToList();

        }

        public async Task<int> Create(UserServiceModel userServiceModel)
        {
            User user = mapper.CreateMapper().Map<User>(userServiceModel);
            user.Department = data.Departments.FirstOrDefault(d => d.Name == userServiceModel.DepartmentName);

            user.Code =
                (1 + this.data.Users.Count()).ToString().PadLeft(3, '0')
                + user.Department.Code
                + GetLAstSixDigits(userServiceModel.BirthDate);

            await this.data.Users.AddAsync(user);
            this.data.SaveChanges();
            return await Task.FromResult(user.Id);
        }


        private string GetLAstSixDigits(DateTime birthDate)
        {
            string[] s = birthDate.GetDateTimeFormats()[2].Split("/");
            return s[1].PadLeft(2, '0') + s[0].PadLeft(2, '0') + s[2].PadLeft(2, '0');
        }

        public List<UserViewModel> filter(FilterDto sort)
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
                    case "Department": query = query.Where(u => u.Department.Name.Equals(sort.Department)); break;
                    case "Education": query = query.Where(u => u.Education.Contains(sort.Education)); break;
                    case "Score":
                        query =
                  sort.ArrowScore == null
                  ? query.Where(u => u.Score == (int)_value)
                  : sort.ArrowScore == 0
                                      ? query.Where(u => u.Score < sort.Score)
                                      : query.Where(u => u.Score > sort.Score); break;
                    case "BirthYaer":
                        query =
           sort.ArrowBirth == null
            ? query.Where(u => u.BirthDate.Year == (int)_value)
            : sort.ArrowBirth == 0 ? query.Where(u => u.BirthDate.Year < sort.BirthYaer)
                                    : query.Where(u => u.BirthDate.Year > sort.BirthYaer); break;


                }

            }

            return query
                  .ProjectTo<UserViewModel>(mapper)
                  .ToList();

        }
    }
}

