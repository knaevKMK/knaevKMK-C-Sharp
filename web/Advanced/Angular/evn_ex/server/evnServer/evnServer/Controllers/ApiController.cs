

namespace evnServer.Controllers
{
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public abstract class ApiConteroller: ControllerBase
    {

        protected readonly IConfigurationProvider mapper;

        protected ApiConteroller(IMapper mapper)
        {
            this.mapper = mapper.ConfigurationProvider;
        }
    }
}
