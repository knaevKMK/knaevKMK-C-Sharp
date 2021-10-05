using System.ComponentModel.DataAnnotations;

namespace Demo_Server.Data.Model.Identity
{
    public class UserLoginRequestModel
    {
        [Required]
        public string Username { get; set; }
      
        [Required]
        public string Password { get; set; }
    }
}
