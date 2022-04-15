using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Assignment12_1.Models;
using System.Threading.Tasks;
using Assignment12_1.ViewModels;

namespace Assignment12_1.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<User> _signInManager;
        public UserManager<User> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        public AccountController(SignInManager<User>signInManager, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            //CreateRoles(roleManager);

        }
        public IActionResult Login()
        {
            if(this.User.Identity.IsAuthenticated)
            {
                //if the user's identity is authenticated, it will return to the products view
                return RedirectToAction("Index", "Product");
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Login(LoginViewModel loginView)
        {
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginView.UserName, loginView.Password, loginView.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Product");
                }
            }
            ModelState.AddModelError("", "Failed to login");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerView)
        {
            if (ModelState.IsValid)
            {
                User newuser = new User()
                {
                    FirstName = registerView.FirstName,
                    LastName = registerView.LastName,
                    UserName = registerView.UserName,
                    PhoneNumber = registerView.PhoneNumber.ToString(),
                    Email = registerView.Email
                };
                var result = await _userManager.CreateAsync(newuser, registerView.Password);
                if (result.Succeeded)
                {
                    var addedUser = await _userManager.FindByNameAsync(newuser.UserName);
                    if (addedUser.UserName == "Admin")
                    {
                        await _userManager.AddToRoleAsync(addedUser, "Admin");
                        await _userManager.AddToRoleAsync(addedUser, "Employee");
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(addedUser, "Employee");
                    }
                    return RedirectToAction("Login", "Account");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
