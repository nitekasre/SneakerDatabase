using System.ComponentModel.DataAnnotations;
namespace Assignment12_1.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter a username")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter a password")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
