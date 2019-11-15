using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SportsStore_v1.Models;

namespace SportsStore_v1.Components {
    public class NavigationMenuViewComponent : ViewComponent {
        private IProductRepository repository;
        public NavigationMenuViewComponent(IProductRepository repo) {
            repository = repo;
        }
        public IViewComponentResult Invoke() {

            ViewBag.SelectedCategory = RouteData?.Values["category"];
            
            if(RouteData?.Values["category"] == null){
                 ViewBag.Home = true;
            }
            return View(repository.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x)
            );
        }
    }
}