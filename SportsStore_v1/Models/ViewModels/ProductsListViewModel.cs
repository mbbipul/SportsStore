using System.Collections.Generic;

namespace SportsStore_v1.Models.ViewModels
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products {get; set;}
        public PagingInfo PagingInfo {get; set;}
    }
}