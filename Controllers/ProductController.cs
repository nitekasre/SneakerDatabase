using Microsoft.AspNetCore.Mvc;
using Assignment12_1.Filters;
using Assignment12_1.Models;
using Microsoft.AspNetCore.Authorization;

namespace Assignment12_1.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository; //dependency injection
        }
        public IActionResult Details(int? id)
        {
            var model = _productRepository.GetProduct(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [SImpleActionFilter]
        [Authorize(Roles ="Employee")]
        public IActionResult Index()
        {
            IndexViewModel model = new IndexViewModel();
            model.Products = _productRepository.InitializeData();
            return View(model);
        }
        [Authorize(Roles ="Admin")]
        public IActionResult Create()
        {
            //navigates to the create page
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(Product obj)
        {
            //posts the created data
            //valiation attributes
            if (ModelState.IsValid)
            {
                _productRepository.AddProduct(obj);
            }
            return View();
        }
        [Authorize(Roles ="Admin")]
        public IActionResult Delete(int id)
        {
            //removes the selected employee from the list and returns the user to the index view/refreshes the page
            _productRepository.DeleteProduct(id);
            return RedirectToAction("Index");
        }
        [HttpGet] //will get the employee id and display the items to be updated
        [Authorize(Roles ="Admin")]
        public IActionResult Update(int id)
        {
            Product obj = _productRepository.GetProduct(id);
            return View(obj);
        }
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public IActionResult Update(Product obj, int id)
        {
            //will update the values added to the selected item and return to the index
            obj.Id = id;
            _productRepository.UpdateProduct(obj);
            return RedirectToAction("Index");
        }
    }
}
