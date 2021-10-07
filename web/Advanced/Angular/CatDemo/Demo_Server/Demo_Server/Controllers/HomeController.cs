
namespace Demo_Server.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : ApiController
    {
       // [Authorize]
       [HttpGet]
        public ActionResult Get() {
            return Ok("Work it");
        }
    }
}
