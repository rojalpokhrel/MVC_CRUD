using System.ComponentModel.DataAnnotations;

namespace ThisIsIt.Models.ViewModels
{
    public class LoginModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
       
        public bool KeepLoggedIn { get; set; }
    }
}
