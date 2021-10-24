
namespace evnServer.Service.Handlers
{
using AutoMapper;
using evnServer.Data.Repositories;
using evnServer.Model.Entity;
using evnServer.Service.Queries;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
    public class CreateUserHandler : IRequestHandler<CreateUserQuery, int>
    {
        private readonly IConfigurationProvider mapper;
        private readonly IUserRepository userRepository;
        private readonly IDepartmentRepository departmentRepository;

        public CreateUserHandler(IMapper mapper,
            IUserRepository userRepository,
         IDepartmentRepository departmentRepository)
        {
            this.userRepository = userRepository;
            this.mapper = mapper.ConfigurationProvider;
            this.departmentRepository = departmentRepository;
        }

        public async Task<int> Handle(CreateUserQuery request, CancellationToken cancellationToken)
        {
            User user = mapper.CreateMapper().Map<User>(request.userServiceModel);
            user.Department = departmentRepository.GetDepartmentByName(request.userServiceModel.DepartmentName);

            user.Code =
                (1 + userRepository.Count()).ToString().PadLeft(3, '0')
                + user.Department.Code
                + GetLAstSixDigits(request.userServiceModel.BirthDate);

            User savedUser = await (userRepository.AddAsync(user));
            return savedUser.Id;
        }
        private string GetLAstSixDigits(DateTime birthDate)
        {
            string[] s = birthDate.GetDateTimeFormats()[2].Split("/");
            return s[1].PadLeft(2, '0') + s[0].PadLeft(2, '0') + s[2].PadLeft(2, '0');
        }
    }
}
