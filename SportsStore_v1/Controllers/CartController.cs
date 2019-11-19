using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SportsStore_v1.Infrastructure;
using SportsStore_v1.Models;
using SportsStore_v1.Models.ViewModels;

namespace SportsStore_v1.Controllers{
    public class CartController : Controller {
    private IProductRepository repository;
    private Cart cart;
    public CartController(IProductRepository repo, Cart cartService) {
        repository = repo;
        cart = cartService;
    }
    public ViewResult Index(string returnUrl) {
        return View(new CartIndexViewModel {
            Cart = cart,
            ReturnUrl = returnUrl
        });
    }
    public RedirectToActionResult AddToCart(int productId, string returnUrl) {
        Product product = repository.Products
            .FirstOrDefault(p => p.ProductId == productId);
        if (product != null) {
            cart.AddItem(product, 1);
        }
        return RedirectToAction("Index", new { returnUrl });
    }
    public RedirectToActionResult RemoveFromCart(int productId,
        string returnUrl) {
        
        Product product = repository.Products
            .FirstOrDefault(p => p.ProductId == productId);
        if (product != null) {
            cart.RemoveLine(product);
        }
        return RedirectToAction("Index", new { returnUrl });
    }
 }
}