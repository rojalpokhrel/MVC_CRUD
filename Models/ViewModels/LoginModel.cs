using System.ComponentModel.DataAnnotations;

namespace ThisIsIt.Models.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage="Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
       
        public bool KeepLoggedIn { get; set; }
        public bool isLogin { get; set; }   
        public LoginModel() { 
            isLogin = false;
        } 
    }
}
