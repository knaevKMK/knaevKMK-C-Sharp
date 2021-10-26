
namespace evnServer.Service
{
    using AutoMapper;
    using evnServer.Model.View;
    using evnServer.Service.Queries;
    using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
    public class DepartmentService : IDepartmentService
    {

        private readonly IConfigurationProvider mapper;
        private readonly IMediator mediator;

        public DepartmentService(IConfigurationProvider mapper, IMediator mediator)
        {
            this.mapper = mapper;
            this.mediator = mediator;
        }

        public async Task<List<DepartmentViewModel>> GetAll()
        {
            return await this.mediator.Send(new DepartmentAllQuery());
        }
    }
}
