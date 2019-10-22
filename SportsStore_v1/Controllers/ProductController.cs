
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SportsStore_v1.Models;
using SportsStore_v1.Models.ViewModels;

namespace SportsStore_v1.Controllers
{
    public class ProductController : Controller
    {
        public IProductRepository repository;
        public int PageSize = 4;
        public ProductController(IProductRepository rep)
        {
            repository = rep;
        }
        public ViewResult List(int productPage = 1) => View(
            new ProductsListViewModel {
                Products = repository.Products
                    .OrderBy(p => p.ProductId)
                    .Skip((productPage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo {
                    CurrentPage = productPage,
                    ItemPerPage = PageSize,
                    TotalItems = repository.Products.Count()
                }
            });
            
    }

}