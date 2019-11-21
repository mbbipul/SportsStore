using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SportsStore_v1.Models;

namespace SportsStore_v1.Controllers {
    public class AdminController : Controller {
        private IProductRepository repository;
        public AdminController(IProductRepository repo) {
            repository = repo;
        }
        public ViewResult Index() => 
            View(repository.Products);
        
        public ViewResult Edit(int productId) =>
            View(repository.Products
            .FirstOrDefault(p => p.ProductId == productId));

        [HttpPost]
        public IActionResult Edit(Product product) {

            if (ModelState.IsValid) {
                repository.SaveProduct(product);
                TempData["message"] = $"{product.Name} has been saved";
                return RedirectToAction("Index");
            } else {
            // there is something wrong with the data values
                return View(product);
            }
        }
    }
}