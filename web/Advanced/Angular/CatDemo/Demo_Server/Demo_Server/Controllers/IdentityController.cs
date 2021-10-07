
namespace Demo_Server.Controllers
{
    using Demo_Server.Data.Model;
    using Demo_Server.Data.Model.Identity;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    [ApiController]
    [Route("user/")]
    public class IdentityController:ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly ApplicationSettings appSettings;

        public IdentityController(UserManager<User> userManager,IOptions<ApplicationSettings> appSettings)
        {
            this.userManager = userManager;
            this.appSettings = appSettings.Value;
        }


        [Route("load")]
        public async Task<IActionResult> onLoading() {
            return Ok("User work");
        }


        [Route("register")]
        [HttpPost]
        public async Task<ActionResult> Register(UserRegisterRequestModel model) {
            var user = new User {
                Email = model.Email,
                UserName = model.Username,
            };
            var result = await userManager.CreateAsync(user, model.Password);
            return Ok(result);
            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.Errors);
        }
       
        [Route("login")]
        [HttpPost]
        public async Task<ActionResult<object>> Login(UserLoginRequestModel model) {
            User user = await this.userManager.FindByNameAsync(model.Username);
                       if (user==null)
            {
                return Unauthorized();
            }

            var passwordValid = await this.userManager.CheckPasswordAsync(user, model.Password);
            if (!passwordValid)
            {
                return Unauthorized();
            }
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encryptedToken = tokenHandler.WriteToken(token);
            return new { Token = encryptedToken };
        }
    }
}
