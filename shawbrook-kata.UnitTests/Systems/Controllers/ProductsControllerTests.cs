using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using shawbrook_kata.Controllers;
using shawbrook_kata.Interfaces.Services;
using shawbrook_kata.Models;
using shawbrook_kata.Models.Interfaces;

namespace shawbrook_kata.Tests.Controllers
{
    public class ProductsControllerTests
    {
        private readonly Mock<IProductService> _productServiceMock;
        private readonly ProductsController _controller;

        public ProductsControllerTests()
        {
            _productServiceMock = new Mock<IProductService>();
            _controller = new ProductsController(_productServiceMock.Object);
        }
        [Fact]
        public async Task GetProducts_ReturnsOkResultWithProducts()
        {
            // Arrange
            var productServiceMock = new Mock<IProductService>();
            var expectedProducts = new List<IProduct>
            {
                new Product()
                {
                    Id = new Guid("4cc48084-74ba-4b58-8cb6-eedb4c5a15e5"),
                    Title = "Membership Item",
                    Price = 9.99m,
                    PhysicalItem = false,
                    Type = "Membership"
                },
                new Product()
                {
                    Id = new Guid("4cc48084-74ba-4b58-8cb6-eedb4c5a15e4"),
                    Title = "Movie Item",
                    Price = 9.99m,
                    PhysicalItem = false,
                    Type = "Books"

                 },
            };

            productServiceMock.Setup(x => x.GetProducts()).ReturnsAsync(expectedProducts);

            var controller = new ProductsController(productServiceMock.Object);

            // Act
            var result = await controller.GetProducts();

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedProducts = Assert.IsAssignableFrom<List<IProduct>>(okObjectResult.Value);

            Assert.Equal(expectedProducts, returnedProducts);
        }

    }
}
