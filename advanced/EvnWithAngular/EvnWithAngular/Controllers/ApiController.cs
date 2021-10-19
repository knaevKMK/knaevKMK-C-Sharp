namespace EvnWithAngular.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public abstract class ApiController:ControllerBase
    {
        protected readonly IConfigurationProvider mapper;

        protected ApiController(IMapper mapper)
        {
            this.mapper = mapper.ConfigurationProvider;
        }
    }
}
