using Microsoft.AspNetCore.Mvc;

namespace Assignment12_1.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
