
namespace EvnWithAngular.Services.impl
{
using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using EvnWithAngular.Data;
    using EvnWithAngular.Models.Entites;
    using EvnWithAngular.Models.Service;
    using EvnWithAngular.Models.Views;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class UserService:IUserService
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
                (1+this.data.Users.Count()).ToString().PadLeft(3,'0')
                + user.Department.Code
                +GetLAstSixDigits(userServiceModel.BirthDate);

          await  this.data.Users.AddAsync(user);
            this.data.SaveChanges();
            return await Task.FromResult(user.Id);
        }

      
        private string GetLAstSixDigits(DateTime birthDate)
        {
            string[] s = birthDate.GetDateTimeFormats()[2].Split("/");
            return s[1].PadLeft(2, '0') + s[0].PadLeft(2, '0') + s[2].PadLeft(2, '0');
        }
    }
}
