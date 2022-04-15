using System.ComponentModel.DataAnnotations;
namespace Assignment12_1.ViewModels
{
    public class RegisterViewModel:LoginViewModel
    {
        [Required(ErrorMessage = "First name is a required field.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is a required field")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter your phone number")]
        [DataType(DataType.PhoneNumber)]
        public int PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please enter your email address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
