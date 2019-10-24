using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using SportsStore_v1.Controllers;
using SportsStore_v1.Models;
using SportsStore_v1.Models.ViewModels;
using Xunit;

namespace SportsStore_v1.Tests
{
    public class ProductControllerTests
    {
        [Fact]
       public void Can_Paginate()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();

            mock.Setup(m => m.Products).Returns((new Product[] {
                new Product {ProductId = 1, Name = "P1"},
                new Product {ProductId = 2, Name = "P2"},
                new Product {ProductId = 3, Name = "P3"},
                new Product {ProductId = 4, Name = "P4"},
                new Product {ProductId = 5, Name = "P5"}
            }).AsQueryable<Product>());

            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;
            // Act
            ProductsListViewModel result =
                controller.List(null,2).ViewData.Model as ProductsListViewModel;
            // Assert
            Product[] prodArray = result.Products.ToArray();
            Assert.True(prodArray.Length == 2);
            Assert.Equal("P4", prodArray[0].Name);
            Assert.Equal("P5", prodArray[1].Name);
        }

        [Fact]
        public void  Can_Filter_Products(){
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
             mock.Setup(m => m.Products).Returns((new Product[] {
                new Product {ProductId = 1, Name = "P1", Category = "c1"},
                new Product {ProductId = 2, Name = "P2", Category = "c2"},
                new Product {ProductId = 3, Name = "P3", Category = "c3"},
                new Product {ProductId = 4, Name = "P4", Category = "c2"},
                new Product {ProductId = 5, Name = "P5", Category = "c5"}
            }).AsQueryable<Product>());

            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            Product[] result = 
                        (controller.List("c2",1).ViewData.Model as ProductsListViewModel)
                        .Products.ToArray();
            Assert.Equal(2, result.Length);
            Assert.True(result[0].Name == "P2" && result[0].Category == "c2");
            Assert.True(result[1].Name == "P4" && result[1].Category == "c2");
        }

    }
}
