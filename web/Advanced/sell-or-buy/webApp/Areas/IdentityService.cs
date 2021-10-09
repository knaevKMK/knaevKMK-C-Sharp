namespace webApp.Areas
{
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using webApp.Areas.Identity.BindingModels;
    using webApp.Areas.Identity.Model;
    using webApp.Configuration;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Options;
    public class IdentityService : IIdentityService
    {
     //   private readonly UserManager<UserApp> userManager;
        private readonly ApplicationSettings appSettings;

        public IdentityService(
          //  UserManager<UserApp> userManager, 
            IOptions<ApplicationSettings> appSettings)
        {
            //this.userManager = userManager;
            this.appSettings = appSettings.Value;
        }


        public async Task<object> Register(UserManager<UserApp> userManager,UserRegisterBindingModel model)
        {
            if (!model.Password.Equals(model.ConfirmPassword))
            {
                return new { Error = new { Password = "Password and Confirm Password are not same" } };

            }
            var user = await userManager.FindByNameAsync(model.Username);
            if (user != null)
            {
                return new { Error = new { Username = "User with this username exist" } };
            }
            if (await userManager.FindByEmailAsync(model.Email) != null)
            {
                return new { Error = new { Username = "User with this email exist" } };
            }

            var result = userManager.CreateAsync(user, model.Password);

            return new { Status = result.Result, Username = user.UserName };
        }

        public async Task<object> Login(UserManager<UserApp> userManager,UserLoginBindingModel model)
        {
            var user =await userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                return new { Error = new { Username = "User with this username does not exist" } };
            }
            var result =await userManager.CheckPasswordAsync(  user, model.Password);
            if (!result)
            {
                return new { Error = new { Password = "Password does not match" } };
            }
            string token = GetToken(user);

            return new { Token = token };
        }

        private string GetToken(UserApp user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
           return  tokenHandler.WriteToken(token);
        }

     
    }
}
