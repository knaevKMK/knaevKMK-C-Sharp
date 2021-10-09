using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using webApp.Areas.Identity.BindingModels;
using webApp.Areas.Identity.Model;

namespace webApp.Areas
{
    public interface IIdentityService
    {
        Task<object> Register(UserManager<UserApp> userManager,UserRegisterBindingModel model);
        Task<object> Login(UserManager<UserApp> userManager,UserLoginBindingModel model);
    }
}