using Moq;
using shawbrook_kata.Interfaces.Services;
using shawbrook_kata.Models.Interfaces;
using shawbrook_kata.Services;

namespace shawbrook_kata.UnitTests.Systems.Services
{
    public class ProductServiceTests
    {
        [Fact]
        public async Task GetProducts_ReturnsAllProducts()
        {
            // Arrange
            var expectedProducts = new List<IProduct>
            {
                new Mock<IProduct>().Object,
                new Mock<IProduct>().Object,
                new Mock<IProduct>().Object
            };

            var productRepositoryMock = new Mock<IProductRepository>();
            productRepositoryMock.Setup(pr => pr.RetrieveAllProducts()).ReturnsAsync(expectedProducts);

            var productService = new ProductService(productRepositoryMock.Object);

            // Act
            var result = await productService.GetProducts();

            // Assert
            Assert.Equal(expectedProducts, result);
        }
    }
}
