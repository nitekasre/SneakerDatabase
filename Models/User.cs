using Microsoft.AspNetCore.Identity;
namespace Assignment12_1.Models
{
    public class User:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
