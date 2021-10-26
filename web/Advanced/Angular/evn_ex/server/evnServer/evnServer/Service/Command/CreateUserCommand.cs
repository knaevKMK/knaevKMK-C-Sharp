
namespace evnServer.Service.Command
{
using AutoMapper;
using evnServer.Data.Repositories;
using evnServer.Model.Entity;
using evnServer.Model.Service;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;


    public class CreateUserCommand : IRequest<int>
    {
        public UserServiceModel userServiceModel;
    }
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IConfigurationProvider mapper;
        private readonly IUserRepository userRepository;
        private readonly IDepartmentRepository departmentRepository;

        public CreateUserCommandHandler(IMapper mapper,
            IUserRepository userRepository,
         IDepartmentRepository departmentRepository)
        {
            this.userRepository = userRepository;
            this.mapper = mapper.ConfigurationProvider;
            this.departmentRepository = departmentRepository;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
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
