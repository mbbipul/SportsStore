using Microsoft.AspNetCore.Mvc;
using SportsStore_v1.Models;

namespace SportsStore_v1.Components {
    public class CartSummaryViewComponent : ViewComponent {
        private Cart cart;
        public CartSummaryViewComponent(Cart cartService) {
            cart = cartService;
        }
        public IViewComponentResult Invoke() {
            return View(cart);
        }
    }
}